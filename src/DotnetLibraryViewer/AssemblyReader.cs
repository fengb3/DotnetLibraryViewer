using System.Collections.Immutable;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using DotnetLibraryViewer.Models;

using SR = System.Reflection;

namespace DotnetLibraryViewer;

public static class AssemblyReader
{
    public static AssemblyInfo ReadAssembly(string dllPath, bool includeInherited = false)
    {
        using var stream = File.OpenRead(dllPath);
        using var peReader = new PEReader(stream);
        var reader = peReader.GetMetadataReader();

        var assemblyDef = reader.GetAssemblyDefinition();
        var assemblyName = reader.GetString(assemblyDef.Name);
        var version = assemblyDef.Version.ToString();

        var types = new List<TypeInfo>();
        var handleToFullName = new Dictionary<TypeDefinitionHandle, string>();

        foreach (var typeHandle in reader.TypeDefinitions)
        {
            var typeDef = reader.GetTypeDefinition(typeHandle);
            var typeName = reader.GetString(typeDef.Name);

            if (typeName.StartsWith("<") || typeName.StartsWith("__"))
                continue;

            var visibility = GetTypeVisibility(typeDef.Attributes);
            if (visibility != Accessibility.Public && visibility != Accessibility.Protected)
                continue;

            var (fullName, _, _) = ResolveTypeName(reader, typeHandle);
            handleToFullName[typeHandle] = fullName;

            types.Add(ReadTypeInfo(reader, typeDef, typeName, typeHandle));
        }

        if (includeInherited)
            CollectInheritedMembers(reader, types, handleToFullName);

        return new AssemblyInfo(assemblyName, version, null, types);
    }

    private static TypeDefinitionHandle? ResolveToTypeDefinitionHandle(EntityHandle handle, MetadataReader reader)
    {
        return handle.Kind switch
        {
            HandleKind.TypeDefinition => (TypeDefinitionHandle)handle,
            HandleKind.TypeSpecification => ResolveTypeSpecToDefinition(handle, reader),
            _ => null
        };
    }

    private static TypeDefinitionHandle? ResolveTypeSpecToDefinition(EntityHandle handle, MetadataReader reader)
    {
        // For TypeSpecification (e.g. constructed generic base types),
        // try to extract the underlying generic type definition.
        try
        {
            var typeSpec = reader.GetTypeSpecification((TypeSpecificationHandle)handle);
            // Decode to get the provider which visits the generic type
            var provider = new TypeDefinitionResolver();
            typeSpec.DecodeSignature(provider, null);
            return provider.ResolvedHandle;
        }
        catch
        {
            return null;
        }
    }

    private sealed class TypeDefinitionResolver : ISignatureTypeProvider<TypeDefinitionHandle?, object?>
    {
        public TypeDefinitionHandle? ResolvedHandle { get; private set; }

        public TypeDefinitionHandle? GetPrimitiveType(PrimitiveTypeCode typeCode) => null;
        public TypeDefinitionHandle? GetSZArrayType(TypeDefinitionHandle? elementType) => elementType;
        public TypeDefinitionHandle? GetByReferenceType(TypeDefinitionHandle? elementType) => elementType;
        public TypeDefinitionHandle? GetPointerType(TypeDefinitionHandle? elementType) => elementType;
        public TypeDefinitionHandle? GetPinnedType(TypeDefinitionHandle? elementType) => elementType;

        public TypeDefinitionHandle? GetGenericInstantiation(TypeDefinitionHandle? genericType, ImmutableArray<TypeDefinitionHandle?> typeArguments)
            => genericType;

        public TypeDefinitionHandle? GetArrayType(TypeDefinitionHandle? elementType, ArrayShape shape) => elementType;
        public TypeDefinitionHandle? GetGenericTypeParameter(object? genericContext, int index) => null;
        public TypeDefinitionHandle? GetGenericMethodParameter(object? genericContext, int index) => null;
        public TypeDefinitionHandle? GetModifiedType(TypeDefinitionHandle? modifier, TypeDefinitionHandle? unmodifiedType, bool isRequired) => unmodifiedType;
        public TypeDefinitionHandle? GetFunctionPointerType(MethodSignature<TypeDefinitionHandle?> signature) => null;

        public TypeDefinitionHandle? GetTypeFromDefinition(MetadataReader reader, TypeDefinitionHandle handle, byte rawTypeKind)
        {
            ResolvedHandle = handle;
            return handle;
        }

        public TypeDefinitionHandle? GetTypeFromReference(MetadataReader reader, TypeReferenceHandle handle, byte rawTypeKind) => null;
        public TypeDefinitionHandle? GetTypeFromSpecification(MetadataReader reader, object? genericContext, TypeSpecificationHandle handle, byte rawTypeKind)
            => reader.GetTypeSpecification(handle).DecodeSignature(this, genericContext);
    }

    private static void CollectInheritedMembers(
        MetadataReader reader,
        List<TypeInfo> types,
        Dictionary<TypeDefinitionHandle, string> handleToFullName)
    {
        var fullNameToHandle = new Dictionary<string, TypeDefinitionHandle>();
        foreach (var (handle, name) in handleToFullName)
            fullNameToHandle[name] = handle;

        // Cache base type members to avoid re-decoding for shared base classes
        var baseMembersCache = new Dictionary<TypeDefinitionHandle, List<MemberInfo>>();

        for (int i = 0; i < types.Count; i++)
        {
            var type = types[i];
            if (!fullNameToHandle.TryGetValue(type.FullName, out var typeHandle))
                continue;

            var typeDef = reader.GetTypeDefinition(typeHandle);
            var inheritedMembers = new List<MemberInfo>();
            var seenDocIds = new HashSet<string>(type.Members.Select(m => m.DocId));

            var currentBaseHandle = typeDef.BaseType;
            while (!currentBaseHandle.IsNil)
            {
                var baseTypeDefHandle = ResolveToTypeDefinitionHandle(currentBaseHandle, reader);
                if (baseTypeDefHandle is null)
                    break;

                if (!handleToFullName.TryGetValue(baseTypeDefHandle.Value, out var baseFullName))
                    break;

                if (!baseMembersCache.TryGetValue(baseTypeDefHandle.Value, out var baseMembers))
                {
                    var baseTypeDef = reader.GetTypeDefinition(baseTypeDefHandle.Value);
                    var baseDocIdTypeName = baseFullName.Replace('+', '.');
                    baseMembers = [];
                    baseMembers.AddRange(ReadProperties(reader, baseTypeDef, baseDocIdTypeName));
                    baseMembers.AddRange(ReadMethods(reader, baseTypeDef, baseDocIdTypeName));
                    baseMembers.AddRange(ReadFields(reader, baseTypeDef, baseDocIdTypeName, DetermineTypeKind(reader, baseTypeDef)));
                    baseMembers.AddRange(ReadEvents(reader, baseTypeDef, baseDocIdTypeName));
                    baseMembersCache[baseTypeDefHandle.Value] = baseMembers;
                }

                foreach (var member in baseMembers)
                {
                    if (member.Kind == MemberKind.Constructor) continue;
                    if (!seenDocIds.Add(member.DocId)) continue;
                    inheritedMembers.Add(member with { IsInherited = true });
                }

                // Walk to the next base type in the chain
                var baseTypeDef2 = reader.GetTypeDefinition(baseTypeDefHandle.Value);
                currentBaseHandle = baseTypeDef2.BaseType;
            }

            if (inheritedMembers.Count > 0)
            {
                types[i] = type with
                {
                    Members = [..type.Members, ..inheritedMembers]
                };
            }
        }
    }

    public static void MergeXmlDocs(AssemblyInfo assembly, XmlDocReader xmlDoc)
    {
        var typesList = (List<TypeInfo>)assembly.Types;
        for (int i = 0; i < typesList.Count; i++)
        {
            var type = typesList[i];
            var typeDoc = xmlDoc.GetDoc($"T:{type.FullName.Replace('+', '.')}");

            var mergedMembers = new List<MemberInfo>();
            foreach (var member in type.Members)
            {
                var memberDoc = xmlDoc.GetDoc(member.DocId);
                mergedMembers.Add(memberDoc is not null
                    ? member with
                    {
                        XmlDocSummary = memberDoc.Summary,
                        XmlDocParameters = memberDoc.Parameters,
                        XmlDocTypeParameters = memberDoc.TypeParameters,
                        XmlDocReturns = memberDoc.Returns
                    }
                    : member);
            }

            typesList[i] = type with
            {
                Members = mergedMembers,
                XmlDocSummary = typeDoc?.Summary,
                XmlDocTypeParameters = typeDoc?.TypeParameters
            };
        }
    }

    private static (string fullName, string? ns, string? declaringType) ResolveTypeName(
        MetadataReader reader, TypeDefinitionHandle handle)
    {
        var typeDef = reader.GetTypeDefinition(handle);
        var name = reader.GetString(typeDef.Name);
        var declaringHandle = typeDef.GetDeclaringType();

        if (declaringHandle.IsNil)
        {
            var ns = reader.GetString(typeDef.Namespace);
            var fullName = string.IsNullOrEmpty(ns) ? name : $"{ns}.{name}";
            return (fullName, string.IsNullOrEmpty(ns) ? null : ns, null);
        }

        var (parentFullName, parentNs, _) = ResolveTypeName(reader, declaringHandle);
        return ($"{parentFullName}+{name}", parentNs, parentFullName);
    }

    private static TypeInfo ReadTypeInfo(MetadataReader reader, TypeDefinition typeDef, string typeName, TypeDefinitionHandle typeHandle)
    {
        var (fullName, ns, declaringType) = ResolveTypeName(reader, typeHandle);
        var docIdTypeName = fullName.Replace('+', '.');

        var kind = DetermineTypeKind(reader, typeDef);
        var baseType = GetBaseTypeName(reader, typeDef);
        var isSealed = (typeDef.Attributes & SR.TypeAttributes.Sealed) != 0;
        var isAbstract = (typeDef.Attributes & SR.TypeAttributes.Abstract) != 0;
        var isStatic = isSealed && isAbstract;
        isAbstract = isAbstract && !isStatic;
        isSealed = isSealed && !isStatic;
        var isObsolete = HasObsoleteAttribute(reader, typeDef.GetCustomAttributes());

        var genericParams = new List<string>();
        foreach (var gpHandle in typeDef.GetGenericParameters())
        {
            var gp = reader.GetGenericParameter(gpHandle);
            genericParams.Add(reader.GetString(gp.Name));
        }

        var interfaces = new List<string>();
        foreach (var ifaceHandle in typeDef.GetInterfaceImplementations())
        {
            var iface = reader.GetInterfaceImplementation(ifaceHandle);
            var ifaceName = ResolveEntityHandle(reader, iface.Interface);
            if (ifaceName is not null)
                interfaces.Add(ifaceName);
        }

        var members = new List<MemberInfo>();
        members.AddRange(ReadProperties(reader, typeDef, docIdTypeName));
        members.AddRange(ReadMethods(reader, typeDef, docIdTypeName));
        members.AddRange(ReadFields(reader, typeDef, docIdTypeName, kind));
        members.AddRange(ReadEvents(reader, typeDef, docIdTypeName));

        return new TypeInfo(
            Name: typeName,
            FullName: fullName,
            Namespace: ns,
            Kind: kind,
            BaseType: baseType,
            IsStatic: isStatic,
            IsAbstract: isAbstract,
            IsSealed: isSealed,
            GenericParameterCount: genericParams.Count,
            GenericParameterNames: genericParams,
            Interfaces: interfaces,
            Members: members,
            XmlDocSummary: null,
            DeclaringType: declaringType,
            IsObsolete: isObsolete
        );
    }

    private static TypeKind DetermineTypeKind(MetadataReader reader, TypeDefinition typeDef)
    {
        if ((typeDef.Attributes & SR.TypeAttributes.Interface) != 0)
            return TypeKind.Interface;

        var baseType = GetBaseTypeName(reader, typeDef);
        if (baseType == "System.Enum")
            return TypeKind.Enum;

        if (baseType == "System.ValueType")
            return TypeKind.Struct;

        if (baseType is "System.MulticastDelegate" or "System.Delegate")
            return TypeKind.Delegate;

        return TypeKind.Class;
    }

    private static string? GetBaseTypeName(MetadataReader reader, TypeDefinition typeDef)
    {
        if (typeDef.BaseType.IsNil) return null;
        return ResolveEntityHandle(reader, typeDef.BaseType);
    }

    private static string? ResolveEntityHandle(MetadataReader reader, EntityHandle handle)
    {
        switch (handle.Kind)
        {
            case HandleKind.TypeReference:
                var typeRef = reader.GetTypeReference((TypeReferenceHandle)handle);
                var refNs = reader.GetString(typeRef.Namespace);
                var refName = reader.GetString(typeRef.Name);
                return string.IsNullOrEmpty(refNs) ? refName : $"{refNs}.{refName}";

            case HandleKind.TypeDefinition:
                var td = reader.GetTypeDefinition((TypeDefinitionHandle)handle);
                var defNs = reader.GetString(td.Namespace);
                var defName = reader.GetString(td.Name);
                return string.IsNullOrEmpty(defNs) ? defName : $"{defNs}.{defName}";

            default:
                return null;
        }
    }

    #region Member Reading

    private static IEnumerable<MemberInfo> ReadProperties(MetadataReader reader, TypeDefinition typeDef, string fullTypeName)
    {
        var sigProvider = new DisplaySignatureProvider();
        foreach (var propHandle in typeDef.GetProperties())
        {
            var propDef = reader.GetPropertyDefinition(propHandle);
            var name = reader.GetString(propDef.Name);
            var signature = propDef.DecodeSignature(sigProvider, null);

            var accessors = propDef.GetAccessors();
            var accessibility = Accessibility.Private;
            var isStatic = false;

            if (!accessors.Getter.IsNil)
            {
                var getter = reader.GetMethodDefinition(accessors.Getter);
                accessibility = GetMethodVisibility(getter.Attributes);
                isStatic = (getter.Attributes & SR.MethodAttributes.Static) != 0;
            }
            else if (!accessors.Setter.IsNil)
            {
                var setter = reader.GetMethodDefinition(accessors.Setter);
                accessibility = GetMethodVisibility(setter.Attributes);
                isStatic = (setter.Attributes & SR.MethodAttributes.Static) != 0;
            }

            if (accessibility != Accessibility.Public && accessibility != Accessibility.Protected)
                continue;

            var isObsolete = false;
            if (!accessors.Getter.IsNil)
                isObsolete = HasObsoleteAttribute(reader, reader.GetMethodDefinition(accessors.Getter).GetCustomAttributes());
            if (!isObsolete && !accessors.Setter.IsNil)
                isObsolete = HasObsoleteAttribute(reader, reader.GetMethodDefinition(accessors.Setter).GetCustomAttributes());

            var propTypeName = signature.ReturnType;

            // Build doc ID for indexer params
            var docIdProvider = new DocIdSignatureProvider();
            var docIdSig = propDef.DecodeSignature(docIdProvider, null);
            var docId = docIdSig.ParameterTypes.Length == 0
                ? $"P:{fullTypeName}.{name}"
                : $"P:{fullTypeName}.{name}({string.Join(",", docIdSig.ParameterTypes)})";

            var getterStr = accessors.Getter.IsNil ? "" : "get; ";
            var setterStr = accessors.Setter.IsNil ? "" : "set; ";

            yield return new MemberInfo(
                Name: name,
                DocId: docId,
                Kind: MemberKind.Property,
                Signature: $"{propTypeName} {name} {{ {getterStr}{setterStr}}}".TrimEnd(),
                TypeName: propTypeName,
                Accessibility: accessibility,
                IsStatic: isStatic,
                IsVirtual: false,
                IsAbstract: false,
                Parameters: [],
                ReturnType: propTypeName,
                XmlDocSummary: null,
                IsObsolete: isObsolete
            );
        }
    }

    private static IEnumerable<MemberInfo> ReadMethods(MetadataReader reader, TypeDefinition typeDef, string fullTypeName)
    {
        var sigProvider = new DisplaySignatureProvider();
        foreach (var methodHandle in typeDef.GetMethods())
        {
            var methodDef = reader.GetMethodDefinition(methodHandle);
            var name = reader.GetString(methodDef.Name);

            var accessibility = GetMethodVisibility(methodDef.Attributes);
            if (accessibility != Accessibility.Public && accessibility != Accessibility.Protected)
                continue;

            var isStatic = (methodDef.Attributes & SR.MethodAttributes.Static) != 0;
            var isVirtual = (methodDef.Attributes & SR.MethodAttributes.Virtual) != 0;
            var isAbstract = (methodDef.Attributes & SR.MethodAttributes.Abstract) != 0;
            var isObsolete = HasObsoleteAttribute(reader, methodDef.GetCustomAttributes());

            var signature = methodDef.DecodeSignature(sigProvider, null);
            var returnType = signature.ReturnType;

            var parameters = new List<Models.ParameterInfo>();
            var paramHandles = methodDef.GetParameters();
            int paramIdx = 0;
            foreach (var paramHandle in paramHandles)
            {
                var param = reader.GetParameter(paramHandle);
                var paramName = reader.GetString(param.Name);
                var paramType = paramIdx < signature.ParameterTypes.Length
                    ? signature.ParameterTypes[paramIdx]
                    : "?";

                var isOut = (param.Attributes & SR.ParameterAttributes.Out) != 0;
                var isRef = paramType.StartsWith("ref ");
                parameters.Add(new Models.ParameterInfo(
                    Name: paramName,
                    Type: paramType,
                    IsRef: isRef,
                    IsOut: isOut,
                    IsParams: false
                ));
                paramIdx++;
            }

            var isCtor = name == ".ctor" || name == ".cctor";
            var kind = isCtor ? MemberKind.Constructor : MemberKind.Method;
            var displayName = isCtor
                ? fullTypeName.Contains('.') || fullTypeName.Contains('+')
                    ? fullTypeName[(new[] { fullTypeName.LastIndexOf('.'), fullTypeName.LastIndexOf('+') }.Max() + 1)..]
                    : fullTypeName
                : name;

            var docId = BuildMethodDocId(reader, methodDef, fullTypeName, name);

            var sb = new StringBuilder();
            if (isStatic && !isCtor) sb.Append("static ");
            if (isAbstract) sb.Append("abstract ");
            else if (isVirtual) sb.Append("virtual ");

            if (isCtor)
                sb.Append(displayName);
            else
                sb.Append(returnType).Append(' ').Append(displayName);

            sb.Append('(').Append(string.Join(", ", parameters.Select(p =>
            {
                var prefix = p.IsOut && !p.IsRef ? "out " : p.IsRef ? "ref " : "";
                return $"{prefix}{p.Type} {p.Name}";
            }))).Append(')');

            yield return new MemberInfo(
                Name: displayName,
                DocId: docId,
                Kind: kind,
                Signature: sb.ToString(),
                TypeName: returnType,
                Accessibility: accessibility,
                IsStatic: isStatic,
                IsVirtual: isVirtual,
                IsAbstract: isAbstract,
                Parameters: parameters,
                ReturnType: returnType,
                XmlDocSummary: null,
                IsObsolete: isObsolete
            );
        }
    }

    private static IEnumerable<MemberInfo> ReadFields(MetadataReader reader, TypeDefinition typeDef, string fullTypeName, TypeKind typeKind)
    {
        foreach (var fieldHandle in typeDef.GetFields())
        {
            var fieldDef = reader.GetFieldDefinition(fieldHandle);
            var name = reader.GetString(fieldDef.Name);

            var accessibility = GetFieldVisibility(fieldDef.Attributes);
            if (accessibility != Accessibility.Public && accessibility != Accessibility.Protected)
                continue;

            if (name.StartsWith("<")) continue;

            var isStatic = (fieldDef.Attributes & SR.FieldAttributes.Static) != 0;
            var fieldType = fieldDef.DecodeSignature(new DisplaySignatureProvider(), null);
            var docId = $"F:{fullTypeName}.{name}";
            var isObsolete = HasObsoleteAttribute(reader, fieldDef.GetCustomAttributes());

            yield return new MemberInfo(
                Name: name,
                DocId: docId,
                Kind: MemberKind.Field,
                Signature: $"{(isStatic ? "static " : "")}{fieldType} {name}",
                TypeName: fieldType,
                Accessibility: accessibility,
                IsStatic: isStatic,
                IsVirtual: false,
                IsAbstract: false,
                Parameters: [],
                ReturnType: fieldType,
                XmlDocSummary: null,
                IsObsolete: isObsolete
            );
        }
    }

    private static IEnumerable<MemberInfo> ReadEvents(MetadataReader reader, TypeDefinition typeDef, string fullTypeName)
    {
        foreach (var eventHandle in typeDef.GetEvents())
        {
            var eventDef = reader.GetEventDefinition(eventHandle);
            var name = reader.GetString(eventDef.Name);
            var eventType = ResolveEntityHandle(reader, eventDef.Type) ?? "?";
            var docId = $"E:{fullTypeName}.{name}";
            var isObsolete = HasObsoleteAttribute(reader, eventDef.GetCustomAttributes());

            yield return new MemberInfo(
                Name: name,
                DocId: docId,
                Kind: MemberKind.Event,
                Signature: $"event {eventType} {name}",
                TypeName: eventType,
                Accessibility: Accessibility.Public,
                IsStatic: false,
                IsVirtual: false,
                IsAbstract: false,
                Parameters: [],
                ReturnType: eventType,
                XmlDocSummary: null,
                IsObsolete: isObsolete
            );
        }
    }

    #endregion

    #region Doc ID Building

    private static string BuildMethodDocId(MetadataReader reader, MethodDefinition methodDef, string fullTypeName, string methodName)
    {
        var docIdProvider = new DocIdSignatureProvider();
        var signature = methodDef.DecodeSignature(docIdProvider, null);
        var docIdName = methodName == ".ctor" ? "#ctor" : methodName == ".cctor" ? "#cctor" : methodName;

        int genericParamCount = 0;
        foreach (var _ in methodDef.GetGenericParameters())
            genericParamCount++;

        if (genericParamCount > 0)
            docIdName += $"``{genericParamCount}";

        var paramTypes = new List<string>();
        var paramHandles = methodDef.GetParameters();
        int idx = 0;
        foreach (var _ in paramHandles)
        {
            if (idx < signature.ParameterTypes.Length)
                paramTypes.Add(signature.ParameterTypes[idx]);
            idx++;
        }

        var paramList = string.Join(",", paramTypes);
        return paramList.Length > 0 ? $"M:{fullTypeName}.{docIdName}({paramList})" : $"M:{fullTypeName}.{docIdName}";
    }

    #endregion

    #region Visibility Helpers

    private static Accessibility GetTypeVisibility(SR.TypeAttributes attrs)
    {
        var visibility = attrs & SR.TypeAttributes.VisibilityMask;
        return visibility switch
        {
            SR.TypeAttributes.Public => Accessibility.Public,
            SR.TypeAttributes.NestedPublic => Accessibility.Public,
            SR.TypeAttributes.NestedFamily => Accessibility.Protected,
            SR.TypeAttributes.NestedFamORAssem => Accessibility.ProtectedInternal,
            SR.TypeAttributes.NestedFamANDAssem => Accessibility.PrivateProtected,
            _ => Accessibility.Internal
        };
    }

    private static Accessibility GetMethodVisibility(SR.MethodAttributes attrs)
    {
        var memberAccess = attrs & SR.MethodAttributes.MemberAccessMask;
        return memberAccess switch
        {
            SR.MethodAttributes.Public => Accessibility.Public,
            SR.MethodAttributes.Assembly => Accessibility.Internal,
            SR.MethodAttributes.Family => Accessibility.Protected,
            SR.MethodAttributes.Private => Accessibility.Private,
            SR.MethodAttributes.FamORAssem => Accessibility.ProtectedInternal,
            SR.MethodAttributes.FamANDAssem => Accessibility.PrivateProtected,
            _ => Accessibility.Private
        };
    }

    private static Accessibility GetFieldVisibility(SR.FieldAttributes attrs)
    {
        var access = attrs & SR.FieldAttributes.FieldAccessMask;
        return access switch
        {
            SR.FieldAttributes.Public => Accessibility.Public,
            SR.FieldAttributes.Assembly => Accessibility.Internal,
            SR.FieldAttributes.Family => Accessibility.Protected,
            SR.FieldAttributes.Private => Accessibility.Private,
            SR.FieldAttributes.FamORAssem => Accessibility.ProtectedInternal,
            SR.FieldAttributes.FamANDAssem => Accessibility.PrivateProtected,
            _ => Accessibility.Private
        };
    }

    #endregion

    #region Signature Providers

    private sealed class DisplaySignatureProvider : ISignatureTypeProvider<string, object?>
    {
        public string GetPrimitiveType(PrimitiveTypeCode typeCode) => typeCode switch
        {
            PrimitiveTypeCode.Boolean => "bool",
            PrimitiveTypeCode.Byte => "byte",
            PrimitiveTypeCode.Char => "char",
            PrimitiveTypeCode.Double => "double",
            PrimitiveTypeCode.Int16 => "short",
            PrimitiveTypeCode.Int32 => "int",
            PrimitiveTypeCode.Int64 => "long",
            PrimitiveTypeCode.IntPtr => "nint",
            PrimitiveTypeCode.Object => "object",
            PrimitiveTypeCode.SByte => "sbyte",
            PrimitiveTypeCode.Single => "float",
            PrimitiveTypeCode.String => "string",
            PrimitiveTypeCode.TypedReference => "TypedReference",
            PrimitiveTypeCode.UInt16 => "ushort",
            PrimitiveTypeCode.UInt32 => "uint",
            PrimitiveTypeCode.UInt64 => "ulong",
            PrimitiveTypeCode.UIntPtr => "nuint",
            PrimitiveTypeCode.Void => "void",
            _ => typeCode.ToString()
        };

        public string GetTypeFromDefinition(MetadataReader reader, TypeDefinitionHandle handle, byte rawTypeKind)
        {
            var (displayName, _, _) = GetDisplayNameParts(reader, handle);
            return displayName;
        }

        public string GetTypeFromReference(MetadataReader reader, TypeReferenceHandle handle, byte rawTypeKind)
        {
            var typeRef = reader.GetTypeReference(handle);
            var ns = reader.GetString(typeRef.Namespace);
            var name = StripGenericArity(reader.GetString(typeRef.Name));
            return string.IsNullOrEmpty(ns) ? name : $"{ns}.{name}";
        }

        public string GetSZArrayType(string elementType) => $"{elementType}[]";
        public string GetByReferenceType(string elementType) => $"ref {elementType}";
        public string GetPointerType(string elementType) => $"{elementType}*";
        public string GetGenericInstantiation(string genericType, ImmutableArray<string> typeArguments)
            => $"{genericType}<{string.Join(", ", typeArguments)}>";
        public string GetArrayType(string elementType, ArrayShape shape)
            => $"{elementType}[{new string(',', shape.Rank - 1)}]";
        public string GetGenericTypeParameter(object? genericContext, int index) => $"T{index}";
        public string GetGenericMethodParameter(object? genericContext, int index) => $"T{index}";
        public string GetModifiedType(string modifier, string unmodifiedType, bool isRequired) => unmodifiedType;
        public string GetPinnedType(string elementType) => elementType;
        public string GetFunctionPointerType(MethodSignature<string> signature)
            => $"delegate*<{signature.ReturnType}, {string.Join(", ", signature.ParameterTypes)}>";
        public string GetTypeFromSpecification(MetadataReader reader, object? genericContext, TypeSpecificationHandle handle, byte rawTypeKind)
            => reader.GetTypeSpecification(handle).DecodeSignature(this, genericContext);
    }

    private sealed class DocIdSignatureProvider : ISignatureTypeProvider<string, object?>
    {
        public string GetPrimitiveType(PrimitiveTypeCode typeCode) => typeCode switch
        {
            PrimitiveTypeCode.Boolean => "System.Boolean",
            PrimitiveTypeCode.Byte => "System.Byte",
            PrimitiveTypeCode.Char => "System.Char",
            PrimitiveTypeCode.Double => "System.Double",
            PrimitiveTypeCode.Int16 => "System.Int16",
            PrimitiveTypeCode.Int32 => "System.Int32",
            PrimitiveTypeCode.Int64 => "System.Int64",
            PrimitiveTypeCode.IntPtr => "System.IntPtr",
            PrimitiveTypeCode.Object => "System.Object",
            PrimitiveTypeCode.SByte => "System.SByte",
            PrimitiveTypeCode.Single => "System.Single",
            PrimitiveTypeCode.String => "System.String",
            PrimitiveTypeCode.TypedReference => "System.TypedReference",
            PrimitiveTypeCode.UInt16 => "System.UInt16",
            PrimitiveTypeCode.UInt32 => "System.UInt32",
            PrimitiveTypeCode.UInt64 => "System.UInt64",
            PrimitiveTypeCode.UIntPtr => "System.UIntPtr",
            PrimitiveTypeCode.Void => "System.Void",
            _ => typeCode.ToString()
        };

        public string GetTypeFromDefinition(MetadataReader reader, TypeDefinitionHandle handle, byte rawTypeKind)
        {
            var (displayName, _, _) = GetDisplayNameParts(reader, handle);
            return displayName;
        }

        public string GetTypeFromReference(MetadataReader reader, TypeReferenceHandle handle, byte rawTypeKind)
        {
            var typeRef = reader.GetTypeReference(handle);
            var ns = reader.GetString(typeRef.Namespace);
            var name = reader.GetString(typeRef.Name);
            return string.IsNullOrEmpty(ns) ? name : $"{ns}.{name}";
        }

        public string GetSZArrayType(string elementType) => $"{elementType}[]";
        public string GetByReferenceType(string elementType) => $"{elementType}@";
        public string GetPointerType(string elementType) => $"{elementType}*";
        public string GetGenericInstantiation(string genericType, ImmutableArray<string> typeArguments)
            => $"{genericType}{{{string.Join(",", typeArguments)}}}";
        public string GetArrayType(string elementType, ArrayShape shape)
            => $"{elementType}[{new string(',', shape.Rank - 1)}]";
        public string GetGenericTypeParameter(object? genericContext, int index) => $"`{index}";
        public string GetGenericMethodParameter(object? genericContext, int index) => $"``{index}";
        public string GetModifiedType(string modifier, string unmodifiedType, bool isRequired) => unmodifiedType;
        public string GetPinnedType(string elementType) => elementType;
        public string GetFunctionPointerType(MethodSignature<string> signature) => "System.IntPtr";
        public string GetTypeFromSpecification(MetadataReader reader, object? genericContext, TypeSpecificationHandle handle, byte rawTypeKind)
            => reader.GetTypeSpecification(handle).DecodeSignature(this, genericContext);
    }

    private static (string displayName, string? ns, string? declaringType) GetDisplayNameParts(
        MetadataReader reader, TypeDefinitionHandle handle)
    {
        var typeDef = reader.GetTypeDefinition(handle);
        var name = StripGenericArity(reader.GetString(typeDef.Name));
        var declaringHandle = typeDef.GetDeclaringType();

        if (declaringHandle.IsNil)
        {
            var ns = reader.GetString(typeDef.Namespace);
            var fullName = string.IsNullOrEmpty(ns) ? name : $"{ns}.{name}";
            return (fullName, string.IsNullOrEmpty(ns) ? null : ns, null);
        }

        var (parentName, parentNs, _) = GetDisplayNameParts(reader, declaringHandle);
        return ($"{parentName}.{name}", parentNs, parentName);
    }

    private static bool HasObsoleteAttribute(MetadataReader reader, CustomAttributeHandleCollection attributes)
    {
        foreach (var attrHandle in attributes)
        {
            var attr = reader.GetCustomAttribute(attrHandle);
            string? attrTypeName = attr.Constructor.Kind switch
            {
                HandleKind.MemberReference => GetAttributeTypeName(reader, (MemberReferenceHandle)attr.Constructor),
                HandleKind.MethodDefinition => GetAttributeTypeName(reader, (MethodDefinitionHandle)attr.Constructor),
                _ => null
            };

            if (attrTypeName == "System.ObsoleteAttribute")
                return true;
        }
        return false;
    }

    private static string? GetAttributeTypeName(MetadataReader reader, MemberReferenceHandle handle)
    {
        var parent = reader.GetMemberReference(handle).Parent;
        return ResolveEntityHandle(reader, parent);
    }

    private static string? GetAttributeTypeName(MetadataReader reader, MethodDefinitionHandle handle)
    {
        var declaringType = reader.GetMethodDefinition(handle).GetDeclaringType();
        return ResolveEntityHandle(reader, declaringType);
    }

    private static string StripGenericArity(string name)
    {
        var idx = name.IndexOf('`');
        return idx >= 0 ? name[..idx] : name;
    }

    #endregion
}

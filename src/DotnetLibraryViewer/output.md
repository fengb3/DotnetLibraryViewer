# Newtonsoft.Json
**Version:** 13.0.0.0

## Newtonsoft.Json

### `sealed enum ConstructorHandling`

Specifies how constructors are used when initializing objects during deserialization by the .

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `value__` | `int` |  |
| `Default` | `Newtonsoft.Json.ConstructorHandling` | First attempt to use the public default constructor, then fall back to a single parameterized constructor, then to the non-public default constructor. |
| `AllowNonPublicDefaultConstructor` | `Newtonsoft.Json.ConstructorHandling` | Json.NET will use a non-public default constructor before falling back to a parameterized constructor. |

---

### `sealed enum DateFormatHandling`

Specifies how dates are formatted when writing JSON text.

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `value__` | `int` |  |
| `IsoDateFormat` | `Newtonsoft.Json.DateFormatHandling` | Dates are written in the ISO 8601 format, e.g. "2012-03-21T05:40Z". |
| `MicrosoftDateFormat` | `Newtonsoft.Json.DateFormatHandling` | Dates are written in the Microsoft JSON format, e.g. "\/Date(1198908717056)\/". |

---

### `sealed enum DateParseHandling`

Specifies how date formatted strings, e.g. "\/Date(1198908717056)\/" and "2012-03-21T05:40Z", are parsed when reading JSON text.

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `value__` | `int` |  |
| `None` | `Newtonsoft.Json.DateParseHandling` | Date formatted strings are not parsed to a date type and are read as strings. |
| `DateTime` | `Newtonsoft.Json.DateParseHandling` | Date formatted strings, e.g. "\/Date(1198908717056)\/" and "2012-03-21T05:40Z", are parsed to . |
| `DateTimeOffset` | `Newtonsoft.Json.DateParseHandling` | Date formatted strings, e.g. "\/Date(1198908717056)\/" and "2012-03-21T05:40Z", are parsed to . |

---

### `sealed enum DateTimeZoneHandling`

Specifies how to treat the time value when converting between string and .

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `value__` | `int` |  |
| `Local` | `Newtonsoft.Json.DateTimeZoneHandling` | Treat as local time. If the object represents a Coordinated Universal Time (UTC), it is converted to the local time. |
| `Utc` | `Newtonsoft.Json.DateTimeZoneHandling` | Treat as a UTC. If the object represents a local time, it is converted to a UTC. |
| `Unspecified` | `Newtonsoft.Json.DateTimeZoneHandling` | Treat as a local time if a is being converted to a string. If a string is being converted to , convert to a local time if a time zone is specified. |
| `RoundtripKind` | `Newtonsoft.Json.DateTimeZoneHandling` | Time zone information should be preserved when converting. |

---

### `class DefaultJsonNameTable : Newtonsoft.Json.JsonNameTable`

The default JSON name table implementation.

#### Methods

| Signature | Description |
|-----------|-------------|
| `DefaultJsonNameTable()` | Initializes a new instance of the class. |
| `virtual string Get(char[] , int key, int start, ? length)` | Gets a string containing the same characters as the specified range of characters in the given array. |
| `string Add(string key)` | Adds the specified string into name table. |

---

### `sealed enum DefaultValueHandling`

Specifies default value handling options for the .

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `value__` | `int` |  |
| `Include` | `Newtonsoft.Json.DefaultValueHandling` | Include members where the member value is the same as the member's default value when serializing objects. Included members are written to JSON. Has no effect when deserializing. |
| `Ignore` | `Newtonsoft.Json.DefaultValueHandling` | Ignore members where the member value is the same as the member's default value when serializing objects so that it is not written to JSON. This option will ignore all default values (e.g. null for objects and nullable types; 0 for integers, decimals and floating point numbers; and false for booleans). The default value ignored can be changed by placing the on the property. |
| `Populate` | `Newtonsoft.Json.DefaultValueHandling` | Members with a default value but no JSON will be set to their default value when deserializing. |
| `IgnoreAndPopulate` | `Newtonsoft.Json.DefaultValueHandling` | Ignore members where the member value is the same as the member's default value when serializing objects and set members to their default value when deserializing. |

---

### `sealed enum FloatFormatHandling`

Specifies float format handling options when writing special floating point numbers, e.g. , and with .

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `value__` | `int` |  |
| `String` | `Newtonsoft.Json.FloatFormatHandling` | Write special floating point values as strings in JSON, e.g. "NaN", "Infinity", "-Infinity". |
| `Symbol` | `Newtonsoft.Json.FloatFormatHandling` | Write special floating point values as symbols in JSON, e.g. NaN, Infinity, -Infinity. Note that this will produce non-valid JSON. |
| `DefaultValue` | `Newtonsoft.Json.FloatFormatHandling` | Write special floating point values as the property's default value in JSON, e.g. 0.0 for a property, null for a of property. |

---

### `sealed enum FloatParseHandling`

Specifies how floating point numbers, e.g. 1.0 and 9.9, are parsed when reading JSON text.

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `value__` | `int` |  |
| `Double` | `Newtonsoft.Json.FloatParseHandling` | Floating point numbers are parsed to . |
| `Decimal` | `Newtonsoft.Json.FloatParseHandling` | Floating point numbers are parsed to . |

---

### `sealed enum Formatting`

Specifies formatting options for the .

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `value__` | `int` |  |
| `None` | `Newtonsoft.Json.Formatting` | No special formatting is applied. This is the default. |
| `Indented` | `Newtonsoft.Json.Formatting` | Causes child objects to be indented according to the and settings. |

---

### `abstract interface IArrayPool`1<T>`

Provides an interface for using pooled arrays.

#### Methods

| Signature | Description |
|-----------|-------------|
| `abstract T0[] Rent(int minimumLength)` | Rent an array from the pool. This array must be returned when it is no longer needed. |
| `abstract void Return(T0[] array)` | Return an array to the pool. |

---

### `abstract interface IJsonLineInfo`

Provides an interface to enable a class to return line and position information.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `LineNumber` | `int` | Gets the current line number. |
| `LinePosition` | `int` | Gets the current line position. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `abstract bool HasLineInfo()` | Gets a value indicating whether the class can return line information. |
| `abstract int get_LineNumber()` |  |
| `abstract int get_LinePosition()` |  |

---

### `sealed class JsonArrayAttribute : Newtonsoft.Json.JsonContainerAttribute`

Instructs the how to serialize the collection.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `AllowNullItems` | `bool` | Gets or sets a value indicating whether null items are allowed in the collection. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `bool get_AllowNullItems()` |  |
| `void set_AllowNullItems(bool value)` |  |
| `JsonArrayAttribute()` | Initializes a new instance of the class. |
| `JsonArrayAttribute(bool allowNullItems)` | Initializes a new instance of the class with a flag indicating whether the array can contain null items. |
| `JsonArrayAttribute(string id)` | Initializes a new instance of the class with the specified container Id. |

---

### `sealed class JsonConstructorAttribute : System.Attribute`

Instructs the to use the specified constructor when deserializing that object.

#### Methods

| Signature | Description |
|-----------|-------------|
| `JsonConstructorAttribute()` |  |

---

### `abstract class JsonContainerAttribute : System.Attribute`

Instructs the how to serialize the object.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `Id` | `string` | Gets or sets the id. |
| `Title` | `string` | Gets or sets the title. |
| `Description` | `string` | Gets or sets the description. |
| `ItemConverterType` | `System.Type` | Gets or sets the collection's items converter. |
| `ItemConverterParameters` | `object[]` | The parameter list to use when constructing the described by . If null, the default constructor is used. When non-null, there must be a constructor defined in the that exactly matches the number, order, and type of these parameters. |
| `NamingStrategyType` | `System.Type` | Gets or sets the of the . |
| `NamingStrategyParameters` | `object[]` | The parameter list to use when constructing the described by . If null, the default constructor is used. When non-null, there must be a constructor defined in the that exactly matches the number, order, and type of these parameters. |
| `IsReference` | `bool` | Gets or sets a value that indicates whether to preserve object references. |
| `ItemIsReference` | `bool` | Gets or sets a value that indicates whether to preserve collection's items references. |
| `ItemReferenceLoopHandling` | `Newtonsoft.Json.ReferenceLoopHandling` | Gets or sets the reference loop handling used when serializing the collection's items. |
| `ItemTypeNameHandling` | `Newtonsoft.Json.TypeNameHandling` | Gets or sets the type name handling used when serializing the collection's items. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `string get_Id()` |  |
| `void set_Id(string value)` |  |
| `string get_Title()` |  |
| `void set_Title(string value)` |  |
| `string get_Description()` |  |
| `void set_Description(string value)` |  |
| `System.Type get_ItemConverterType()` |  |
| `void set_ItemConverterType(System.Type value)` |  |
| `object[] get_ItemConverterParameters(? )` |  |
| `void set_ItemConverterParameters(object[] value)` |  |
| `System.Type get_NamingStrategyType()` |  |
| `void set_NamingStrategyType(System.Type value)` |  |
| `object[] get_NamingStrategyParameters(? )` |  |
| `void set_NamingStrategyParameters(object[] value)` |  |
| `bool get_IsReference()` |  |
| `void set_IsReference(bool value)` |  |
| `bool get_ItemIsReference()` |  |
| `void set_ItemIsReference(bool value)` |  |
| `Newtonsoft.Json.ReferenceLoopHandling get_ItemReferenceLoopHandling()` |  |
| `void set_ItemReferenceLoopHandling(Newtonsoft.Json.ReferenceLoopHandling value)` |  |
| `Newtonsoft.Json.TypeNameHandling get_ItemTypeNameHandling()` |  |
| `void set_ItemTypeNameHandling(Newtonsoft.Json.TypeNameHandling value)` |  |
| `JsonContainerAttribute()` | Initializes a new instance of the class. |
| `JsonContainerAttribute(string id)` | Initializes a new instance of the class with the specified container Id. |

---

### `static class JsonConvert`

Provides methods for converting between .NET types and JSON types.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `DefaultSettings` | `System.Func<Newtonsoft.Json.JsonSerializerSettings>` | Gets or sets a function that creates default . Default settings are automatically used by serialization methods on , and and on . To serialize without using any default settings create a with . |

#### Methods

| Signature | Description |
|-----------|-------------|
| `static System.Func<Newtonsoft.Json.JsonSerializerSettings> get_DefaultSettings(? )` |  |
| `static void set_DefaultSettings(System.Func<Newtonsoft.Json.JsonSerializerSettings> value)` |  |
| `static string ToString(System.DateTime value)` | Converts the to its JSON string representation. |
| `static string ToString(System.DateTime value, Newtonsoft.Json.DateFormatHandling format, Newtonsoft.Json.DateTimeZoneHandling timeZoneHandling)` | Converts the to its JSON string representation using the specified. |
| `static string ToString(System.DateTimeOffset value)` | Converts the to its JSON string representation. |
| `static string ToString(System.DateTimeOffset value, Newtonsoft.Json.DateFormatHandling format)` | Converts the to its JSON string representation using the specified. |
| `static string ToString(bool value)` | Converts the to its JSON string representation. |
| `static string ToString(char value)` | Converts the to its JSON string representation. |
| `static string ToString(System.Enum value)` | Converts the to its JSON string representation. |
| `static string ToString(int value)` | Converts the to its JSON string representation. |
| `static string ToString(short value)` | Converts the to its JSON string representation. |
| `static string ToString(ushort value)` | Converts the to its JSON string representation. |
| `static string ToString(uint value)` | Converts the to its JSON string representation. |
| `static string ToString(long value)` | Converts the to its JSON string representation. |
| `static string ToString(ulong value)` | Converts the to its JSON string representation. |
| `static string ToString(float value)` | Converts the to its JSON string representation. |
| `static string ToString(double value)` | Converts the to its JSON string representation. |
| `static string ToString(byte value)` | Converts the to its JSON string representation. |
| `static string ToString(sbyte value)` | Converts the to its JSON string representation. |
| `static string ToString(System.Decimal value)` | Converts the to its JSON string representation. |
| `static string ToString(System.Guid value)` | Converts the to its JSON string representation. |
| `static string ToString(System.TimeSpan value)` | Converts the to its JSON string representation. |
| `static string ToString(System.Uri value)` | Converts the to its JSON string representation. |
| `static string ToString(string value)` | Converts the to its JSON string representation. |
| `static string ToString(string value, char delimiter)` | Converts the to its JSON string representation. |
| `static string ToString(string value, char delimiter, Newtonsoft.Json.StringEscapeHandling stringEscapeHandling)` | Converts the to its JSON string representation. |
| `static string ToString(object value)` | Converts the to its JSON string representation. |
| `static string SerializeObject(object value)` | Serializes the specified object to a JSON string. |
| `static string SerializeObject(object value, Newtonsoft.Json.Formatting formatting)` | Serializes the specified object to a JSON string using formatting. |
| `static string SerializeObject(object value, Newtonsoft.Json.JsonConverter[] converters)` | Serializes the specified object to a JSON string using a collection of . |
| `static string SerializeObject(object value, Newtonsoft.Json.Formatting formatting, Newtonsoft.Json.JsonConverter[] converters)` | Serializes the specified object to a JSON string using formatting and a collection of . |
| `static string SerializeObject(object , Newtonsoft.Json.JsonSerializerSettings value, ? settings)` | Serializes the specified object to a JSON string using . |
| `static string SerializeObject(object , System.Type value, Newtonsoft.Json.JsonSerializerSettings type, ? settings)` | Serializes the specified object to a JSON string using a type, formatting and . |
| `static string SerializeObject(object , Newtonsoft.Json.Formatting value, Newtonsoft.Json.JsonSerializerSettings formatting, ? settings)` | Serializes the specified object to a JSON string using formatting and . |
| `static string SerializeObject(object , System.Type value, Newtonsoft.Json.Formatting type, Newtonsoft.Json.JsonSerializerSettings formatting, ? settings)` | Serializes the specified object to a JSON string using a type, formatting and . |
| `static object DeserializeObject(string , ? value)` | Deserializes the JSON to a .NET object. |
| `static object DeserializeObject(string , Newtonsoft.Json.JsonSerializerSettings value, ? settings)` | Deserializes the JSON to a .NET object using . |
| `static object DeserializeObject(string , System.Type value, ? type)` | Deserializes the JSON to the specified .NET type. |
| `static T0 DeserializeObject(string value)` | Deserializes the JSON to the specified .NET type. |
| `static T0 DeserializeAnonymousType(string , T0 value, ? anonymousTypeObject)` | Deserializes the JSON to the given anonymous type. |
| `static T0 DeserializeAnonymousType(string , T0 value, Newtonsoft.Json.JsonSerializerSettings anonymousTypeObject, ? settings)` | Deserializes the JSON to the given anonymous type using . |
| `static T0 DeserializeObject(string , Newtonsoft.Json.JsonConverter[] value, ? converters)` | Deserializes the JSON to the specified .NET type using a collection of . |
| `static T0 DeserializeObject(string value, Newtonsoft.Json.JsonSerializerSettings settings)` | Deserializes the JSON to the specified .NET type using . |
| `static object DeserializeObject(string , System.Type value, Newtonsoft.Json.JsonConverter[] type, ? converters)` | Deserializes the JSON to the specified .NET type using a collection of . |
| `static object DeserializeObject(string value, System.Type type, Newtonsoft.Json.JsonSerializerSettings settings)` | Deserializes the JSON to the specified .NET type using . |
| `static void PopulateObject(string value, object target)` | Populates the object with values from the JSON string. |
| `static void PopulateObject(string value, object target, Newtonsoft.Json.JsonSerializerSettings settings)` | Populates the object with values from the JSON string using . |
| `static string SerializeXmlNode(System.Xml.XmlNode node)` | Serializes the to a JSON string. |
| `static string SerializeXmlNode(System.Xml.XmlNode node, Newtonsoft.Json.Formatting formatting)` | Serializes the to a JSON string using formatting. |
| `static string SerializeXmlNode(System.Xml.XmlNode node, Newtonsoft.Json.Formatting formatting, bool omitRootObject)` | Serializes the to a JSON string using formatting and omits the root object if is true. |
| `static System.Xml.XmlDocument DeserializeXmlNode(string , ? value)` | Deserializes the from a JSON string. |
| `static System.Xml.XmlDocument DeserializeXmlNode(string value, string deserializeRootElementName)` | Deserializes the from a JSON string nested in a root element specified by . |
| `static System.Xml.XmlDocument DeserializeXmlNode(string value, string deserializeRootElementName, bool writeArrayAttribute)` | Deserializes the from a JSON string nested in a root element specified by and writes a Json.NET array attribute for collections. |
| `static System.Xml.XmlDocument DeserializeXmlNode(string value, string deserializeRootElementName, bool writeArrayAttribute, bool encodeSpecialCharacters)` | Deserializes the from a JSON string nested in a root element specified by , writes a Json.NET array attribute for collections, and encodes special characters. |
| `static string SerializeXNode(System.Xml.Linq.XObject node)` | Serializes the to a JSON string. |
| `static string SerializeXNode(System.Xml.Linq.XObject node, Newtonsoft.Json.Formatting formatting)` | Serializes the to a JSON string using formatting. |
| `static string SerializeXNode(System.Xml.Linq.XObject node, Newtonsoft.Json.Formatting formatting, bool omitRootObject)` | Serializes the to a JSON string using formatting and omits the root object if is true. |
| `static System.Xml.Linq.XDocument DeserializeXNode(string , ? value)` | Deserializes the from a JSON string. |
| `static System.Xml.Linq.XDocument DeserializeXNode(string value, string deserializeRootElementName)` | Deserializes the from a JSON string nested in a root element specified by . |
| `static System.Xml.Linq.XDocument DeserializeXNode(string value, string deserializeRootElementName, bool writeArrayAttribute)` | Deserializes the from a JSON string nested in a root element specified by and writes a Json.NET array attribute for collections. |
| `static System.Xml.Linq.XDocument DeserializeXNode(string value, string deserializeRootElementName, bool writeArrayAttribute, bool encodeSpecialCharacters)` | Deserializes the from a JSON string nested in a root element specified by , writes a Json.NET array attribute for collections, and encodes special characters. |

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `True` | `string` | Represents JavaScript's boolean value true as a string. This field is read-only. |
| `False` | `string` | Represents JavaScript's boolean value false as a string. This field is read-only. |
| `Null` | `string` | Represents JavaScript's null as a string. This field is read-only. |
| `Undefined` | `string` | Represents JavaScript's undefined as a string. This field is read-only. |
| `PositiveInfinity` | `string` | Represents JavaScript's positive infinity as a string. This field is read-only. |
| `NegativeInfinity` | `string` | Represents JavaScript's negative infinity as a string. This field is read-only. |
| `NaN` | `string` | Represents JavaScript's NaN as a string. This field is read-only. |

---

### `abstract class JsonConverter`

Converts an object to and from JSON.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `CanRead` | `bool` | Gets a value indicating whether this can read JSON. |
| `CanWrite` | `bool` | Gets a value indicating whether this can write JSON. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `abstract void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)` | Writes the JSON representation of the object. |
| `abstract object ReadJson(Newtonsoft.Json.JsonReader , System.Type reader, object objectType, Newtonsoft.Json.JsonSerializer existingValue, ? serializer)` | Reads the JSON representation of the object. |
| `abstract bool CanConvert(System.Type objectType)` | Determines whether this instance can convert the specified object type. |
| `virtual bool get_CanRead()` |  |
| `virtual bool get_CanWrite()` |  |
| `JsonConverter()` |  |

---

### `sealed class JsonConverterAttribute : System.Attribute`

Instructs the to use the specified when serializing the member or class.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `ConverterType` | `System.Type` | Gets the of the . |
| `ConverterParameters` | `object[]` | The parameter list to use when constructing the described by . If null, the default constructor is used. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `System.Type get_ConverterType()` |  |
| `object[] get_ConverterParameters(? )` |  |
| `JsonConverterAttribute(System.Type converterType)` | Initializes a new instance of the class. |
| `JsonConverterAttribute(System.Type converterType, object[] converterParameters)` | Initializes a new instance of the class. |

---

### `class JsonConverterCollection`

Represents a collection of .

#### Methods

| Signature | Description |
|-----------|-------------|
| `JsonConverterCollection()` |  |

---

### `abstract class JsonConverter`1<T> : Newtonsoft.Json.JsonConverter`

Converts an object to and from JSON.

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)` | Writes the JSON representation of the object. |
| `abstract void WriteJson(Newtonsoft.Json.JsonWriter writer, T0 value, Newtonsoft.Json.JsonSerializer serializer)` | Writes the JSON representation of the object. |
| `virtual object ReadJson(Newtonsoft.Json.JsonReader , System.Type reader, object objectType, Newtonsoft.Json.JsonSerializer existingValue, ? serializer)` | Reads the JSON representation of the object. |
| `abstract T0 ReadJson(Newtonsoft.Json.JsonReader , System.Type reader, T0 objectType, bool existingValue, Newtonsoft.Json.JsonSerializer hasExistingValue, ? serializer)` | Reads the JSON representation of the object. |
| `virtual bool CanConvert(System.Type objectType)` | Determines whether this instance can convert the specified object type. |
| `JsonConverter`1()` |  |

---

### `sealed class JsonDictionaryAttribute : Newtonsoft.Json.JsonContainerAttribute`

Instructs the how to serialize the collection.

#### Methods

| Signature | Description |
|-----------|-------------|
| `JsonDictionaryAttribute()` | Initializes a new instance of the class. |
| `JsonDictionaryAttribute(string id)` | Initializes a new instance of the class with the specified container Id. |

---

### `class JsonException : System.Exception`

The exception thrown when an error occurs during JSON serialization or deserialization.

#### Methods

| Signature | Description |
|-----------|-------------|
| `JsonException()` | Initializes a new instance of the class. |
| `JsonException(string message)` | Initializes a new instance of the class with a specified error message. |
| `JsonException(string message, System.Exception innerException)` | Initializes a new instance of the class with a specified error message and a reference to the inner exception that is the cause of this exception. |
| `JsonException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)` | Initializes a new instance of the class. |

---

### `class JsonExtensionDataAttribute : System.Attribute`

Instructs the to deserialize properties with no matching class member into the specified collection and write values during serialization.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `WriteData` | `bool` | Gets or sets a value that indicates whether to write extension data when serializing the object. |
| `ReadData` | `bool` | Gets or sets a value that indicates whether to read extension data when deserializing the object. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `bool get_WriteData()` |  |
| `void set_WriteData(bool value)` |  |
| `bool get_ReadData()` |  |
| `void set_ReadData(bool value)` |  |
| `JsonExtensionDataAttribute()` | Initializes a new instance of the class. |

---

### `sealed class JsonIgnoreAttribute : System.Attribute`

Instructs the not to serialize the public field or public read/write property value.

#### Methods

| Signature | Description |
|-----------|-------------|
| `JsonIgnoreAttribute()` |  |

---

### `abstract class JsonNameTable`

Base class for a table of atomized string objects.

#### Methods

| Signature | Description |
|-----------|-------------|
| `abstract string Get(char[] , int key, int start, ? length)` | Gets a string containing the same characters as the specified range of characters in the given array. |
| `JsonNameTable()` |  |

---

### `sealed class JsonObjectAttribute : Newtonsoft.Json.JsonContainerAttribute`

Instructs the how to serialize the object.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `MemberSerialization` | `Newtonsoft.Json.MemberSerialization` | Gets or sets the member serialization. |
| `MissingMemberHandling` | `Newtonsoft.Json.MissingMemberHandling` | Gets or sets the missing member handling used when deserializing this object. |
| `ItemNullValueHandling` | `Newtonsoft.Json.NullValueHandling` | Gets or sets how the object's properties with null values are handled during serialization and deserialization. |
| `ItemRequired` | `Newtonsoft.Json.Required` | Gets or sets a value that indicates whether the object's properties are required. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `Newtonsoft.Json.MemberSerialization get_MemberSerialization()` |  |
| `void set_MemberSerialization(Newtonsoft.Json.MemberSerialization value)` |  |
| `Newtonsoft.Json.MissingMemberHandling get_MissingMemberHandling()` |  |
| `void set_MissingMemberHandling(Newtonsoft.Json.MissingMemberHandling value)` |  |
| `Newtonsoft.Json.NullValueHandling get_ItemNullValueHandling()` |  |
| `void set_ItemNullValueHandling(Newtonsoft.Json.NullValueHandling value)` |  |
| `Newtonsoft.Json.Required get_ItemRequired()` |  |
| `void set_ItemRequired(Newtonsoft.Json.Required value)` |  |
| `JsonObjectAttribute()` | Initializes a new instance of the class. |
| `JsonObjectAttribute(Newtonsoft.Json.MemberSerialization memberSerialization)` | Initializes a new instance of the class with the specified member serialization. |
| `JsonObjectAttribute(string id)` | Initializes a new instance of the class with the specified container Id. |

---

### `sealed class JsonPropertyAttribute : System.Attribute`

Instructs the to always serialize the member with the specified name.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `ItemConverterType` | `System.Type` | Gets or sets the type used when serializing the property's collection items. |
| `ItemConverterParameters` | `object[]` | The parameter list to use when constructing the described by . If null, the default constructor is used. When non-null, there must be a constructor defined in the that exactly matches the number, order, and type of these parameters. |
| `NamingStrategyType` | `System.Type` | Gets or sets the of the . |
| `NamingStrategyParameters` | `object[]` | The parameter list to use when constructing the described by . If null, the default constructor is used. When non-null, there must be a constructor defined in the that exactly matches the number, order, and type of these parameters. |
| `NullValueHandling` | `Newtonsoft.Json.NullValueHandling` | Gets or sets the null value handling used when serializing this property. |
| `DefaultValueHandling` | `Newtonsoft.Json.DefaultValueHandling` | Gets or sets the default value handling used when serializing this property. |
| `ReferenceLoopHandling` | `Newtonsoft.Json.ReferenceLoopHandling` | Gets or sets the reference loop handling used when serializing this property. |
| `ObjectCreationHandling` | `Newtonsoft.Json.ObjectCreationHandling` | Gets or sets the object creation handling used when deserializing this property. |
| `TypeNameHandling` | `Newtonsoft.Json.TypeNameHandling` | Gets or sets the type name handling used when serializing this property. |
| `IsReference` | `bool` | Gets or sets whether this property's value is serialized as a reference. |
| `Order` | `int` | Gets or sets the order of serialization of a member. |
| `Required` | `Newtonsoft.Json.Required` | Gets or sets a value indicating whether this property is required. |
| `PropertyName` | `string` | Gets or sets the name of the property. |
| `ItemReferenceLoopHandling` | `Newtonsoft.Json.ReferenceLoopHandling` | Gets or sets the reference loop handling used when serializing the property's collection items. |
| `ItemTypeNameHandling` | `Newtonsoft.Json.TypeNameHandling` | Gets or sets the type name handling used when serializing the property's collection items. |
| `ItemIsReference` | `bool` | Gets or sets whether this property's collection items are serialized as a reference. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `System.Type get_ItemConverterType()` |  |
| `void set_ItemConverterType(System.Type value)` |  |
| `object[] get_ItemConverterParameters(? )` |  |
| `void set_ItemConverterParameters(object[] value)` |  |
| `System.Type get_NamingStrategyType()` |  |
| `void set_NamingStrategyType(System.Type value)` |  |
| `object[] get_NamingStrategyParameters(? )` |  |
| `void set_NamingStrategyParameters(object[] value)` |  |
| `Newtonsoft.Json.NullValueHandling get_NullValueHandling()` |  |
| `void set_NullValueHandling(Newtonsoft.Json.NullValueHandling value)` |  |
| `Newtonsoft.Json.DefaultValueHandling get_DefaultValueHandling()` |  |
| `void set_DefaultValueHandling(Newtonsoft.Json.DefaultValueHandling value)` |  |
| `Newtonsoft.Json.ReferenceLoopHandling get_ReferenceLoopHandling()` |  |
| `void set_ReferenceLoopHandling(Newtonsoft.Json.ReferenceLoopHandling value)` |  |
| `Newtonsoft.Json.ObjectCreationHandling get_ObjectCreationHandling()` |  |
| `void set_ObjectCreationHandling(Newtonsoft.Json.ObjectCreationHandling value)` |  |
| `Newtonsoft.Json.TypeNameHandling get_TypeNameHandling()` |  |
| `void set_TypeNameHandling(Newtonsoft.Json.TypeNameHandling value)` |  |
| `bool get_IsReference()` |  |
| `void set_IsReference(bool value)` |  |
| `int get_Order()` |  |
| `void set_Order(int value)` |  |
| `Newtonsoft.Json.Required get_Required()` |  |
| `void set_Required(Newtonsoft.Json.Required value)` |  |
| `string get_PropertyName()` |  |
| `void set_PropertyName(string value)` |  |
| `Newtonsoft.Json.ReferenceLoopHandling get_ItemReferenceLoopHandling()` |  |
| `void set_ItemReferenceLoopHandling(Newtonsoft.Json.ReferenceLoopHandling value)` |  |
| `Newtonsoft.Json.TypeNameHandling get_ItemTypeNameHandling()` |  |
| `void set_ItemTypeNameHandling(Newtonsoft.Json.TypeNameHandling value)` |  |
| `bool get_ItemIsReference()` |  |
| `void set_ItemIsReference(bool value)` |  |
| `JsonPropertyAttribute()` | Initializes a new instance of the class. |
| `JsonPropertyAttribute(string propertyName)` | Initializes a new instance of the class with the specified name. |

---

### `abstract class JsonReader : System.IAsyncDisposable, System.IDisposable`

Represents a reader that provides fast, non-cached, forward-only access to serialized JSON data.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `CurrentState` | `State` | Gets the current reader state. |
| `CloseInput` | `bool` | Gets or sets a value indicating whether the source should be closed when this reader is closed. |
| `SupportMultipleContent` | `bool` | Gets or sets a value indicating whether multiple pieces of JSON content can be read from a continuous stream without erroring. |
| `QuoteChar` | `char` | Gets the quotation mark character used to enclose the value of a string. |
| `DateTimeZoneHandling` | `Newtonsoft.Json.DateTimeZoneHandling` | Gets or sets how time zones are handled when reading JSON. |
| `DateParseHandling` | `Newtonsoft.Json.DateParseHandling` | Gets or sets how date formatted strings, e.g. "\/Date(1198908717056)\/" and "2012-03-21T05:40Z", are parsed when reading JSON. |
| `FloatParseHandling` | `Newtonsoft.Json.FloatParseHandling` | Gets or sets how floating point numbers, e.g. 1.0 and 9.9, are parsed when reading JSON text. |
| `DateFormatString` | `string` | Gets or sets how custom date formatted strings are parsed when reading JSON. |
| `MaxDepth` | `System.Nullable<int>` | Gets or sets the maximum depth allowed when reading JSON. Reading past this depth will throw a . A null value means there is no maximum. The default value is 64. |
| `TokenType` | `Newtonsoft.Json.JsonToken` | Gets the type of the current JSON token. |
| `Value` | `object` | Gets the text value of the current JSON token. |
| `ValueType` | `System.Type` | Gets the .NET type for the current JSON token. |
| `Depth` | `int` | Gets the depth of the current token in the JSON document. |
| `Path` | `string` | Gets the path of the current JSON token. |
| `Culture` | `System.Globalization.CultureInfo` | Gets or sets the culture used when reading JSON. Defaults to . |

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual System.Threading.Tasks.Task<bool> ReadAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously reads the next JSON token from the source. |
| `System.Threading.Tasks.Task SkipAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously skips the children of the current token. |
| `virtual System.Threading.Tasks.Task<System.Nullable<bool>> ReadAsBooleanAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously reads the next JSON token from the source as a of . |
| `virtual System.Threading.Tasks.Task<byte[]> ReadAsBytesAsync(System.Threading.CancellationToken , ? cancellationToken)` | Asynchronously reads the next JSON token from the source as a []. |
| `virtual System.Threading.Tasks.Task<System.Nullable<System.DateTime>> ReadAsDateTimeAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously reads the next JSON token from the source as a of . |
| `virtual System.Threading.Tasks.Task<System.Nullable<System.DateTimeOffset>> ReadAsDateTimeOffsetAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously reads the next JSON token from the source as a of . |
| `virtual System.Threading.Tasks.Task<System.Nullable<System.Decimal>> ReadAsDecimalAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously reads the next JSON token from the source as a of . |
| `virtual System.Threading.Tasks.Task<System.Nullable<double>> ReadAsDoubleAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously reads the next JSON token from the source as a of . |
| `virtual System.Threading.Tasks.Task<System.Nullable<int>> ReadAsInt32Async(System.Threading.CancellationToken cancellationToken)` | Asynchronously reads the next JSON token from the source as a of . |
| `virtual System.Threading.Tasks.Task<string> ReadAsStringAsync(System.Threading.CancellationToken , ? cancellationToken)` | Asynchronously reads the next JSON token from the source as a . |
| `State get_CurrentState()` |  |
| `bool get_CloseInput()` |  |
| `void set_CloseInput(bool value)` |  |
| `bool get_SupportMultipleContent()` |  |
| `void set_SupportMultipleContent(bool value)` |  |
| `virtual char get_QuoteChar()` |  |
| `Newtonsoft.Json.DateTimeZoneHandling get_DateTimeZoneHandling()` |  |
| `void set_DateTimeZoneHandling(Newtonsoft.Json.DateTimeZoneHandling value)` |  |
| `Newtonsoft.Json.DateParseHandling get_DateParseHandling()` |  |
| `void set_DateParseHandling(Newtonsoft.Json.DateParseHandling value)` |  |
| `Newtonsoft.Json.FloatParseHandling get_FloatParseHandling()` |  |
| `void set_FloatParseHandling(Newtonsoft.Json.FloatParseHandling value)` |  |
| `string get_DateFormatString()` |  |
| `void set_DateFormatString(string value)` |  |
| `System.Nullable<int> get_MaxDepth()` |  |
| `void set_MaxDepth(System.Nullable<int> value)` |  |
| `virtual Newtonsoft.Json.JsonToken get_TokenType()` |  |
| `virtual object get_Value()` |  |
| `virtual System.Type get_ValueType()` |  |
| `virtual int get_Depth()` |  |
| `virtual string get_Path()` |  |
| `System.Globalization.CultureInfo get_Culture()` |  |
| `void set_Culture(System.Globalization.CultureInfo value)` |  |
| `JsonReader()` | Initializes a new instance of the class. |
| `abstract bool Read()` | Reads the next JSON token from the source. |
| `virtual System.Nullable<int> ReadAsInt32()` | Reads the next JSON token from the source as a of . |
| `virtual string ReadAsString()` | Reads the next JSON token from the source as a . |
| `virtual byte[] ReadAsBytes()` | Reads the next JSON token from the source as a []. |
| `virtual System.Nullable<double> ReadAsDouble()` | Reads the next JSON token from the source as a of . |
| `virtual System.Nullable<bool> ReadAsBoolean()` | Reads the next JSON token from the source as a of . |
| `virtual System.Nullable<System.Decimal> ReadAsDecimal()` | Reads the next JSON token from the source as a of . |
| `virtual System.Nullable<System.DateTime> ReadAsDateTime()` | Reads the next JSON token from the source as a of . |
| `virtual System.Nullable<System.DateTimeOffset> ReadAsDateTimeOffset()` | Reads the next JSON token from the source as a of . |
| `void Skip()` | Skips the children of the current token. |
| `void SetToken(Newtonsoft.Json.JsonToken newToken)` | Sets the current token. |
| `void SetToken(Newtonsoft.Json.JsonToken newToken, object value)` | Sets the current token and value. |
| `void SetToken(Newtonsoft.Json.JsonToken newToken, object value, bool updateIndex)` | Sets the current token and value. |
| `void SetStateBasedOnCurrent()` | Sets the state based on current token type. |
| `virtual void Dispose(bool disposing)` | Releases unmanaged and - optionally - managed resources. |
| `virtual void Close()` | Changes the reader's state to . If is set to true, the source is also closed. |

---

### `class JsonReaderException : Newtonsoft.Json.JsonException`

The exception thrown when an error occurs while reading JSON text.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `LineNumber` | `int` | Gets the line number indicating where the error occurred. |
| `LinePosition` | `int` | Gets the line position indicating where the error occurred. |
| `Path` | `string` | Gets the path to the JSON where the error occurred. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `int get_LineNumber()` |  |
| `int get_LinePosition()` |  |
| `string get_Path()` |  |
| `JsonReaderException()` | Initializes a new instance of the class. |
| `JsonReaderException(string message)` | Initializes a new instance of the class with a specified error message. |
| `JsonReaderException(string message, System.Exception innerException)` | Initializes a new instance of the class with a specified error message and a reference to the inner exception that is the cause of this exception. |
| `JsonReaderException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)` | Initializes a new instance of the class. |
| `JsonReaderException(string message, string path, int lineNumber, int linePosition, System.Exception innerException)` | Initializes a new instance of the class with a specified error message, JSON path, line number, line position, and a reference to the inner exception that is the cause of this exception. |

---

### `sealed class JsonRequiredAttribute : System.Attribute`

Instructs the to always serialize the member, and to require that the member has a value.

#### Methods

| Signature | Description |
|-----------|-------------|
| `JsonRequiredAttribute()` |  |

---

### `class JsonSerializationException : Newtonsoft.Json.JsonException`

The exception thrown when an error occurs during JSON serialization or deserialization.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `LineNumber` | `int` | Gets the line number indicating where the error occurred. |
| `LinePosition` | `int` | Gets the line position indicating where the error occurred. |
| `Path` | `string` | Gets the path to the JSON where the error occurred. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `int get_LineNumber()` |  |
| `int get_LinePosition()` |  |
| `string get_Path()` |  |
| `JsonSerializationException()` | Initializes a new instance of the class. |
| `JsonSerializationException(string message)` | Initializes a new instance of the class with a specified error message. |
| `JsonSerializationException(string message, System.Exception innerException)` | Initializes a new instance of the class with a specified error message and a reference to the inner exception that is the cause of this exception. |
| `JsonSerializationException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)` | Initializes a new instance of the class. |
| `JsonSerializationException(string message, string path, int lineNumber, int linePosition, System.Exception innerException)` | Initializes a new instance of the class with a specified error message, JSON path, line number, line position, and a reference to the inner exception that is the cause of this exception. |

---

### `class JsonSerializer`

Serializes and deserializes objects into and from the JSON format. The enables you to control how objects are encoded into JSON.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `ReferenceResolver` | `Newtonsoft.Json.Serialization.IReferenceResolver` | Gets or sets the used by the serializer when resolving references. |
| `Binder` | `System.Runtime.Serialization.SerializationBinder` | Gets or sets the used by the serializer when resolving type names. |
| `SerializationBinder` | `Newtonsoft.Json.Serialization.ISerializationBinder` | Gets or sets the used by the serializer when resolving type names. |
| `TraceWriter` | `Newtonsoft.Json.Serialization.ITraceWriter` | Gets or sets the used by the serializer when writing trace messages. |
| `EqualityComparer` | `System.Collections.IEqualityComparer` | Gets or sets the equality comparer used by the serializer when comparing references. |
| `TypeNameHandling` | `Newtonsoft.Json.TypeNameHandling` | Gets or sets how type name writing and reading is handled by the serializer. The default value is . |
| `TypeNameAssemblyFormat` | `System.Runtime.Serialization.Formatters.FormatterAssemblyStyle` | Gets or sets how a type name assembly is written and resolved by the serializer. The default value is . |
| `TypeNameAssemblyFormatHandling` | `Newtonsoft.Json.TypeNameAssemblyFormatHandling` | Gets or sets how a type name assembly is written and resolved by the serializer. The default value is . |
| `PreserveReferencesHandling` | `Newtonsoft.Json.PreserveReferencesHandling` | Gets or sets how object references are preserved by the serializer. The default value is . |
| `ReferenceLoopHandling` | `Newtonsoft.Json.ReferenceLoopHandling` | Gets or sets how reference loops (e.g. a class referencing itself) is handled. The default value is . |
| `MissingMemberHandling` | `Newtonsoft.Json.MissingMemberHandling` | Gets or sets how missing members (e.g. JSON contains a property that isn't a member on the object) are handled during deserialization. The default value is . |
| `NullValueHandling` | `Newtonsoft.Json.NullValueHandling` | Gets or sets how null values are handled during serialization and deserialization. The default value is . |
| `DefaultValueHandling` | `Newtonsoft.Json.DefaultValueHandling` | Gets or sets how default values are handled during serialization and deserialization. The default value is . |
| `ObjectCreationHandling` | `Newtonsoft.Json.ObjectCreationHandling` | Gets or sets how objects are created during deserialization. The default value is . |
| `ConstructorHandling` | `Newtonsoft.Json.ConstructorHandling` | Gets or sets how constructors are used during deserialization. The default value is . |
| `MetadataPropertyHandling` | `Newtonsoft.Json.MetadataPropertyHandling` | Gets or sets how metadata properties are used during deserialization. The default value is . |
| `Converters` | `Newtonsoft.Json.JsonConverterCollection` | Gets a collection that will be used during serialization. |
| `ContractResolver` | `Newtonsoft.Json.Serialization.IContractResolver` | Gets or sets the contract resolver used by the serializer when serializing .NET objects to JSON and vice versa. |
| `Context` | `System.Runtime.Serialization.StreamingContext` | Gets or sets the used by the serializer when invoking serialization callback methods. |
| `Formatting` | `Newtonsoft.Json.Formatting` | Indicates how JSON text output is formatted. The default value is . |
| `DateFormatHandling` | `Newtonsoft.Json.DateFormatHandling` | Gets or sets how dates are written to JSON text. The default value is . |
| `DateTimeZoneHandling` | `Newtonsoft.Json.DateTimeZoneHandling` | Gets or sets how time zones are handled during serialization and deserialization. The default value is . |
| `DateParseHandling` | `Newtonsoft.Json.DateParseHandling` | Gets or sets how date formatted strings, e.g. "\/Date(1198908717056)\/" and "2012-03-21T05:40Z", are parsed when reading JSON. The default value is . |
| `FloatParseHandling` | `Newtonsoft.Json.FloatParseHandling` | Gets or sets how floating point numbers, e.g. 1.0 and 9.9, are parsed when reading JSON text. The default value is . |
| `FloatFormatHandling` | `Newtonsoft.Json.FloatFormatHandling` | Gets or sets how special floating point numbers, e.g. , and , are written as JSON text. The default value is . |
| `StringEscapeHandling` | `Newtonsoft.Json.StringEscapeHandling` | Gets or sets how strings are escaped when writing JSON text. The default value is . |
| `DateFormatString` | `string` | Gets or sets how and values are formatted when writing JSON text, and the expected date format when reading JSON text. The default value is "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK". |
| `Culture` | `System.Globalization.CultureInfo` | Gets or sets the culture used when reading JSON. The default value is . |
| `MaxDepth` | `System.Nullable<int>` | Gets or sets the maximum depth allowed when reading JSON. Reading past this depth will throw a . A null value means there is no maximum. The default value is 64. |
| `CheckAdditionalContent` | `bool` | Gets a value indicating whether there will be a check for additional JSON content after deserializing an object. The default value is false. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual void add_Error(System.EventHandler<Newtonsoft.Json.Serialization.ErrorEventArgs> value)` |  |
| `virtual void remove_Error(System.EventHandler<Newtonsoft.Json.Serialization.ErrorEventArgs> value)` |  |
| `virtual Newtonsoft.Json.Serialization.IReferenceResolver get_ReferenceResolver()` |  |
| `virtual void set_ReferenceResolver(Newtonsoft.Json.Serialization.IReferenceResolver value)` |  |
| `virtual System.Runtime.Serialization.SerializationBinder get_Binder()` |  |
| `virtual void set_Binder(System.Runtime.Serialization.SerializationBinder value)` |  |
| `virtual Newtonsoft.Json.Serialization.ISerializationBinder get_SerializationBinder()` |  |
| `virtual void set_SerializationBinder(Newtonsoft.Json.Serialization.ISerializationBinder value)` |  |
| `virtual Newtonsoft.Json.Serialization.ITraceWriter get_TraceWriter()` |  |
| `virtual void set_TraceWriter(Newtonsoft.Json.Serialization.ITraceWriter value)` |  |
| `virtual System.Collections.IEqualityComparer get_EqualityComparer()` |  |
| `virtual void set_EqualityComparer(System.Collections.IEqualityComparer value)` |  |
| `virtual Newtonsoft.Json.TypeNameHandling get_TypeNameHandling()` |  |
| `virtual void set_TypeNameHandling(Newtonsoft.Json.TypeNameHandling value)` |  |
| `virtual System.Runtime.Serialization.Formatters.FormatterAssemblyStyle get_TypeNameAssemblyFormat()` |  |
| `virtual void set_TypeNameAssemblyFormat(System.Runtime.Serialization.Formatters.FormatterAssemblyStyle value)` |  |
| `virtual Newtonsoft.Json.TypeNameAssemblyFormatHandling get_TypeNameAssemblyFormatHandling()` |  |
| `virtual void set_TypeNameAssemblyFormatHandling(Newtonsoft.Json.TypeNameAssemblyFormatHandling value)` |  |
| `virtual Newtonsoft.Json.PreserveReferencesHandling get_PreserveReferencesHandling()` |  |
| `virtual void set_PreserveReferencesHandling(Newtonsoft.Json.PreserveReferencesHandling value)` |  |
| `virtual Newtonsoft.Json.ReferenceLoopHandling get_ReferenceLoopHandling()` |  |
| `virtual void set_ReferenceLoopHandling(Newtonsoft.Json.ReferenceLoopHandling value)` |  |
| `virtual Newtonsoft.Json.MissingMemberHandling get_MissingMemberHandling()` |  |
| `virtual void set_MissingMemberHandling(Newtonsoft.Json.MissingMemberHandling value)` |  |
| `virtual Newtonsoft.Json.NullValueHandling get_NullValueHandling()` |  |
| `virtual void set_NullValueHandling(Newtonsoft.Json.NullValueHandling value)` |  |
| `virtual Newtonsoft.Json.DefaultValueHandling get_DefaultValueHandling()` |  |
| `virtual void set_DefaultValueHandling(Newtonsoft.Json.DefaultValueHandling value)` |  |
| `virtual Newtonsoft.Json.ObjectCreationHandling get_ObjectCreationHandling()` |  |
| `virtual void set_ObjectCreationHandling(Newtonsoft.Json.ObjectCreationHandling value)` |  |
| `virtual Newtonsoft.Json.ConstructorHandling get_ConstructorHandling()` |  |
| `virtual void set_ConstructorHandling(Newtonsoft.Json.ConstructorHandling value)` |  |
| `virtual Newtonsoft.Json.MetadataPropertyHandling get_MetadataPropertyHandling()` |  |
| `virtual void set_MetadataPropertyHandling(Newtonsoft.Json.MetadataPropertyHandling value)` |  |
| `virtual Newtonsoft.Json.JsonConverterCollection get_Converters()` |  |
| `virtual Newtonsoft.Json.Serialization.IContractResolver get_ContractResolver()` |  |
| `virtual void set_ContractResolver(Newtonsoft.Json.Serialization.IContractResolver value)` |  |
| `virtual System.Runtime.Serialization.StreamingContext get_Context()` |  |
| `virtual void set_Context(System.Runtime.Serialization.StreamingContext value)` |  |
| `virtual Newtonsoft.Json.Formatting get_Formatting()` |  |
| `virtual void set_Formatting(Newtonsoft.Json.Formatting value)` |  |
| `virtual Newtonsoft.Json.DateFormatHandling get_DateFormatHandling()` |  |
| `virtual void set_DateFormatHandling(Newtonsoft.Json.DateFormatHandling value)` |  |
| `virtual Newtonsoft.Json.DateTimeZoneHandling get_DateTimeZoneHandling()` |  |
| `virtual void set_DateTimeZoneHandling(Newtonsoft.Json.DateTimeZoneHandling value)` |  |
| `virtual Newtonsoft.Json.DateParseHandling get_DateParseHandling()` |  |
| `virtual void set_DateParseHandling(Newtonsoft.Json.DateParseHandling value)` |  |
| `virtual Newtonsoft.Json.FloatParseHandling get_FloatParseHandling()` |  |
| `virtual void set_FloatParseHandling(Newtonsoft.Json.FloatParseHandling value)` |  |
| `virtual Newtonsoft.Json.FloatFormatHandling get_FloatFormatHandling()` |  |
| `virtual void set_FloatFormatHandling(Newtonsoft.Json.FloatFormatHandling value)` |  |
| `virtual Newtonsoft.Json.StringEscapeHandling get_StringEscapeHandling()` |  |
| `virtual void set_StringEscapeHandling(Newtonsoft.Json.StringEscapeHandling value)` |  |
| `virtual string get_DateFormatString()` |  |
| `virtual void set_DateFormatString(string value)` |  |
| `virtual System.Globalization.CultureInfo get_Culture()` |  |
| `virtual void set_Culture(System.Globalization.CultureInfo value)` |  |
| `virtual System.Nullable<int> get_MaxDepth()` |  |
| `virtual void set_MaxDepth(System.Nullable<int> value)` |  |
| `virtual bool get_CheckAdditionalContent()` |  |
| `virtual void set_CheckAdditionalContent(bool value)` |  |
| `JsonSerializer()` | Initializes a new instance of the class. |
| `static Newtonsoft.Json.JsonSerializer Create()` | Creates a new instance. The will not use default settings from . |
| `static Newtonsoft.Json.JsonSerializer Create(Newtonsoft.Json.JsonSerializerSettings settings)` | Creates a new instance using the specified . The will not use default settings from . |
| `static Newtonsoft.Json.JsonSerializer CreateDefault()` | Creates a new instance. The will use default settings from . |
| `static Newtonsoft.Json.JsonSerializer CreateDefault(Newtonsoft.Json.JsonSerializerSettings settings)` | Creates a new instance using the specified . The will use default settings from as well as the specified . |
| `void Populate(System.IO.TextReader reader, object target)` | Populates the JSON values onto the target object. |
| `void Populate(Newtonsoft.Json.JsonReader reader, object target)` | Populates the JSON values onto the target object. |
| `object Deserialize(Newtonsoft.Json.JsonReader , ? reader)` | Deserializes the JSON structure contained by the specified . |
| `object Deserialize(System.IO.TextReader , System.Type reader, ? objectType)` | Deserializes the JSON structure contained by the specified into an instance of the specified type. |
| `T0 Deserialize(Newtonsoft.Json.JsonReader reader)` | Deserializes the JSON structure contained by the specified into an instance of the specified type. |
| `object Deserialize(Newtonsoft.Json.JsonReader reader, System.Type objectType)` | Deserializes the JSON structure contained by the specified into an instance of the specified type. |
| `void Serialize(System.IO.TextWriter textWriter, object value)` | Serializes the specified and writes the JSON structure using the specified . |
| `void Serialize(Newtonsoft.Json.JsonWriter jsonWriter, object value, System.Type objectType)` | Serializes the specified and writes the JSON structure using the specified . |
| `void Serialize(System.IO.TextWriter textWriter, object value, System.Type objectType)` | Serializes the specified and writes the JSON structure using the specified . |
| `void Serialize(Newtonsoft.Json.JsonWriter jsonWriter, object value)` | Serializes the specified and writes the JSON structure using the specified . |

#### Events

| Name | Type | Description |
|------|------|-------------|
| `Error` | `?` | Occurs when the errors during serialization and deserialization. |

---

### `class JsonSerializerSettings`

Specifies the settings on a object.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `ReferenceLoopHandling` | `Newtonsoft.Json.ReferenceLoopHandling` | Gets or sets how reference loops (e.g. a class referencing itself) are handled. The default value is . |
| `MissingMemberHandling` | `Newtonsoft.Json.MissingMemberHandling` | Gets or sets how missing members (e.g. JSON contains a property that isn't a member on the object) are handled during deserialization. The default value is . |
| `ObjectCreationHandling` | `Newtonsoft.Json.ObjectCreationHandling` | Gets or sets how objects are created during deserialization. The default value is . |
| `NullValueHandling` | `Newtonsoft.Json.NullValueHandling` | Gets or sets how null values are handled during serialization and deserialization. The default value is . |
| `DefaultValueHandling` | `Newtonsoft.Json.DefaultValueHandling` | Gets or sets how default values are handled during serialization and deserialization. The default value is . |
| `Converters` | `System.Collections.Generic.IList<Newtonsoft.Json.JsonConverter>` | Gets or sets a collection that will be used during serialization. |
| `PreserveReferencesHandling` | `Newtonsoft.Json.PreserveReferencesHandling` | Gets or sets how object references are preserved by the serializer. The default value is . |
| `TypeNameHandling` | `Newtonsoft.Json.TypeNameHandling` | Gets or sets how type name writing and reading is handled by the serializer. The default value is . |
| `MetadataPropertyHandling` | `Newtonsoft.Json.MetadataPropertyHandling` | Gets or sets how metadata properties are used during deserialization. The default value is . |
| `TypeNameAssemblyFormat` | `System.Runtime.Serialization.Formatters.FormatterAssemblyStyle` | Gets or sets how a type name assembly is written and resolved by the serializer. The default value is . |
| `TypeNameAssemblyFormatHandling` | `Newtonsoft.Json.TypeNameAssemblyFormatHandling` | Gets or sets how a type name assembly is written and resolved by the serializer. The default value is . |
| `ConstructorHandling` | `Newtonsoft.Json.ConstructorHandling` | Gets or sets how constructors are used during deserialization. The default value is . |
| `ContractResolver` | `Newtonsoft.Json.Serialization.IContractResolver` | Gets or sets the contract resolver used by the serializer when serializing .NET objects to JSON and vice versa. |
| `EqualityComparer` | `System.Collections.IEqualityComparer` | Gets or sets the equality comparer used by the serializer when comparing references. |
| `ReferenceResolver` | `Newtonsoft.Json.Serialization.IReferenceResolver` | Gets or sets the used by the serializer when resolving references. |
| `ReferenceResolverProvider` | `System.Func<Newtonsoft.Json.Serialization.IReferenceResolver>` | Gets or sets a function that creates the used by the serializer when resolving references. |
| `TraceWriter` | `Newtonsoft.Json.Serialization.ITraceWriter` | Gets or sets the used by the serializer when writing trace messages. |
| `Binder` | `System.Runtime.Serialization.SerializationBinder` | Gets or sets the used by the serializer when resolving type names. |
| `SerializationBinder` | `Newtonsoft.Json.Serialization.ISerializationBinder` | Gets or sets the used by the serializer when resolving type names. |
| `Error` | `System.EventHandler<Newtonsoft.Json.Serialization.ErrorEventArgs>` | Gets or sets the error handler called during serialization and deserialization. |
| `Context` | `System.Runtime.Serialization.StreamingContext` | Gets or sets the used by the serializer when invoking serialization callback methods. |
| `DateFormatString` | `string` | Gets or sets how and values are formatted when writing JSON text, and the expected date format when reading JSON text. The default value is "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK". |
| `MaxDepth` | `System.Nullable<int>` | Gets or sets the maximum depth allowed when reading JSON. Reading past this depth will throw a . A null value means there is no maximum. The default value is 64. |
| `Formatting` | `Newtonsoft.Json.Formatting` | Indicates how JSON text output is formatted. The default value is . |
| `DateFormatHandling` | `Newtonsoft.Json.DateFormatHandling` | Gets or sets how dates are written to JSON text. The default value is . |
| `DateTimeZoneHandling` | `Newtonsoft.Json.DateTimeZoneHandling` | Gets or sets how time zones are handled during serialization and deserialization. The default value is . |
| `DateParseHandling` | `Newtonsoft.Json.DateParseHandling` | Gets or sets how date formatted strings, e.g. "\/Date(1198908717056)\/" and "2012-03-21T05:40Z", are parsed when reading JSON. The default value is . |
| `FloatFormatHandling` | `Newtonsoft.Json.FloatFormatHandling` | Gets or sets how special floating point numbers, e.g. , and , are written as JSON. The default value is . |
| `FloatParseHandling` | `Newtonsoft.Json.FloatParseHandling` | Gets or sets how floating point numbers, e.g. 1.0 and 9.9, are parsed when reading JSON text. The default value is . |
| `StringEscapeHandling` | `Newtonsoft.Json.StringEscapeHandling` | Gets or sets how strings are escaped when writing JSON text. The default value is . |
| `Culture` | `System.Globalization.CultureInfo` | Gets or sets the culture used when reading JSON. The default value is . |
| `CheckAdditionalContent` | `bool` | Gets a value indicating whether there will be a check for additional content after deserializing an object. The default value is false. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `Newtonsoft.Json.ReferenceLoopHandling get_ReferenceLoopHandling()` |  |
| `void set_ReferenceLoopHandling(Newtonsoft.Json.ReferenceLoopHandling value)` |  |
| `Newtonsoft.Json.MissingMemberHandling get_MissingMemberHandling()` |  |
| `void set_MissingMemberHandling(Newtonsoft.Json.MissingMemberHandling value)` |  |
| `Newtonsoft.Json.ObjectCreationHandling get_ObjectCreationHandling()` |  |
| `void set_ObjectCreationHandling(Newtonsoft.Json.ObjectCreationHandling value)` |  |
| `Newtonsoft.Json.NullValueHandling get_NullValueHandling()` |  |
| `void set_NullValueHandling(Newtonsoft.Json.NullValueHandling value)` |  |
| `Newtonsoft.Json.DefaultValueHandling get_DefaultValueHandling()` |  |
| `void set_DefaultValueHandling(Newtonsoft.Json.DefaultValueHandling value)` |  |
| `System.Collections.Generic.IList<Newtonsoft.Json.JsonConverter> get_Converters()` |  |
| `void set_Converters(System.Collections.Generic.IList<Newtonsoft.Json.JsonConverter> value)` |  |
| `Newtonsoft.Json.PreserveReferencesHandling get_PreserveReferencesHandling()` |  |
| `void set_PreserveReferencesHandling(Newtonsoft.Json.PreserveReferencesHandling value)` |  |
| `Newtonsoft.Json.TypeNameHandling get_TypeNameHandling()` |  |
| `void set_TypeNameHandling(Newtonsoft.Json.TypeNameHandling value)` |  |
| `Newtonsoft.Json.MetadataPropertyHandling get_MetadataPropertyHandling()` |  |
| `void set_MetadataPropertyHandling(Newtonsoft.Json.MetadataPropertyHandling value)` |  |
| `System.Runtime.Serialization.Formatters.FormatterAssemblyStyle get_TypeNameAssemblyFormat()` |  |
| `void set_TypeNameAssemblyFormat(System.Runtime.Serialization.Formatters.FormatterAssemblyStyle value)` |  |
| `Newtonsoft.Json.TypeNameAssemblyFormatHandling get_TypeNameAssemblyFormatHandling()` |  |
| `void set_TypeNameAssemblyFormatHandling(Newtonsoft.Json.TypeNameAssemblyFormatHandling value)` |  |
| `Newtonsoft.Json.ConstructorHandling get_ConstructorHandling()` |  |
| `void set_ConstructorHandling(Newtonsoft.Json.ConstructorHandling value)` |  |
| `Newtonsoft.Json.Serialization.IContractResolver get_ContractResolver()` |  |
| `void set_ContractResolver(Newtonsoft.Json.Serialization.IContractResolver value)` |  |
| `System.Collections.IEqualityComparer get_EqualityComparer()` |  |
| `void set_EqualityComparer(System.Collections.IEqualityComparer value)` |  |
| `Newtonsoft.Json.Serialization.IReferenceResolver get_ReferenceResolver()` |  |
| `void set_ReferenceResolver(Newtonsoft.Json.Serialization.IReferenceResolver value)` |  |
| `System.Func<Newtonsoft.Json.Serialization.IReferenceResolver> get_ReferenceResolverProvider()` |  |
| `void set_ReferenceResolverProvider(System.Func<Newtonsoft.Json.Serialization.IReferenceResolver> value)` |  |
| `Newtonsoft.Json.Serialization.ITraceWriter get_TraceWriter()` |  |
| `void set_TraceWriter(Newtonsoft.Json.Serialization.ITraceWriter value)` |  |
| `System.Runtime.Serialization.SerializationBinder get_Binder()` |  |
| `void set_Binder(System.Runtime.Serialization.SerializationBinder value)` |  |
| `Newtonsoft.Json.Serialization.ISerializationBinder get_SerializationBinder()` |  |
| `void set_SerializationBinder(Newtonsoft.Json.Serialization.ISerializationBinder value)` |  |
| `System.EventHandler<Newtonsoft.Json.Serialization.ErrorEventArgs> get_Error(? )` |  |
| `void set_Error(System.EventHandler<Newtonsoft.Json.Serialization.ErrorEventArgs> value)` |  |
| `System.Runtime.Serialization.StreamingContext get_Context()` |  |
| `void set_Context(System.Runtime.Serialization.StreamingContext value)` |  |
| `string get_DateFormatString()` |  |
| `void set_DateFormatString(string value)` |  |
| `System.Nullable<int> get_MaxDepth()` |  |
| `void set_MaxDepth(System.Nullable<int> value)` |  |
| `Newtonsoft.Json.Formatting get_Formatting()` |  |
| `void set_Formatting(Newtonsoft.Json.Formatting value)` |  |
| `Newtonsoft.Json.DateFormatHandling get_DateFormatHandling()` |  |
| `void set_DateFormatHandling(Newtonsoft.Json.DateFormatHandling value)` |  |
| `Newtonsoft.Json.DateTimeZoneHandling get_DateTimeZoneHandling()` |  |
| `void set_DateTimeZoneHandling(Newtonsoft.Json.DateTimeZoneHandling value)` |  |
| `Newtonsoft.Json.DateParseHandling get_DateParseHandling()` |  |
| `void set_DateParseHandling(Newtonsoft.Json.DateParseHandling value)` |  |
| `Newtonsoft.Json.FloatFormatHandling get_FloatFormatHandling()` |  |
| `void set_FloatFormatHandling(Newtonsoft.Json.FloatFormatHandling value)` |  |
| `Newtonsoft.Json.FloatParseHandling get_FloatParseHandling()` |  |
| `void set_FloatParseHandling(Newtonsoft.Json.FloatParseHandling value)` |  |
| `Newtonsoft.Json.StringEscapeHandling get_StringEscapeHandling()` |  |
| `void set_StringEscapeHandling(Newtonsoft.Json.StringEscapeHandling value)` |  |
| `System.Globalization.CultureInfo get_Culture()` |  |
| `void set_Culture(System.Globalization.CultureInfo value)` |  |
| `bool get_CheckAdditionalContent()` |  |
| `void set_CheckAdditionalContent(bool value)` |  |
| `JsonSerializerSettings()` | Initializes a new instance of the class. |
| `JsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings original)` | Initializes a new instance of the class using values copied from the passed in . |

---

### `class JsonTextReader : Newtonsoft.Json.JsonReader, Newtonsoft.Json.IJsonLineInfo`

Represents a reader that provides fast, non-cached, forward-only access to JSON text data.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `PropertyNameTable` | `Newtonsoft.Json.JsonNameTable` | Gets or sets the reader's property name table. |
| `ArrayPool` | `Newtonsoft.Json.IArrayPool<char>` | Gets or sets the reader's character buffer pool. |
| `LineNumber` | `int` | Gets the current line number. |
| `LinePosition` | `int` | Gets the current line position. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual System.Threading.Tasks.Task<bool> ReadAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously reads the next JSON token from the source. |
| `virtual System.Threading.Tasks.Task<System.Nullable<bool>> ReadAsBooleanAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously reads the next JSON token from the source as a of . |
| `virtual System.Threading.Tasks.Task<byte[]> ReadAsBytesAsync(System.Threading.CancellationToken , ? cancellationToken)` | Asynchronously reads the next JSON token from the source as a []. |
| `virtual System.Threading.Tasks.Task<System.Nullable<System.DateTime>> ReadAsDateTimeAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously reads the next JSON token from the source as a of . |
| `virtual System.Threading.Tasks.Task<System.Nullable<System.DateTimeOffset>> ReadAsDateTimeOffsetAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously reads the next JSON token from the source as a of . |
| `virtual System.Threading.Tasks.Task<System.Nullable<System.Decimal>> ReadAsDecimalAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously reads the next JSON token from the source as a of . |
| `virtual System.Threading.Tasks.Task<System.Nullable<double>> ReadAsDoubleAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously reads the next JSON token from the source as a of . |
| `virtual System.Threading.Tasks.Task<System.Nullable<int>> ReadAsInt32Async(System.Threading.CancellationToken cancellationToken)` | Asynchronously reads the next JSON token from the source as a of . |
| `virtual System.Threading.Tasks.Task<string> ReadAsStringAsync(System.Threading.CancellationToken , ? cancellationToken)` | Asynchronously reads the next JSON token from the source as a . |
| `JsonTextReader(System.IO.TextReader reader)` | Initializes a new instance of the class with the specified . |
| `Newtonsoft.Json.JsonNameTable get_PropertyNameTable()` |  |
| `void set_PropertyNameTable(Newtonsoft.Json.JsonNameTable value)` |  |
| `Newtonsoft.Json.IArrayPool<char> get_ArrayPool()` |  |
| `void set_ArrayPool(Newtonsoft.Json.IArrayPool<char> value)` |  |
| `virtual bool Read()` | Reads the next JSON token from the underlying . |
| `virtual System.Nullable<int> ReadAsInt32()` | Reads the next JSON token from the underlying as a of . |
| `virtual System.Nullable<System.DateTime> ReadAsDateTime()` | Reads the next JSON token from the underlying as a of . |
| `virtual string ReadAsString()` | Reads the next JSON token from the underlying as a . |
| `virtual byte[] ReadAsBytes()` | Reads the next JSON token from the underlying as a []. |
| `virtual System.Nullable<bool> ReadAsBoolean()` | Reads the next JSON token from the underlying as a of . |
| `virtual System.Nullable<System.DateTimeOffset> ReadAsDateTimeOffset()` | Reads the next JSON token from the underlying as a of . |
| `virtual System.Nullable<System.Decimal> ReadAsDecimal()` | Reads the next JSON token from the underlying as a of . |
| `virtual System.Nullable<double> ReadAsDouble()` | Reads the next JSON token from the underlying as a of . |
| `virtual void Close()` | Changes the reader's state to . If is set to true, the underlying is also closed. |
| `virtual bool HasLineInfo()` | Gets a value indicating whether the class can return line information. |
| `virtual int get_LineNumber()` |  |
| `virtual int get_LinePosition()` |  |

---

### `class JsonTextWriter : Newtonsoft.Json.JsonWriter`

Represents a writer that provides a fast, non-cached, forward-only way of generating JSON data.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `ArrayPool` | `Newtonsoft.Json.IArrayPool<char>` | Gets or sets the writer's character array pool. |
| `Indentation` | `int` | Gets or sets how many s to write for each level in the hierarchy when is set to . |
| `QuoteChar` | `char` | Gets or sets which character to use to quote attribute values. |
| `IndentChar` | `char` | Gets or sets which character to use for indenting when is set to . |
| `QuoteName` | `bool` | Gets or sets a value indicating whether object names will be surrounded with quotes. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual System.Threading.Tasks.Task FlushAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously flushes whatever is in the buffer to the destination and also flushes the destination. |
| `virtual System.Threading.Tasks.Task WriteValueDelimiterAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously writes the JSON value delimiter. |
| `virtual System.Threading.Tasks.Task WriteEndAsync(Newtonsoft.Json.JsonToken token, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes the specified end token. |
| `virtual System.Threading.Tasks.Task CloseAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously closes this writer. If is set to true, the destination is also closed. |
| `virtual System.Threading.Tasks.Task WriteEndAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously writes the end of the current JSON object or array. |
| `virtual System.Threading.Tasks.Task WriteIndentAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously writes indent characters. |
| `virtual System.Threading.Tasks.Task WriteIndentSpaceAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously writes an indent space. |
| `virtual System.Threading.Tasks.Task WriteRawAsync(string json, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes raw JSON without changing the writer's state. |
| `virtual System.Threading.Tasks.Task WriteNullAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a null value. |
| `virtual System.Threading.Tasks.Task WritePropertyNameAsync(string name, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes the property name of a name/value pair of a JSON object. |
| `virtual System.Threading.Tasks.Task WritePropertyNameAsync(string name, bool escape, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes the property name of a name/value pair of a JSON object. |
| `virtual System.Threading.Tasks.Task WriteStartArrayAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously writes the beginning of a JSON array. |
| `virtual System.Threading.Tasks.Task WriteStartObjectAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously writes the beginning of a JSON object. |
| `virtual System.Threading.Tasks.Task WriteStartConstructorAsync(string name, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes the start of a constructor with the given name. |
| `virtual System.Threading.Tasks.Task WriteUndefinedAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously writes an undefined value. |
| `virtual System.Threading.Tasks.Task WriteWhitespaceAsync(string ws, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes the given white space. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(bool value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a of value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<bool> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(byte value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<byte> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(byte[] value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a [] value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(char value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<char> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.DateTime value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<System.DateTime> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.DateTimeOffset value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<System.DateTimeOffset> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Decimal value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<System.Decimal> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(double value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<double> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(float value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<float> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Guid value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<System.Guid> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(int value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<int> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(long value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<long> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(object value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(sbyte value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<sbyte> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(short value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<short> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(string value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.TimeSpan value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<System.TimeSpan> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(uint value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<uint> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(ulong value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<ulong> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Uri value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(ushort value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<ushort> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteCommentAsync(string text, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a comment /*...*/ containing the specified text. |
| `virtual System.Threading.Tasks.Task WriteEndArrayAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously writes the end of an array. |
| `virtual System.Threading.Tasks.Task WriteEndConstructorAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously writes the end of a constructor. |
| `virtual System.Threading.Tasks.Task WriteEndObjectAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously writes the end of a JSON object. |
| `virtual System.Threading.Tasks.Task WriteRawValueAsync(string json, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes raw JSON where a value is expected and updates the writer's state. |
| `Newtonsoft.Json.IArrayPool<char> get_ArrayPool()` |  |
| `void set_ArrayPool(Newtonsoft.Json.IArrayPool<char> value)` |  |
| `int get_Indentation()` |  |
| `void set_Indentation(int value)` |  |
| `char get_QuoteChar()` |  |
| `void set_QuoteChar(char value)` |  |
| `char get_IndentChar()` |  |
| `void set_IndentChar(char value)` |  |
| `bool get_QuoteName()` |  |
| `void set_QuoteName(bool value)` |  |
| `JsonTextWriter(System.IO.TextWriter textWriter)` | Initializes a new instance of the class using the specified . |
| `virtual void Flush()` | Flushes whatever is in the buffer to the underlying and also flushes the underlying . |
| `virtual void Close()` | Closes this writer. If is set to true, the underlying is also closed. If is set to true, the JSON is auto-completed. |
| `virtual void WriteStartObject()` | Writes the beginning of a JSON object. |
| `virtual void WriteStartArray()` | Writes the beginning of a JSON array. |
| `virtual void WriteStartConstructor(string name)` | Writes the start of a constructor with the given name. |
| `virtual void WriteEnd(Newtonsoft.Json.JsonToken token)` | Writes the specified end token. |
| `virtual void WritePropertyName(string name)` | Writes the property name of a name/value pair on a JSON object. |
| `virtual void WritePropertyName(string name, bool escape)` | Writes the property name of a name/value pair on a JSON object. |
| `virtual void WriteIndent()` | Writes indent characters. |
| `virtual void WriteValueDelimiter()` | Writes the JSON value delimiter. |
| `virtual void WriteIndentSpace()` | Writes an indent space. |
| `virtual void WriteValue(object value)` | Writes a value. An error will raised if the value cannot be written as a single JSON token. |
| `virtual void WriteNull()` | Writes a null value. |
| `virtual void WriteUndefined()` | Writes an undefined value. |
| `virtual void WriteRaw(string json)` | Writes raw JSON. |
| `virtual void WriteValue(string value)` | Writes a value. |
| `virtual void WriteValue(int value)` | Writes a value. |
| `virtual void WriteValue(uint value)` | Writes a value. |
| `virtual void WriteValue(long value)` | Writes a value. |
| `virtual void WriteValue(ulong value)` | Writes a value. |
| `virtual void WriteValue(float value)` | Writes a value. |
| `virtual void WriteValue(System.Nullable<float> value)` |  |
| `virtual void WriteValue(double value)` | Writes a value. |
| `virtual void WriteValue(System.Nullable<double> value)` |  |
| `virtual void WriteValue(bool value)` | Writes a value. |
| `virtual void WriteValue(short value)` | Writes a value. |
| `virtual void WriteValue(ushort value)` | Writes a value. |
| `virtual void WriteValue(char value)` | Writes a value. |
| `virtual void WriteValue(byte value)` | Writes a value. |
| `virtual void WriteValue(sbyte value)` | Writes a value. |
| `virtual void WriteValue(System.Decimal value)` | Writes a value. |
| `virtual void WriteValue(System.DateTime value)` | Writes a value. |
| `virtual void WriteValue(byte[] value)` | Writes a [] value. |
| `virtual void WriteValue(System.DateTimeOffset value)` | Writes a value. |
| `virtual void WriteValue(System.Guid value)` | Writes a value. |
| `virtual void WriteValue(System.TimeSpan value)` | Writes a value. |
| `virtual void WriteValue(System.Uri value)` | Writes a value. |
| `virtual void WriteComment(string text)` | Writes a comment /*...*/ containing the specified text. |
| `virtual void WriteWhitespace(string ws)` | Writes the given white space. |

---

### `sealed enum JsonToken`

Specifies the type of JSON token.

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `value__` | `int` |  |
| `None` | `Newtonsoft.Json.JsonToken` | This is returned by the if a read method has not been called. |
| `StartObject` | `Newtonsoft.Json.JsonToken` | An object start token. |
| `StartArray` | `Newtonsoft.Json.JsonToken` | An array start token. |
| `StartConstructor` | `Newtonsoft.Json.JsonToken` | A constructor start token. |
| `PropertyName` | `Newtonsoft.Json.JsonToken` | An object property name. |
| `Comment` | `Newtonsoft.Json.JsonToken` | A comment. |
| `Raw` | `Newtonsoft.Json.JsonToken` | Raw JSON. |
| `Integer` | `Newtonsoft.Json.JsonToken` | An integer. |
| `Float` | `Newtonsoft.Json.JsonToken` | A float. |
| `String` | `Newtonsoft.Json.JsonToken` | A string. |
| `Boolean` | `Newtonsoft.Json.JsonToken` | A boolean. |
| `Null` | `Newtonsoft.Json.JsonToken` | A null token. |
| `Undefined` | `Newtonsoft.Json.JsonToken` | An undefined token. |
| `EndObject` | `Newtonsoft.Json.JsonToken` | An object end token. |
| `EndArray` | `Newtonsoft.Json.JsonToken` | An array end token. |
| `EndConstructor` | `Newtonsoft.Json.JsonToken` | A constructor end token. |
| `Date` | `Newtonsoft.Json.JsonToken` | A Date. |
| `Bytes` | `Newtonsoft.Json.JsonToken` | Byte data. |

---

### `class JsonValidatingReader : Newtonsoft.Json.JsonReader, Newtonsoft.Json.IJsonLineInfo`

Represents a reader that provides validation. JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `Value` | `object` | Gets the text value of the current JSON token. |
| `Depth` | `int` | Gets the depth of the current token in the JSON document. |
| `Path` | `string` | Gets the path of the current JSON token. |
| `QuoteChar` | `char` | Gets the quotation mark character used to enclose the value of a string. |
| `TokenType` | `Newtonsoft.Json.JsonToken` | Gets the type of the current JSON token. |
| `ValueType` | `System.Type` | Gets the .NET type for the current JSON token. |
| `Schema` | `Newtonsoft.Json.Schema.JsonSchema` | Gets or sets the schema. |
| `Reader` | `Newtonsoft.Json.JsonReader` | Gets the used to construct this . |

#### Methods

| Signature | Description |
|-----------|-------------|
| `void add_ValidationEventHandler(Newtonsoft.Json.Schema.ValidationEventHandler value)` |  |
| `void remove_ValidationEventHandler(Newtonsoft.Json.Schema.ValidationEventHandler value)` |  |
| `virtual object get_Value()` |  |
| `virtual int get_Depth()` |  |
| `virtual string get_Path()` |  |
| `virtual char get_QuoteChar()` |  |
| `virtual Newtonsoft.Json.JsonToken get_TokenType()` |  |
| `virtual System.Type get_ValueType()` |  |
| `JsonValidatingReader(Newtonsoft.Json.JsonReader reader)` | Initializes a new instance of the class that validates the content returned from the given . |
| `Newtonsoft.Json.Schema.JsonSchema get_Schema()` |  |
| `void set_Schema(Newtonsoft.Json.Schema.JsonSchema value)` |  |
| `Newtonsoft.Json.JsonReader get_Reader()` |  |
| `virtual void Close()` | Changes the reader's state to . If is set to true, the underlying is also closed. |
| `virtual System.Nullable<int> ReadAsInt32()` | Reads the next JSON token from the underlying as a of . |
| `virtual byte[] ReadAsBytes()` | Reads the next JSON token from the underlying as a []. |
| `virtual System.Nullable<System.Decimal> ReadAsDecimal()` | Reads the next JSON token from the underlying as a of . |
| `virtual System.Nullable<double> ReadAsDouble()` | Reads the next JSON token from the underlying as a of . |
| `virtual System.Nullable<bool> ReadAsBoolean()` | Reads the next JSON token from the underlying as a of . |
| `virtual string ReadAsString()` | Reads the next JSON token from the underlying as a . |
| `virtual System.Nullable<System.DateTime> ReadAsDateTime()` | Reads the next JSON token from the underlying as a of . |
| `virtual System.Nullable<System.DateTimeOffset> ReadAsDateTimeOffset()` | Reads the next JSON token from the underlying as a of . |
| `virtual bool Read()` | Reads the next JSON token from the underlying . |

#### Events

| Name | Type | Description |
|------|------|-------------|
| `ValidationEventHandler` | `Newtonsoft.Json.Schema.ValidationEventHandler` | Sets an event handler for receiving schema validation errors. |

---

### `abstract class JsonWriter : System.IAsyncDisposable, System.IDisposable`

Represents a writer that provides a fast, non-cached, forward-only way of generating JSON data.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `CloseOutput` | `bool` | Gets or sets a value indicating whether the destination should be closed when this writer is closed. |
| `AutoCompleteOnClose` | `bool` | Gets or sets a value indicating whether the JSON should be auto-completed when this writer is closed. |
| `WriteState` | `Newtonsoft.Json.WriteState` | Gets the state of the writer. |
| `Path` | `string` | Gets the path of the writer. |
| `Formatting` | `Newtonsoft.Json.Formatting` | Gets or sets a value indicating how JSON text output should be formatted. |
| `DateFormatHandling` | `Newtonsoft.Json.DateFormatHandling` | Gets or sets how dates are written to JSON text. |
| `DateTimeZoneHandling` | `Newtonsoft.Json.DateTimeZoneHandling` | Gets or sets how time zones are handled when writing JSON text. |
| `StringEscapeHandling` | `Newtonsoft.Json.StringEscapeHandling` | Gets or sets how strings are escaped when writing JSON text. |
| `FloatFormatHandling` | `Newtonsoft.Json.FloatFormatHandling` | Gets or sets how special floating point numbers, e.g. , and , are written to JSON text. |
| `DateFormatString` | `string` | Gets or sets how and values are formatted when writing JSON text. |
| `Culture` | `System.Globalization.CultureInfo` | Gets or sets the culture used when writing JSON. Defaults to . |

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual System.Threading.Tasks.Task CloseAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously closes this writer. If is set to true, the destination is also closed. |
| `virtual System.Threading.Tasks.Task FlushAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously flushes whatever is in the buffer to the destination and also flushes the destination. |
| `virtual System.Threading.Tasks.Task WriteEndAsync(Newtonsoft.Json.JsonToken token, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes the specified end token. |
| `virtual System.Threading.Tasks.Task WriteIndentAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously writes indent characters. |
| `virtual System.Threading.Tasks.Task WriteValueDelimiterAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously writes the JSON value delimiter. |
| `virtual System.Threading.Tasks.Task WriteIndentSpaceAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously writes an indent space. |
| `virtual System.Threading.Tasks.Task WriteRawAsync(string json, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes raw JSON without changing the writer's state. |
| `virtual System.Threading.Tasks.Task WriteEndAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously writes the end of the current JSON object or array. |
| `virtual System.Threading.Tasks.Task WriteEndArrayAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously writes the end of an array. |
| `virtual System.Threading.Tasks.Task WriteEndConstructorAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously writes the end of a constructor. |
| `virtual System.Threading.Tasks.Task WriteEndObjectAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously writes the end of a JSON object. |
| `virtual System.Threading.Tasks.Task WriteNullAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a null value. |
| `virtual System.Threading.Tasks.Task WritePropertyNameAsync(string name, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes the property name of a name/value pair of a JSON object. |
| `virtual System.Threading.Tasks.Task WritePropertyNameAsync(string name, bool escape, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes the property name of a name/value pair of a JSON object. |
| `virtual System.Threading.Tasks.Task WriteStartArrayAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously writes the beginning of a JSON array. |
| `virtual System.Threading.Tasks.Task WriteCommentAsync(string text, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a comment /*...*/ containing the specified text. |
| `virtual System.Threading.Tasks.Task WriteRawValueAsync(string json, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes raw JSON where a value is expected and updates the writer's state. |
| `virtual System.Threading.Tasks.Task WriteStartConstructorAsync(string name, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes the start of a constructor with the given name. |
| `virtual System.Threading.Tasks.Task WriteStartObjectAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously writes the beginning of a JSON object. |
| `System.Threading.Tasks.Task WriteTokenAsync(Newtonsoft.Json.JsonReader reader, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes the current token. |
| `System.Threading.Tasks.Task WriteTokenAsync(Newtonsoft.Json.JsonReader reader, bool writeChildren, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes the current token. |
| `System.Threading.Tasks.Task WriteTokenAsync(Newtonsoft.Json.JsonToken token, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes the token and its value. |
| `System.Threading.Tasks.Task WriteTokenAsync(Newtonsoft.Json.JsonToken token, object value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes the token and its value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(bool value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a of value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<bool> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(byte value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<byte> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(byte[] value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a [] value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(char value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<char> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.DateTime value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<System.DateTime> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.DateTimeOffset value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<System.DateTimeOffset> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Decimal value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<System.Decimal> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(double value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<double> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(float value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<float> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Guid value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<System.Guid> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(int value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<int> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(long value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<long> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(object value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(sbyte value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<sbyte> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(short value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<short> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(string value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.TimeSpan value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<System.TimeSpan> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(uint value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<uint> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(ulong value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<ulong> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Uri value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(ushort value, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes a value. |
| `virtual System.Threading.Tasks.Task WriteValueAsync(System.Nullable<ushort> value, System.Threading.CancellationToken cancellationToken)` |  |
| `virtual System.Threading.Tasks.Task WriteUndefinedAsync(System.Threading.CancellationToken cancellationToken)` | Asynchronously writes an undefined value. |
| `virtual System.Threading.Tasks.Task WriteWhitespaceAsync(string ws, System.Threading.CancellationToken cancellationToken)` | Asynchronously writes the given white space. |
| `System.Threading.Tasks.Task SetWriteStateAsync(Newtonsoft.Json.JsonToken token, object value, System.Threading.CancellationToken cancellationToken)` | Asynchronously ets the state of the . |
| `bool get_CloseOutput()` |  |
| `void set_CloseOutput(bool value)` |  |
| `bool get_AutoCompleteOnClose()` |  |
| `void set_AutoCompleteOnClose(bool value)` |  |
| `Newtonsoft.Json.WriteState get_WriteState()` |  |
| `string get_Path()` |  |
| `Newtonsoft.Json.Formatting get_Formatting()` |  |
| `void set_Formatting(Newtonsoft.Json.Formatting value)` |  |
| `Newtonsoft.Json.DateFormatHandling get_DateFormatHandling()` |  |
| `void set_DateFormatHandling(Newtonsoft.Json.DateFormatHandling value)` |  |
| `Newtonsoft.Json.DateTimeZoneHandling get_DateTimeZoneHandling()` |  |
| `void set_DateTimeZoneHandling(Newtonsoft.Json.DateTimeZoneHandling value)` |  |
| `Newtonsoft.Json.StringEscapeHandling get_StringEscapeHandling()` |  |
| `void set_StringEscapeHandling(Newtonsoft.Json.StringEscapeHandling value)` |  |
| `Newtonsoft.Json.FloatFormatHandling get_FloatFormatHandling()` |  |
| `void set_FloatFormatHandling(Newtonsoft.Json.FloatFormatHandling value)` |  |
| `string get_DateFormatString()` |  |
| `void set_DateFormatString(string value)` |  |
| `System.Globalization.CultureInfo get_Culture()` |  |
| `void set_Culture(System.Globalization.CultureInfo value)` |  |
| `JsonWriter()` | Initializes a new instance of the class. |
| `abstract void Flush()` | Flushes whatever is in the buffer to the destination and also flushes the destination. |
| `virtual void Close()` | Closes this writer. If is set to true, the destination is also closed. If is set to true, the JSON is auto-completed. |
| `virtual void WriteStartObject()` | Writes the beginning of a JSON object. |
| `virtual void WriteEndObject()` | Writes the end of a JSON object. |
| `virtual void WriteStartArray()` | Writes the beginning of a JSON array. |
| `virtual void WriteEndArray()` | Writes the end of an array. |
| `virtual void WriteStartConstructor(string name)` | Writes the start of a constructor with the given name. |
| `virtual void WriteEndConstructor()` | Writes the end constructor. |
| `virtual void WritePropertyName(string name)` | Writes the property name of a name/value pair of a JSON object. |
| `virtual void WritePropertyName(string name, bool escape)` | Writes the property name of a name/value pair of a JSON object. |
| `virtual void WriteEnd()` | Writes the end of the current JSON object or array. |
| `void WriteToken(Newtonsoft.Json.JsonReader reader)` | Writes the current token and its children. |
| `void WriteToken(Newtonsoft.Json.JsonReader reader, bool writeChildren)` | Writes the current token. |
| `void WriteToken(Newtonsoft.Json.JsonToken token, object value)` | Writes the token and its value. |
| `void WriteToken(Newtonsoft.Json.JsonToken token)` | Writes the token. |
| `virtual void WriteEnd(Newtonsoft.Json.JsonToken token)` | Writes the specified end token. |
| `virtual void WriteIndent()` | Writes indent characters. |
| `virtual void WriteValueDelimiter()` | Writes the JSON value delimiter. |
| `virtual void WriteIndentSpace()` | Writes an indent space. |
| `virtual void WriteNull()` | Writes a null value. |
| `virtual void WriteUndefined()` | Writes an undefined value. |
| `virtual void WriteRaw(string json)` | Writes raw JSON without changing the writer's state. |
| `virtual void WriteRawValue(string json)` | Writes raw JSON where a value is expected and updates the writer's state. |
| `virtual void WriteValue(string value)` | Writes a value. |
| `virtual void WriteValue(int value)` | Writes a value. |
| `virtual void WriteValue(uint value)` | Writes a value. |
| `virtual void WriteValue(long value)` | Writes a value. |
| `virtual void WriteValue(ulong value)` | Writes a value. |
| `virtual void WriteValue(float value)` | Writes a value. |
| `virtual void WriteValue(double value)` | Writes a value. |
| `virtual void WriteValue(bool value)` | Writes a value. |
| `virtual void WriteValue(short value)` | Writes a value. |
| `virtual void WriteValue(ushort value)` | Writes a value. |
| `virtual void WriteValue(char value)` | Writes a value. |
| `virtual void WriteValue(byte value)` | Writes a value. |
| `virtual void WriteValue(sbyte value)` | Writes a value. |
| `virtual void WriteValue(System.Decimal value)` | Writes a value. |
| `virtual void WriteValue(System.DateTime value)` | Writes a value. |
| `virtual void WriteValue(System.DateTimeOffset value)` | Writes a value. |
| `virtual void WriteValue(System.Guid value)` | Writes a value. |
| `virtual void WriteValue(System.TimeSpan value)` | Writes a value. |
| `virtual void WriteValue(System.Nullable<int> value)` |  |
| `virtual void WriteValue(System.Nullable<uint> value)` |  |
| `virtual void WriteValue(System.Nullable<long> value)` |  |
| `virtual void WriteValue(System.Nullable<ulong> value)` |  |
| `virtual void WriteValue(System.Nullable<float> value)` |  |
| `virtual void WriteValue(System.Nullable<double> value)` |  |
| `virtual void WriteValue(System.Nullable<bool> value)` |  |
| `virtual void WriteValue(System.Nullable<short> value)` |  |
| `virtual void WriteValue(System.Nullable<ushort> value)` |  |
| `virtual void WriteValue(System.Nullable<char> value)` |  |
| `virtual void WriteValue(System.Nullable<byte> value)` |  |
| `virtual void WriteValue(System.Nullable<sbyte> value)` |  |
| `virtual void WriteValue(System.Nullable<System.Decimal> value)` |  |
| `virtual void WriteValue(System.Nullable<System.DateTime> value)` |  |
| `virtual void WriteValue(System.Nullable<System.DateTimeOffset> value)` |  |
| `virtual void WriteValue(System.Nullable<System.Guid> value)` |  |
| `virtual void WriteValue(System.Nullable<System.TimeSpan> value)` |  |
| `virtual void WriteValue(byte[] value)` | Writes a [] value. |
| `virtual void WriteValue(System.Uri value)` | Writes a value. |
| `virtual void WriteValue(object value)` | Writes a value. An error will raised if the value cannot be written as a single JSON token. |
| `virtual void WriteComment(string text)` | Writes a comment /*...*/ containing the specified text. |
| `virtual void WriteWhitespace(string ws)` | Writes the given white space. |
| `virtual void Dispose(bool disposing)` | Releases unmanaged and - optionally - managed resources. |
| `void SetWriteState(Newtonsoft.Json.JsonToken token, object value)` | Sets the state of the . |

---

### `class JsonWriterException : Newtonsoft.Json.JsonException`

The exception thrown when an error occurs while writing JSON text.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `Path` | `string` | Gets the path to the JSON where the error occurred. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `string get_Path()` |  |
| `JsonWriterException()` | Initializes a new instance of the class. |
| `JsonWriterException(string message)` | Initializes a new instance of the class with a specified error message. |
| `JsonWriterException(string message, System.Exception innerException)` | Initializes a new instance of the class with a specified error message and a reference to the inner exception that is the cause of this exception. |
| `JsonWriterException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)` | Initializes a new instance of the class. |
| `JsonWriterException(string message, string path, System.Exception innerException)` | Initializes a new instance of the class with a specified error message, JSON path and a reference to the inner exception that is the cause of this exception. |

---

### `sealed enum MemberSerialization`

Specifies the member serialization options for the .

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `value__` | `int` |  |
| `OptOut` | `Newtonsoft.Json.MemberSerialization` | All public members are serialized by default. Members can be excluded using or . This is the default member serialization mode. |
| `OptIn` | `Newtonsoft.Json.MemberSerialization` | Only members marked with or are serialized. This member serialization mode can also be set by marking the class with . |
| `Fields` | `Newtonsoft.Json.MemberSerialization` | All public and private fields are serialized. Members can be excluded using or . This member serialization mode can also be set by marking the class with and setting IgnoreSerializableAttribute on to false. |

---

### `sealed enum MetadataPropertyHandling`

Specifies metadata property handling options for the .

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `value__` | `int` |  |
| `Default` | `Newtonsoft.Json.MetadataPropertyHandling` | Read metadata properties located at the start of a JSON object. |
| `ReadAhead` | `Newtonsoft.Json.MetadataPropertyHandling` | Read metadata properties located anywhere in a JSON object. Note that this setting will impact performance. |
| `Ignore` | `Newtonsoft.Json.MetadataPropertyHandling` | Do not try to read metadata properties. |

---

### `sealed enum MissingMemberHandling`

Specifies missing member handling options for the .

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `value__` | `int` |  |
| `Ignore` | `Newtonsoft.Json.MissingMemberHandling` | Ignore a missing member and do not attempt to deserialize it. |
| `Error` | `Newtonsoft.Json.MissingMemberHandling` | Throw a when a missing member is encountered during deserialization. |

---

### `sealed enum NullValueHandling`

Specifies null value handling options for the .

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `value__` | `int` |  |
| `Include` | `Newtonsoft.Json.NullValueHandling` | Include null values when serializing and deserializing objects. |
| `Ignore` | `Newtonsoft.Json.NullValueHandling` | Ignore null values when serializing and deserializing objects. |

---

### `sealed enum ObjectCreationHandling`

Specifies how object creation is handled by the .

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `value__` | `int` |  |
| `Auto` | `Newtonsoft.Json.ObjectCreationHandling` | Reuse existing objects, create new objects when needed. |
| `Reuse` | `Newtonsoft.Json.ObjectCreationHandling` | Only reuse existing objects. |
| `Replace` | `Newtonsoft.Json.ObjectCreationHandling` | Always create new objects. |

---

### `sealed enum PreserveReferencesHandling`

Specifies reference handling options for the . Note that references cannot be preserved when a value is set via a non-default constructor such as types that implement .

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `value__` | `int` |  |
| `None` | `Newtonsoft.Json.PreserveReferencesHandling` | Do not preserve references when serializing types. |
| `Objects` | `Newtonsoft.Json.PreserveReferencesHandling` | Preserve references when serializing into a JSON object structure. |
| `Arrays` | `Newtonsoft.Json.PreserveReferencesHandling` | Preserve references when serializing into a JSON array structure. |
| `All` | `Newtonsoft.Json.PreserveReferencesHandling` | Preserve references when serializing. |

---

### `sealed enum ReferenceLoopHandling`

Specifies reference loop handling options for the .

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `value__` | `int` |  |
| `Error` | `Newtonsoft.Json.ReferenceLoopHandling` | Throw a when a loop is encountered. |
| `Ignore` | `Newtonsoft.Json.ReferenceLoopHandling` | Ignore loop references and do not serialize. |
| `Serialize` | `Newtonsoft.Json.ReferenceLoopHandling` | Serialize loop references. |

---

### `sealed enum Required`

Indicating whether a property is required.

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `value__` | `int` |  |
| `Default` | `Newtonsoft.Json.Required` | The property is not required. The default state. |
| `AllowNull` | `Newtonsoft.Json.Required` | The property must be defined in JSON but can be a null value. |
| `Always` | `Newtonsoft.Json.Required` | The property must be defined in JSON and cannot be a null value. |
| `DisallowNull` | `Newtonsoft.Json.Required` | The property is not required but it cannot be a null value. |

---

### `sealed enum StringEscapeHandling`

Specifies how strings are escaped when writing JSON text.

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `value__` | `int` |  |
| `Default` | `Newtonsoft.Json.StringEscapeHandling` | Only control characters (e.g. newline) are escaped. |
| `EscapeNonAscii` | `Newtonsoft.Json.StringEscapeHandling` | All non-ASCII and control characters (e.g. newline) are escaped. |
| `EscapeHtml` | `Newtonsoft.Json.StringEscapeHandling` | HTML (<, >, &, ', ") and control characters (e.g. newline) are escaped. |

---

### `sealed enum TypeNameAssemblyFormatHandling`

Indicates the method that will be used during deserialization for locating and loading assemblies.

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `value__` | `int` |  |
| `Simple` | `Newtonsoft.Json.TypeNameAssemblyFormatHandling` | In simple mode, the assembly used during deserialization need not match exactly the assembly used during serialization. Specifically, the version numbers need not match as the LoadWithPartialName method of the class is used to load the assembly. |
| `Full` | `Newtonsoft.Json.TypeNameAssemblyFormatHandling` | In full mode, the assembly used during deserialization must match exactly the assembly used during serialization. The Load method of the class is used to load the assembly. |

---

### `sealed enum TypeNameHandling`

Specifies type name handling options for the .

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `value__` | `int` |  |
| `None` | `Newtonsoft.Json.TypeNameHandling` | Do not include the .NET type name when serializing types. |
| `Objects` | `Newtonsoft.Json.TypeNameHandling` | Include the .NET type name when serializing into a JSON object structure. |
| `Arrays` | `Newtonsoft.Json.TypeNameHandling` | Include the .NET type name when serializing into a JSON array structure. |
| `All` | `Newtonsoft.Json.TypeNameHandling` | Always include the .NET type name when serializing. |
| `Auto` | `Newtonsoft.Json.TypeNameHandling` | Include the .NET type name when the type of the object being serialized is not the same as its declared type. Note that this doesn't include the root serialized object by default. To include the root object's type name in JSON you must specify a root type object with or . |

---

### `sealed enum WriteState`

Specifies the state of the .

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `value__` | `int` |  |
| `Error` | `Newtonsoft.Json.WriteState` | An exception has been thrown, which has left the in an invalid state. You may call the method to put the in the Closed state. Any other method calls result in an being thrown. |
| `Closed` | `Newtonsoft.Json.WriteState` | The method has been called. |
| `Object` | `Newtonsoft.Json.WriteState` | An object is being written. |
| `Array` | `Newtonsoft.Json.WriteState` | An array is being written. |
| `Constructor` | `Newtonsoft.Json.WriteState` | A constructor is being written. |
| `Property` | `Newtonsoft.Json.WriteState` | A property is being written. |
| `Start` | `Newtonsoft.Json.WriteState` | A write method has not been called. |

---

## Newtonsoft.Json.Bson

### `class BsonObjectId`

Represents a BSON Oid (object id).

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `Value` | `byte[]` | Gets or sets the value of the Oid. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `byte[] get_Value()` |  |
| `BsonObjectId(byte[] value)` | Initializes a new instance of the class. |

---

### `class BsonReader : Newtonsoft.Json.JsonReader`

Represents a reader that provides fast, non-cached, forward-only access to serialized BSON data.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `JsonNet35BinaryCompatibility` | `bool` | Gets or sets a value indicating whether binary data reading should be compatible with incorrect Json.NET 3.5 written binary. |
| `ReadRootValueAsArray` | `bool` | Gets or sets a value indicating whether the root object will be read as a JSON array. |
| `DateTimeKindHandling` | `System.DateTimeKind` | Gets or sets the used when reading values from BSON. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `bool get_JsonNet35BinaryCompatibility()` |  |
| `void set_JsonNet35BinaryCompatibility(bool value)` |  |
| `bool get_ReadRootValueAsArray()` |  |
| `void set_ReadRootValueAsArray(bool value)` |  |
| `System.DateTimeKind get_DateTimeKindHandling()` |  |
| `void set_DateTimeKindHandling(System.DateTimeKind value)` |  |
| `BsonReader(System.IO.Stream stream)` | Initializes a new instance of the class. |
| `BsonReader(System.IO.BinaryReader reader)` | Initializes a new instance of the class. |
| `BsonReader(System.IO.Stream stream, bool readRootValueAsArray, System.DateTimeKind dateTimeKindHandling)` | Initializes a new instance of the class. |
| `BsonReader(System.IO.BinaryReader reader, bool readRootValueAsArray, System.DateTimeKind dateTimeKindHandling)` | Initializes a new instance of the class. |
| `virtual bool Read()` | Reads the next JSON token from the underlying . |
| `virtual void Close()` | Changes the reader's state to . If is set to true, the underlying is also closed. |

---

### `class BsonWriter : Newtonsoft.Json.JsonWriter`

Represents a writer that provides a fast, non-cached, forward-only way of generating BSON data.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `DateTimeKindHandling` | `System.DateTimeKind` | Gets or sets the used when writing values to BSON. When set to no conversion will occur. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `System.DateTimeKind get_DateTimeKindHandling()` |  |
| `void set_DateTimeKindHandling(System.DateTimeKind value)` |  |
| `BsonWriter(System.IO.Stream stream)` | Initializes a new instance of the class. |
| `BsonWriter(System.IO.BinaryWriter writer)` | Initializes a new instance of the class. |
| `virtual void Flush()` | Flushes whatever is in the buffer to the underlying and also flushes the underlying stream. |
| `virtual void WriteEnd(Newtonsoft.Json.JsonToken token)` | Writes the end. |
| `virtual void WriteComment(string text)` | Writes a comment /*...*/ containing the specified text. |
| `virtual void WriteStartConstructor(string name)` | Writes the start of a constructor with the given name. |
| `virtual void WriteRaw(string json)` | Writes raw JSON. |
| `virtual void WriteRawValue(string json)` | Writes raw JSON where a value is expected and updates the writer's state. |
| `virtual void WriteStartArray()` | Writes the beginning of a JSON array. |
| `virtual void WriteStartObject()` | Writes the beginning of a JSON object. |
| `virtual void WritePropertyName(string name)` | Writes the property name of a name/value pair on a JSON object. |
| `virtual void Close()` | Closes this writer. If is set to true, the underlying is also closed. If is set to true, the JSON is auto-completed. |
| `virtual void WriteValue(object value)` | Writes a value. An error will raised if the value cannot be written as a single JSON token. |
| `virtual void WriteNull()` | Writes a null value. |
| `virtual void WriteUndefined()` | Writes an undefined value. |
| `virtual void WriteValue(string value)` | Writes a value. |
| `virtual void WriteValue(int value)` | Writes a value. |
| `virtual void WriteValue(uint value)` | Writes a value. |
| `virtual void WriteValue(long value)` | Writes a value. |
| `virtual void WriteValue(ulong value)` | Writes a value. |
| `virtual void WriteValue(float value)` | Writes a value. |
| `virtual void WriteValue(double value)` | Writes a value. |
| `virtual void WriteValue(bool value)` | Writes a value. |
| `virtual void WriteValue(short value)` | Writes a value. |
| `virtual void WriteValue(ushort value)` | Writes a value. |
| `virtual void WriteValue(char value)` | Writes a value. |
| `virtual void WriteValue(byte value)` | Writes a value. |
| `virtual void WriteValue(sbyte value)` | Writes a value. |
| `virtual void WriteValue(System.Decimal value)` | Writes a value. |
| `virtual void WriteValue(System.DateTime value)` | Writes a value. |
| `virtual void WriteValue(System.DateTimeOffset value)` | Writes a value. |
| `virtual void WriteValue(byte[] value)` | Writes a [] value. |
| `virtual void WriteValue(System.Guid value)` | Writes a value. |
| `virtual void WriteValue(System.TimeSpan value)` | Writes a value. |
| `virtual void WriteValue(System.Uri value)` | Writes a value. |
| `void WriteObjectId(byte[] value)` | Writes a [] value that represents a BSON object id. |
| `void WriteRegex(string pattern, string options)` | Writes a BSON regex. |

---

## Newtonsoft.Json.Converters

### `class BinaryConverter : Newtonsoft.Json.JsonConverter`

Converts a binary value to and from a base 64 string value.

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)` | Writes the JSON representation of the object. |
| `virtual object ReadJson(Newtonsoft.Json.JsonReader , System.Type reader, object objectType, Newtonsoft.Json.JsonSerializer existingValue, ? serializer)` | Reads the JSON representation of the object. |
| `virtual bool CanConvert(System.Type objectType)` | Determines whether this instance can convert the specified object type. |
| `BinaryConverter()` |  |

---

### `class BsonObjectIdConverter : Newtonsoft.Json.JsonConverter`

Converts a to and from JSON and BSON.

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)` | Writes the JSON representation of the object. |
| `virtual object ReadJson(Newtonsoft.Json.JsonReader reader, System.Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)` | Reads the JSON representation of the object. |
| `virtual bool CanConvert(System.Type objectType)` | Determines whether this instance can convert the specified object type. |
| `BsonObjectIdConverter()` |  |

---

### `abstract class CustomCreationConverter`1<T> : Newtonsoft.Json.JsonConverter`

Creates a custom object.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `CanWrite` | `bool` | Gets a value indicating whether this can write JSON. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)` | Writes the JSON representation of the object. |
| `virtual object ReadJson(Newtonsoft.Json.JsonReader , System.Type reader, object objectType, Newtonsoft.Json.JsonSerializer existingValue, ? serializer)` | Reads the JSON representation of the object. |
| `abstract T0 Create(System.Type objectType)` | Creates an object which will then be populated by the serializer. |
| `virtual bool CanConvert(System.Type objectType)` | Determines whether this instance can convert the specified object type. |
| `virtual bool get_CanWrite()` |  |
| `CustomCreationConverter`1()` |  |

---

### `class DataSetConverter : Newtonsoft.Json.JsonConverter`

Converts a to and from JSON.

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)` | Writes the JSON representation of the object. |
| `virtual object ReadJson(Newtonsoft.Json.JsonReader , System.Type reader, object objectType, Newtonsoft.Json.JsonSerializer existingValue, ? serializer)` | Reads the JSON representation of the object. |
| `virtual bool CanConvert(System.Type valueType)` | Determines whether this instance can convert the specified value type. |
| `DataSetConverter()` |  |

---

### `class DataTableConverter : Newtonsoft.Json.JsonConverter`

Converts a to and from JSON.

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)` | Writes the JSON representation of the object. |
| `virtual object ReadJson(Newtonsoft.Json.JsonReader , System.Type reader, object objectType, Newtonsoft.Json.JsonSerializer existingValue, ? serializer)` | Reads the JSON representation of the object. |
| `virtual bool CanConvert(System.Type valueType)` | Determines whether this instance can convert the specified value type. |
| `DataTableConverter()` |  |

---

### `abstract class DateTimeConverterBase : Newtonsoft.Json.JsonConverter`

Provides a base class for converting a to and from JSON.

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual bool CanConvert(System.Type objectType)` | Determines whether this instance can convert the specified object type. |
| `DateTimeConverterBase()` |  |

---

### `class DiscriminatedUnionConverter : Newtonsoft.Json.JsonConverter`

Converts a F# discriminated union type to and from JSON.

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)` | Writes the JSON representation of the object. |
| `virtual object ReadJson(Newtonsoft.Json.JsonReader , System.Type reader, object objectType, Newtonsoft.Json.JsonSerializer existingValue, ? serializer)` | Reads the JSON representation of the object. |
| `virtual bool CanConvert(System.Type objectType)` | Determines whether this instance can convert the specified object type. |
| `DiscriminatedUnionConverter()` |  |

---

### `class EntityKeyMemberConverter : Newtonsoft.Json.JsonConverter`

Converts an Entity Framework to and from JSON.

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)` | Writes the JSON representation of the object. |
| `virtual object ReadJson(Newtonsoft.Json.JsonReader , System.Type reader, object objectType, Newtonsoft.Json.JsonSerializer existingValue, ? serializer)` | Reads the JSON representation of the object. |
| `virtual bool CanConvert(System.Type objectType)` | Determines whether this instance can convert the specified object type. |
| `EntityKeyMemberConverter()` |  |

---

### `class ExpandoObjectConverter : Newtonsoft.Json.JsonConverter`

Converts an to and from JSON.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `CanWrite` | `bool` | Gets a value indicating whether this can write JSON. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)` | Writes the JSON representation of the object. |
| `virtual object ReadJson(Newtonsoft.Json.JsonReader , System.Type reader, object objectType, Newtonsoft.Json.JsonSerializer existingValue, ? serializer)` | Reads the JSON representation of the object. |
| `virtual bool CanConvert(System.Type objectType)` | Determines whether this instance can convert the specified object type. |
| `virtual bool get_CanWrite()` |  |
| `ExpandoObjectConverter()` |  |

---

### `class IsoDateTimeConverter : Newtonsoft.Json.Converters.DateTimeConverterBase`

Converts a to and from the ISO 8601 date format (e.g. "2008-04-12T12:53Z").

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `DateTimeStyles` | `System.Globalization.DateTimeStyles` | Gets or sets the date time styles used when converting a date to and from JSON. |
| `DateTimeFormat` | `string` | Gets or sets the date time format used when converting a date to and from JSON. |
| `Culture` | `System.Globalization.CultureInfo` | Gets or sets the culture used when converting a date to and from JSON. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `System.Globalization.DateTimeStyles get_DateTimeStyles()` |  |
| `void set_DateTimeStyles(System.Globalization.DateTimeStyles value)` |  |
| `string get_DateTimeFormat()` |  |
| `void set_DateTimeFormat(string value)` |  |
| `System.Globalization.CultureInfo get_Culture()` |  |
| `void set_Culture(System.Globalization.CultureInfo value)` |  |
| `virtual void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)` | Writes the JSON representation of the object. |
| `virtual object ReadJson(Newtonsoft.Json.JsonReader , System.Type reader, object objectType, Newtonsoft.Json.JsonSerializer existingValue, ? serializer)` | Reads the JSON representation of the object. |
| `IsoDateTimeConverter()` |  |

---

### `class JavaScriptDateTimeConverter : Newtonsoft.Json.Converters.DateTimeConverterBase`

Converts a to and from a JavaScript Date constructor (e.g. new Date(52231943)).

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)` | Writes the JSON representation of the object. |
| `virtual object ReadJson(Newtonsoft.Json.JsonReader , System.Type reader, object objectType, Newtonsoft.Json.JsonSerializer existingValue, ? serializer)` | Reads the JSON representation of the object. |
| `JavaScriptDateTimeConverter()` |  |

---

### `class KeyValuePairConverter : Newtonsoft.Json.JsonConverter`

Converts a to and from JSON.

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)` | Writes the JSON representation of the object. |
| `virtual object ReadJson(Newtonsoft.Json.JsonReader , System.Type reader, object objectType, Newtonsoft.Json.JsonSerializer existingValue, ? serializer)` | Reads the JSON representation of the object. |
| `virtual bool CanConvert(System.Type objectType)` | Determines whether this instance can convert the specified object type. |
| `KeyValuePairConverter()` |  |

---

### `class RegexConverter : Newtonsoft.Json.JsonConverter`

Converts a to and from JSON and BSON.

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)` | Writes the JSON representation of the object. |
| `virtual object ReadJson(Newtonsoft.Json.JsonReader , System.Type reader, object objectType, Newtonsoft.Json.JsonSerializer existingValue, ? serializer)` | Reads the JSON representation of the object. |
| `virtual bool CanConvert(System.Type objectType)` | Determines whether this instance can convert the specified object type. |
| `RegexConverter()` |  |

---

### `class StringEnumConverter : Newtonsoft.Json.JsonConverter`

Converts an to and from its name string value.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `CamelCaseText` | `bool` | Gets or sets a value indicating whether the written enum text should be camel case. The default value is false. |
| `NamingStrategy` | `Newtonsoft.Json.Serialization.NamingStrategy` | Gets or sets the naming strategy used to resolve how enum text is written. |
| `AllowIntegerValues` | `bool` | Gets or sets a value indicating whether integer values are allowed when serializing and deserializing. The default value is true. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `bool get_CamelCaseText()` |  |
| `void set_CamelCaseText(bool value)` |  |
| `Newtonsoft.Json.Serialization.NamingStrategy get_NamingStrategy()` |  |
| `void set_NamingStrategy(Newtonsoft.Json.Serialization.NamingStrategy value)` |  |
| `bool get_AllowIntegerValues()` |  |
| `void set_AllowIntegerValues(bool value)` |  |
| `StringEnumConverter()` | Initializes a new instance of the class. |
| `StringEnumConverter(bool camelCaseText)` | Initializes a new instance of the class. |
| `StringEnumConverter(Newtonsoft.Json.Serialization.NamingStrategy namingStrategy, bool allowIntegerValues)` | Initializes a new instance of the class. |
| `StringEnumConverter(System.Type namingStrategyType)` | Initializes a new instance of the class. |
| `StringEnumConverter(System.Type namingStrategyType, object[] namingStrategyParameters)` | Initializes a new instance of the class. |
| `StringEnumConverter(System.Type namingStrategyType, object[] namingStrategyParameters, bool allowIntegerValues)` | Initializes a new instance of the class. |
| `virtual void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)` | Writes the JSON representation of the object. |
| `virtual object ReadJson(Newtonsoft.Json.JsonReader , System.Type reader, object objectType, Newtonsoft.Json.JsonSerializer existingValue, ? serializer)` | Reads the JSON representation of the object. |
| `virtual bool CanConvert(System.Type objectType)` | Determines whether this instance can convert the specified object type. |

---

### `class UnixDateTimeConverter : Newtonsoft.Json.Converters.DateTimeConverterBase`

Converts a to and from Unix epoch time

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `AllowPreEpoch` | `bool` | Gets or sets a value indicating whether the dates before Unix epoch should converted to and from JSON. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `bool get_AllowPreEpoch()` |  |
| `void set_AllowPreEpoch(bool value)` |  |
| `UnixDateTimeConverter()` | Initializes a new instance of the class. |
| `UnixDateTimeConverter(bool allowPreEpoch)` | Initializes a new instance of the class. |
| `virtual void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)` | Writes the JSON representation of the object. |
| `virtual object ReadJson(Newtonsoft.Json.JsonReader , System.Type reader, object objectType, Newtonsoft.Json.JsonSerializer existingValue, ? serializer)` | Reads the JSON representation of the object. |

---

### `class VersionConverter : Newtonsoft.Json.JsonConverter`

Converts a to and from a string (e.g. "1.2.3.4").

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)` | Writes the JSON representation of the object. |
| `virtual object ReadJson(Newtonsoft.Json.JsonReader , System.Type reader, object objectType, Newtonsoft.Json.JsonSerializer existingValue, ? serializer)` | Reads the JSON representation of the object. |
| `virtual bool CanConvert(System.Type objectType)` | Determines whether this instance can convert the specified object type. |
| `VersionConverter()` |  |

---

### `class XmlNodeConverter : Newtonsoft.Json.JsonConverter`

Converts XML to and from JSON.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `DeserializeRootElementName` | `string` | Gets or sets the name of the root element to insert when deserializing to XML if the JSON structure has produced multiple root elements. |
| `WriteArrayAttribute` | `bool` | Gets or sets a value to indicate whether to write the Json.NET array attribute. This attribute helps preserve arrays when converting the written XML back to JSON. |
| `OmitRootObject` | `bool` | Gets or sets a value indicating whether to write the root JSON object. |
| `EncodeSpecialCharacters` | `bool` | Gets or sets a value indicating whether to encode special characters when converting JSON to XML. If true, special characters like ':', '@', '?', '#' and '$' in JSON property names aren't used to specify XML namespaces, attributes or processing directives. Instead special characters are encoded and written as part of the XML element name. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `string get_DeserializeRootElementName()` |  |
| `void set_DeserializeRootElementName(string value)` |  |
| `bool get_WriteArrayAttribute()` |  |
| `void set_WriteArrayAttribute(bool value)` |  |
| `bool get_OmitRootObject()` |  |
| `void set_OmitRootObject(bool value)` |  |
| `bool get_EncodeSpecialCharacters()` |  |
| `void set_EncodeSpecialCharacters(bool value)` |  |
| `virtual void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)` | Writes the JSON representation of the object. |
| `virtual object ReadJson(Newtonsoft.Json.JsonReader , System.Type reader, object objectType, Newtonsoft.Json.JsonSerializer existingValue, ? serializer)` | Reads the JSON representation of the object. |
| `virtual bool CanConvert(System.Type valueType)` | Determines whether this instance can convert the specified value type. |
| `XmlNodeConverter()` |  |

---

## Newtonsoft.Json.Linq

### `sealed enum CommentHandling`

Specifies how JSON comments are handled when loading JSON.

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `value__` | `int` |  |
| `Ignore` | `Newtonsoft.Json.Linq.CommentHandling` | Ignore comments. |
| `Load` | `Newtonsoft.Json.Linq.CommentHandling` | Load comments as a with type . |

---

### `sealed enum DuplicatePropertyNameHandling`

Specifies how duplicate property names are handled when loading JSON.

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `value__` | `int` |  |
| `Replace` | `Newtonsoft.Json.Linq.DuplicatePropertyNameHandling` | Replace the existing value when there is a duplicate property. The value of the last property in the JSON object will be used. |
| `Ignore` | `Newtonsoft.Json.Linq.DuplicatePropertyNameHandling` | Ignore the new value when there is a duplicate property. The value of the first property in the JSON object will be used. |
| `Error` | `Newtonsoft.Json.Linq.DuplicatePropertyNameHandling` | Throw a when a duplicate property is encountered. |

---

### `static class Extensions`

Contains the LINQ to JSON extension methods.

#### Methods

| Signature | Description |
|-----------|-------------|
| `static Newtonsoft.Json.Linq.IJEnumerable<Newtonsoft.Json.Linq.JToken> Ancestors(System.Collections.Generic.IEnumerable<T0> source)` |  |
| `static Newtonsoft.Json.Linq.IJEnumerable<Newtonsoft.Json.Linq.JToken> AncestorsAndSelf(System.Collections.Generic.IEnumerable<T0> source)` |  |
| `static Newtonsoft.Json.Linq.IJEnumerable<Newtonsoft.Json.Linq.JToken> Descendants(System.Collections.Generic.IEnumerable<T0> source)` |  |
| `static Newtonsoft.Json.Linq.IJEnumerable<Newtonsoft.Json.Linq.JToken> DescendantsAndSelf(System.Collections.Generic.IEnumerable<T0> source)` |  |
| `static Newtonsoft.Json.Linq.IJEnumerable<Newtonsoft.Json.Linq.JProperty> Properties(System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JObject> source)` |  |
| `static Newtonsoft.Json.Linq.IJEnumerable<Newtonsoft.Json.Linq.JToken> Values(System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken> source, object key)` |  |
| `static Newtonsoft.Json.Linq.IJEnumerable<Newtonsoft.Json.Linq.JToken> Values(System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken> source)` |  |
| `static System.Collections.Generic.IEnumerable<T0> Values(System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken> , object source, ? key)` |  |
| `static System.Collections.Generic.IEnumerable<T0> Values(System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken> , ? source)` |  |
| `static T0 Value(System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken> value)` |  |
| `static T1 Value(System.Collections.Generic.IEnumerable<T0> , ? value)` |  |
| `static Newtonsoft.Json.Linq.IJEnumerable<Newtonsoft.Json.Linq.JToken> Children(System.Collections.Generic.IEnumerable<T0> source)` |  |
| `static System.Collections.Generic.IEnumerable<T1> Children(System.Collections.Generic.IEnumerable<T0> , ? source)` |  |
| `static Newtonsoft.Json.Linq.IJEnumerable<Newtonsoft.Json.Linq.JToken> AsJEnumerable(System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken> source)` |  |
| `static Newtonsoft.Json.Linq.IJEnumerable<T0> AsJEnumerable(System.Collections.Generic.IEnumerable<T0> source)` |  |

---

### `abstract interface IJEnumerable`1<T> : System.Collections.IEnumerable`

Represents a collection of objects.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `Item` | `Newtonsoft.Json.Linq.IJEnumerable<Newtonsoft.Json.Linq.JToken>` | Gets the of with the specified key. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `abstract Newtonsoft.Json.Linq.IJEnumerable<Newtonsoft.Json.Linq.JToken> get_Item(object key)` |  |

---

### `class JArray : Newtonsoft.Json.Linq.JContainer, System.Collections.IEnumerable`

Represents a JSON array.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `ChildrenTokens` | `System.Collections.Generic.IList<Newtonsoft.Json.Linq.JToken>` | Gets the container's children tokens. |
| `Type` | `Newtonsoft.Json.Linq.JTokenType` | Gets the node type for this . |
| `Item` | `Newtonsoft.Json.Linq.JToken` | Gets the with the specified key. |
| `Item` | `Newtonsoft.Json.Linq.JToken` | Gets or sets the at the specified index. |
| `IsReadOnly` | `bool` | Gets a value indicating whether the is read-only. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual System.Threading.Tasks.Task WriteToAsync(Newtonsoft.Json.JsonWriter writer, System.Threading.CancellationToken cancellationToken, Newtonsoft.Json.JsonConverter[] converters)` | Writes this token to a asynchronously. |
| `static System.Threading.Tasks.Task<Newtonsoft.Json.Linq.JArray> LoadAsync(Newtonsoft.Json.JsonReader reader, System.Threading.CancellationToken cancellationToken)` | Asynchronously loads a from a . |
| `static System.Threading.Tasks.Task<Newtonsoft.Json.Linq.JArray> LoadAsync(Newtonsoft.Json.JsonReader reader, Newtonsoft.Json.Linq.JsonLoadSettings settings, System.Threading.CancellationToken cancellationToken)` | Asynchronously loads a from a . |
| `virtual System.Collections.Generic.IList<Newtonsoft.Json.Linq.JToken> get_ChildrenTokens()` |  |
| `virtual Newtonsoft.Json.Linq.JTokenType get_Type()` |  |
| `JArray()` | Initializes a new instance of the class. |
| `JArray(Newtonsoft.Json.Linq.JArray other)` | Initializes a new instance of the class from another object. |
| `JArray(object[] content)` | Initializes a new instance of the class with the specified content. |
| `JArray(object content)` | Initializes a new instance of the class with the specified content. |
| `static Newtonsoft.Json.Linq.JArray Load(Newtonsoft.Json.JsonReader reader)` | Loads an from a . |
| `static Newtonsoft.Json.Linq.JArray Load(Newtonsoft.Json.JsonReader reader, Newtonsoft.Json.Linq.JsonLoadSettings settings)` | Loads an from a . |
| `static Newtonsoft.Json.Linq.JArray Parse(string json)` | Load a from a string that contains JSON. |
| `static Newtonsoft.Json.Linq.JArray Parse(string json, Newtonsoft.Json.Linq.JsonLoadSettings settings)` | Load a from a string that contains JSON. |
| `static Newtonsoft.Json.Linq.JArray FromObject(object o)` | Creates a from an object. |
| `static Newtonsoft.Json.Linq.JArray FromObject(object o, Newtonsoft.Json.JsonSerializer jsonSerializer)` | Creates a from an object. |
| `virtual void WriteTo(Newtonsoft.Json.JsonWriter writer, Newtonsoft.Json.JsonConverter[] converters)` | Writes this token to a . |
| `virtual Newtonsoft.Json.Linq.JToken get_Item(object , ? key)` |  |
| `virtual void set_Item(object key, Newtonsoft.Json.Linq.JToken value)` |  |
| `virtual Newtonsoft.Json.Linq.JToken get_Item(int index)` |  |
| `virtual void set_Item(int index, Newtonsoft.Json.Linq.JToken value)` |  |
| `virtual int IndexOf(Newtonsoft.Json.Linq.JToken item)` | Determines the index of a specific item in the . |
| `virtual void Insert(int index, Newtonsoft.Json.Linq.JToken item)` | Inserts an item to the at the specified index. |
| `virtual void RemoveAt(int index)` | Removes the item at the specified index. |
| `virtual System.Collections.Generic.IEnumerator<Newtonsoft.Json.Linq.JToken> GetEnumerator()` | Returns an enumerator that iterates through the collection. |
| `virtual void Add(Newtonsoft.Json.Linq.JToken item)` | Adds an item to the . |
| `virtual void Clear()` | Removes all items from the . |
| `virtual bool Contains(Newtonsoft.Json.Linq.JToken item)` | Determines whether the contains a specific value. |
| `virtual void CopyTo(Newtonsoft.Json.Linq.JToken[] array, int arrayIndex)` | Copies the elements of the to an array, starting at a particular array index. |
| `virtual bool get_IsReadOnly()` |  |
| `virtual bool Remove(Newtonsoft.Json.Linq.JToken item)` | Removes the first occurrence of a specific object from the . |

---

### `class JConstructor : Newtonsoft.Json.Linq.JContainer`

Represents a JSON constructor.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `ChildrenTokens` | `System.Collections.Generic.IList<Newtonsoft.Json.Linq.JToken>` | Gets the container's children tokens. |
| `Name` | `string` | Gets or sets the name of this constructor. |
| `Type` | `Newtonsoft.Json.Linq.JTokenType` | Gets the node type for this . |
| `Item` | `Newtonsoft.Json.Linq.JToken` | Gets the with the specified key. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual System.Threading.Tasks.Task WriteToAsync(Newtonsoft.Json.JsonWriter writer, System.Threading.CancellationToken cancellationToken, Newtonsoft.Json.JsonConverter[] converters)` | Writes this token to a asynchronously. |
| `static System.Threading.Tasks.Task<Newtonsoft.Json.Linq.JConstructor> LoadAsync(Newtonsoft.Json.JsonReader reader, System.Threading.CancellationToken cancellationToken)` | Asynchronously loads a from a . |
| `static System.Threading.Tasks.Task<Newtonsoft.Json.Linq.JConstructor> LoadAsync(Newtonsoft.Json.JsonReader reader, Newtonsoft.Json.Linq.JsonLoadSettings settings, System.Threading.CancellationToken cancellationToken)` | Asynchronously loads a from a . |
| `virtual System.Collections.Generic.IList<Newtonsoft.Json.Linq.JToken> get_ChildrenTokens()` |  |
| `string get_Name()` |  |
| `void set_Name(string value)` |  |
| `virtual Newtonsoft.Json.Linq.JTokenType get_Type()` |  |
| `JConstructor()` | Initializes a new instance of the class. |
| `JConstructor(Newtonsoft.Json.Linq.JConstructor other)` | Initializes a new instance of the class from another object. |
| `JConstructor(string name, object[] content)` | Initializes a new instance of the class with the specified name and content. |
| `JConstructor(string name, object content)` | Initializes a new instance of the class with the specified name and content. |
| `JConstructor(string name)` | Initializes a new instance of the class with the specified name. |
| `virtual void WriteTo(Newtonsoft.Json.JsonWriter writer, Newtonsoft.Json.JsonConverter[] converters)` | Writes this token to a . |
| `virtual Newtonsoft.Json.Linq.JToken get_Item(object , ? key)` |  |
| `virtual void set_Item(object key, Newtonsoft.Json.Linq.JToken value)` |  |
| `static Newtonsoft.Json.Linq.JConstructor Load(Newtonsoft.Json.JsonReader reader)` | Loads a from a . |
| `static Newtonsoft.Json.Linq.JConstructor Load(Newtonsoft.Json.JsonReader reader, Newtonsoft.Json.Linq.JsonLoadSettings settings)` | Loads a from a . |

---

### `abstract class JContainer : Newtonsoft.Json.Linq.JToken, System.Collections.IEnumerable, System.ComponentModel.ITypedList, System.ComponentModel.IBindingList, System.Collections.ICollection, System.Collections.IList, System.Collections.Specialized.INotifyCollectionChanged`

Represents a token that can contain other tokens.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `ChildrenTokens` | `System.Collections.Generic.IList<Newtonsoft.Json.Linq.JToken>` | Gets the container's children tokens. |
| `HasValues` | `bool` | Gets a value indicating whether this token has child tokens. |
| `First` | `Newtonsoft.Json.Linq.JToken` | Get the first child token of this token. |
| `Last` | `Newtonsoft.Json.Linq.JToken` | Get the last child token of this token. |
| `Count` | `int` | Gets the count of child JSON tokens. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual void add_ListChanged(System.ComponentModel.ListChangedEventHandler value)` |  |
| `virtual void remove_ListChanged(System.ComponentModel.ListChangedEventHandler value)` |  |
| `void add_AddingNew(System.ComponentModel.AddingNewEventHandler value)` |  |
| `void remove_AddingNew(System.ComponentModel.AddingNewEventHandler value)` |  |
| `virtual void add_CollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventHandler value)` |  |
| `virtual void remove_CollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventHandler value)` |  |
| `abstract System.Collections.Generic.IList<Newtonsoft.Json.Linq.JToken> get_ChildrenTokens()` |  |
| `virtual void OnAddingNew(System.ComponentModel.AddingNewEventArgs e)` | Raises the event. |
| `virtual void OnListChanged(System.ComponentModel.ListChangedEventArgs e)` | Raises the event. |
| `virtual void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)` | Raises the event. |
| `virtual bool get_HasValues()` |  |
| `virtual Newtonsoft.Json.Linq.JToken get_First()` |  |
| `virtual Newtonsoft.Json.Linq.JToken get_Last()` |  |
| `virtual Newtonsoft.Json.Linq.JEnumerable<Newtonsoft.Json.Linq.JToken> Children(? )` | Returns a collection of the child tokens of this token, in document order. |
| `virtual System.Collections.Generic.IEnumerable<T0> Values(? )` | Returns a collection of the child values of this token, in document order. |
| `System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken> Descendants()` | Returns a collection of the descendant tokens for this token in document order. |
| `System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken> DescendantsAndSelf()` | Returns a collection of the tokens that contain this token, and all descendant tokens of this token, in document order. |
| `virtual void Add(object content)` | Adds the specified content as children of this . |
| `void AddFirst(object content)` | Adds the specified content as the first children of this . |
| `Newtonsoft.Json.JsonWriter CreateWriter()` | Creates a that can be used to add tokens to the . |
| `void ReplaceAll(object content)` | Replaces the child nodes of this token with the specified content. |
| `void RemoveAll()` | Removes the child nodes from this token. |
| `void Merge(object content)` | Merge the specified content into this . |
| `void Merge(object content, Newtonsoft.Json.Linq.JsonMergeSettings settings)` | Merge the specified content into this using . |
| `virtual int get_Count()` |  |

#### Events

| Name | Type | Description |
|------|------|-------------|
| `ListChanged` | `System.ComponentModel.ListChangedEventHandler` | Occurs when the list changes or an item in the list changes. |
| `AddingNew` | `System.ComponentModel.AddingNewEventHandler` | Occurs before an item is added to the collection. |
| `CollectionChanged` | `System.Collections.Specialized.NotifyCollectionChangedEventHandler` | Occurs when the items list of the collection has changed, or the collection is reset. |

---

### `sealed struct JEnumerable`1<T> : System.Collections.IEnumerable`

Represents a collection of objects.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `Item` | `Newtonsoft.Json.Linq.IJEnumerable<Newtonsoft.Json.Linq.JToken>` | Gets the of with the specified key. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `JEnumerable`1(System.Collections.Generic.IEnumerable<T0> enumerable)` |  |
| `virtual System.Collections.Generic.IEnumerator<T0> GetEnumerator()` | Returns an enumerator that can be used to iterate through the collection. |
| `virtual Newtonsoft.Json.Linq.IJEnumerable<Newtonsoft.Json.Linq.JToken> get_Item(object key)` |  |
| `virtual bool Equals(Newtonsoft.Json.Linq.JEnumerable<T0> other)` |  |
| `virtual bool Equals(object obj)` | Determines whether the specified is equal to this instance. |
| `virtual int GetHashCode()` | Returns a hash code for this instance. |

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `Empty` | `Newtonsoft.Json.Linq.JEnumerable<T0>` | An empty collection of objects. |

---

### `class JObject : Newtonsoft.Json.Linq.JContainer, System.Collections.IEnumerable, System.ComponentModel.INotifyPropertyChanged, System.ComponentModel.ICustomTypeDescriptor, System.ComponentModel.INotifyPropertyChanging`

Represents a JSON object.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `ChildrenTokens` | `System.Collections.Generic.IList<Newtonsoft.Json.Linq.JToken>` | Gets the container's children tokens. |
| `Type` | `Newtonsoft.Json.Linq.JTokenType` | Gets the node type for this . |
| `Item` | `Newtonsoft.Json.Linq.JToken` | Gets the with the specified key. |
| `Item` | `Newtonsoft.Json.Linq.JToken` | Gets or sets the with the specified property name. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual System.Threading.Tasks.Task WriteToAsync(Newtonsoft.Json.JsonWriter writer, System.Threading.CancellationToken cancellationToken, Newtonsoft.Json.JsonConverter[] converters)` | Writes this token to a asynchronously. |
| `static System.Threading.Tasks.Task<Newtonsoft.Json.Linq.JObject> LoadAsync(Newtonsoft.Json.JsonReader reader, System.Threading.CancellationToken cancellationToken)` | Asynchronously loads a from a . |
| `static System.Threading.Tasks.Task<Newtonsoft.Json.Linq.JObject> LoadAsync(Newtonsoft.Json.JsonReader reader, Newtonsoft.Json.Linq.JsonLoadSettings settings, System.Threading.CancellationToken cancellationToken)` | Asynchronously loads a from a . |
| `virtual System.Collections.Generic.IList<Newtonsoft.Json.Linq.JToken> get_ChildrenTokens()` |  |
| `virtual void add_PropertyChanged(System.ComponentModel.PropertyChangedEventHandler value)` |  |
| `virtual void remove_PropertyChanged(System.ComponentModel.PropertyChangedEventHandler value)` |  |
| `virtual void add_PropertyChanging(System.ComponentModel.PropertyChangingEventHandler value)` |  |
| `virtual void remove_PropertyChanging(System.ComponentModel.PropertyChangingEventHandler value)` |  |
| `JObject()` | Initializes a new instance of the class. |
| `JObject(Newtonsoft.Json.Linq.JObject other)` | Initializes a new instance of the class from another object. |
| `JObject(object[] content)` | Initializes a new instance of the class with the specified content. |
| `JObject(object content)` | Initializes a new instance of the class with the specified content. |
| `virtual Newtonsoft.Json.Linq.JTokenType get_Type()` |  |
| `System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JProperty> Properties()` | Gets an of of this object's properties. |
| `Newtonsoft.Json.Linq.JProperty Property(string , ? name)` | Gets a with the specified name. |
| `Newtonsoft.Json.Linq.JProperty Property(string , System.StringComparison name, ? comparison)` | Gets the with the specified name. The exact name will be searched for first and if no matching property is found then the will be used to match a property. |
| `Newtonsoft.Json.Linq.JEnumerable<Newtonsoft.Json.Linq.JToken> PropertyValues(? )` | Gets a of of this object's property values. |
| `virtual Newtonsoft.Json.Linq.JToken get_Item(object , ? key)` |  |
| `virtual void set_Item(object key, Newtonsoft.Json.Linq.JToken value)` |  |
| `virtual Newtonsoft.Json.Linq.JToken get_Item(string , ? propertyName)` |  |
| `virtual void set_Item(string propertyName, Newtonsoft.Json.Linq.JToken value)` |  |
| `static Newtonsoft.Json.Linq.JObject Load(Newtonsoft.Json.JsonReader reader)` | Loads a from a . |
| `static Newtonsoft.Json.Linq.JObject Load(Newtonsoft.Json.JsonReader reader, Newtonsoft.Json.Linq.JsonLoadSettings settings)` | Loads a from a . |
| `static Newtonsoft.Json.Linq.JObject Parse(string json)` | Load a from a string that contains JSON. |
| `static Newtonsoft.Json.Linq.JObject Parse(string json, Newtonsoft.Json.Linq.JsonLoadSettings settings)` | Load a from a string that contains JSON. |
| `static Newtonsoft.Json.Linq.JObject FromObject(object o)` | Creates a from an object. |
| `static Newtonsoft.Json.Linq.JObject FromObject(object o, Newtonsoft.Json.JsonSerializer jsonSerializer)` | Creates a from an object. |
| `virtual void WriteTo(Newtonsoft.Json.JsonWriter writer, Newtonsoft.Json.JsonConverter[] converters)` | Writes this token to a . |
| `Newtonsoft.Json.Linq.JToken GetValue(string propertyName)` | Gets the with the specified property name. |
| `Newtonsoft.Json.Linq.JToken GetValue(string propertyName, System.StringComparison comparison)` | Gets the with the specified property name. The exact property name will be searched for first and if no matching property is found then the will be used to match a property. |
| `bool TryGetValue(string propertyName, System.StringComparison comparison, ref ref Newtonsoft.Json.Linq.JToken value)` | Tries to get the with the specified property name. The exact property name will be searched for first and if no matching property is found then the will be used to match a property. |
| `virtual void Add(string propertyName, Newtonsoft.Json.Linq.JToken value)` | Adds the specified property name. |
| `virtual bool ContainsKey(string propertyName)` | Determines whether the JSON object has the specified property name. |
| `virtual bool Remove(string propertyName)` | Removes the property with the specified name. |
| `virtual bool TryGetValue(string propertyName, ref ref Newtonsoft.Json.Linq.JToken value)` | Tries to get the with the specified property name. |
| `virtual System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, Newtonsoft.Json.Linq.JToken>> GetEnumerator(? )` | Returns an enumerator that can be used to iterate through the collection. |
| `virtual void OnPropertyChanged(string propertyName)` | Raises the event with the provided arguments. |
| `virtual void OnPropertyChanging(string propertyName)` | Raises the event with the provided arguments. |
| `virtual System.Dynamic.DynamicMetaObject GetMetaObject(System.Linq.Expressions.Expression parameter)` | Returns the responsible for binding operations performed on this object. |

#### Events

| Name | Type | Description |
|------|------|-------------|
| `PropertyChanged` | `System.ComponentModel.PropertyChangedEventHandler` | Occurs when a property value changes. |
| `PropertyChanging` | `System.ComponentModel.PropertyChangingEventHandler` | Occurs when a property value is changing. |

---

### `class JProperty : Newtonsoft.Json.Linq.JContainer`

Represents a JSON property.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `ChildrenTokens` | `System.Collections.Generic.IList<Newtonsoft.Json.Linq.JToken>` | Gets the container's children tokens. |
| `Name` | `string` | Gets the property name. |
| `Value` | `Newtonsoft.Json.Linq.JToken` | Gets or sets the property value. |
| `Type` | `Newtonsoft.Json.Linq.JTokenType` | Gets the node type for this . |

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual System.Threading.Tasks.Task WriteToAsync(Newtonsoft.Json.JsonWriter writer, System.Threading.CancellationToken cancellationToken, Newtonsoft.Json.JsonConverter[] converters)` | Writes this token to a asynchronously. |
| `static System.Threading.Tasks.Task<Newtonsoft.Json.Linq.JProperty> LoadAsync(Newtonsoft.Json.JsonReader reader, System.Threading.CancellationToken cancellationToken)` | Asynchronously loads a from a . |
| `static System.Threading.Tasks.Task<Newtonsoft.Json.Linq.JProperty> LoadAsync(Newtonsoft.Json.JsonReader reader, Newtonsoft.Json.Linq.JsonLoadSettings settings, System.Threading.CancellationToken cancellationToken)` | Asynchronously loads a from a . |
| `virtual System.Collections.Generic.IList<Newtonsoft.Json.Linq.JToken> get_ChildrenTokens()` |  |
| `string get_Name()` |  |
| `Newtonsoft.Json.Linq.JToken get_Value()` |  |
| `void set_Value(Newtonsoft.Json.Linq.JToken value)` |  |
| `JProperty(Newtonsoft.Json.Linq.JProperty other)` | Initializes a new instance of the class from another object. |
| `virtual Newtonsoft.Json.Linq.JTokenType get_Type()` |  |
| `JProperty(string name, object[] content)` | Initializes a new instance of the class. |
| `JProperty(string name, object content)` | Initializes a new instance of the class. |
| `virtual void WriteTo(Newtonsoft.Json.JsonWriter writer, Newtonsoft.Json.JsonConverter[] converters)` | Writes this token to a . |
| `static Newtonsoft.Json.Linq.JProperty Load(Newtonsoft.Json.JsonReader reader)` | Loads a from a . |
| `static Newtonsoft.Json.Linq.JProperty Load(Newtonsoft.Json.JsonReader reader, Newtonsoft.Json.Linq.JsonLoadSettings settings)` | Loads a from a . |

---

### `class JPropertyDescriptor : System.ComponentModel.PropertyDescriptor`

Represents a view of a .

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `ComponentType` | `System.Type` | When overridden in a derived class, gets the type of the component this property is bound to. |
| `IsReadOnly` | `bool` | When overridden in a derived class, gets a value indicating whether this property is read-only. |
| `PropertyType` | `System.Type` | When overridden in a derived class, gets the type of the property. |
| `NameHashCode` | `int` | Gets the hash code for the name of the member. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `JPropertyDescriptor(string name)` | Initializes a new instance of the class. |
| `virtual bool CanResetValue(object component)` | When overridden in a derived class, returns whether resetting an object changes its value. |
| `virtual object GetValue(object component)` | When overridden in a derived class, gets the current value of the property on a component. |
| `virtual void ResetValue(object component)` | When overridden in a derived class, resets the value for this property of the component to the default value. |
| `virtual void SetValue(object component, object value)` | When overridden in a derived class, sets the value of the component to a different value. |
| `virtual bool ShouldSerializeValue(object component)` | When overridden in a derived class, determines a value indicating whether the value of this property needs to be persisted. |
| `virtual System.Type get_ComponentType()` |  |
| `virtual bool get_IsReadOnly()` |  |
| `virtual System.Type get_PropertyType()` |  |
| `virtual int get_NameHashCode()` |  |

---

### `class JRaw : Newtonsoft.Json.Linq.JValue`

Represents a raw JSON string.

#### Methods

| Signature | Description |
|-----------|-------------|
| `static System.Threading.Tasks.Task<Newtonsoft.Json.Linq.JRaw> CreateAsync(Newtonsoft.Json.JsonReader reader, System.Threading.CancellationToken cancellationToken)` | Asynchronously creates an instance of with the content of the reader's current token. |
| `JRaw(Newtonsoft.Json.Linq.JRaw other)` | Initializes a new instance of the class from another object. |
| `JRaw(object rawJson)` | Initializes a new instance of the class. |
| `static Newtonsoft.Json.Linq.JRaw Create(Newtonsoft.Json.JsonReader reader)` | Creates an instance of with the content of the reader's current token. |

---

### `abstract class JToken : System.Collections.IEnumerable, Newtonsoft.Json.IJsonLineInfo, System.ICloneable, System.Dynamic.IDynamicMetaObjectProvider`

Represents an abstract JSON token.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `EqualityComparer` | `Newtonsoft.Json.Linq.JTokenEqualityComparer` | Gets a comparer that can compare two tokens for value equality. |
| `Parent` | `Newtonsoft.Json.Linq.JContainer` | Gets or sets the parent. |
| `Root` | `Newtonsoft.Json.Linq.JToken` | Gets the root of this . |
| `Type` | `Newtonsoft.Json.Linq.JTokenType` | Gets the node type for this . |
| `HasValues` | `bool` | Gets a value indicating whether this token has child tokens. |
| `Next` | `Newtonsoft.Json.Linq.JToken` | Gets the next sibling token of this node. |
| `Previous` | `Newtonsoft.Json.Linq.JToken` | Gets the previous sibling token of this node. |
| `Path` | `string` | Gets the path of the JSON token. |
| `Item` | `Newtonsoft.Json.Linq.JToken` | Gets the with the specified key. |
| `First` | `Newtonsoft.Json.Linq.JToken` | Get the first child token of this token. |
| `Last` | `Newtonsoft.Json.Linq.JToken` | Get the last child token of this token. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual System.Threading.Tasks.Task WriteToAsync(Newtonsoft.Json.JsonWriter writer, System.Threading.CancellationToken cancellationToken, Newtonsoft.Json.JsonConverter[] converters)` | Writes this token to a asynchronously. |
| `System.Threading.Tasks.Task WriteToAsync(Newtonsoft.Json.JsonWriter writer, Newtonsoft.Json.JsonConverter[] converters)` | Writes this token to a asynchronously. |
| `static System.Threading.Tasks.Task<Newtonsoft.Json.Linq.JToken> ReadFromAsync(Newtonsoft.Json.JsonReader reader, System.Threading.CancellationToken cancellationToken)` | Asynchronously creates a from a . |
| `static System.Threading.Tasks.Task<Newtonsoft.Json.Linq.JToken> ReadFromAsync(Newtonsoft.Json.JsonReader reader, Newtonsoft.Json.Linq.JsonLoadSettings settings, System.Threading.CancellationToken cancellationToken)` | Asynchronously creates a from a . |
| `static System.Threading.Tasks.Task<Newtonsoft.Json.Linq.JToken> LoadAsync(Newtonsoft.Json.JsonReader reader, System.Threading.CancellationToken cancellationToken)` | Asynchronously creates a from a . |
| `static System.Threading.Tasks.Task<Newtonsoft.Json.Linq.JToken> LoadAsync(Newtonsoft.Json.JsonReader reader, Newtonsoft.Json.Linq.JsonLoadSettings settings, System.Threading.CancellationToken cancellationToken)` | Asynchronously creates a from a . |
| `static Newtonsoft.Json.Linq.JTokenEqualityComparer get_EqualityComparer()` |  |
| `Newtonsoft.Json.Linq.JContainer get_Parent()` |  |
| `Newtonsoft.Json.Linq.JToken get_Root()` |  |
| `abstract Newtonsoft.Json.Linq.JTokenType get_Type()` |  |
| `abstract bool get_HasValues()` |  |
| `static bool DeepEquals(Newtonsoft.Json.Linq.JToken t1, Newtonsoft.Json.Linq.JToken t2)` | Compares the values of two tokens, including the values of all descendant tokens. |
| `Newtonsoft.Json.Linq.JToken get_Next()` |  |
| `Newtonsoft.Json.Linq.JToken get_Previous()` |  |
| `string get_Path()` |  |
| `void AddAfterSelf(object content)` | Adds the specified content immediately after this token. |
| `void AddBeforeSelf(object content)` | Adds the specified content immediately before this token. |
| `System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken> Ancestors()` | Returns a collection of the ancestor tokens of this token. |
| `System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken> AncestorsAndSelf()` | Returns a collection of tokens that contain this token, and the ancestors of this token. |
| `System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken> AfterSelf()` | Returns a collection of the sibling tokens after this token, in document order. |
| `System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken> BeforeSelf()` | Returns a collection of the sibling tokens before this token, in document order. |
| `virtual Newtonsoft.Json.Linq.JToken get_Item(object , ? key)` |  |
| `virtual void set_Item(object key, Newtonsoft.Json.Linq.JToken value)` |  |
| `virtual T0 Value(object key)` | Gets the with the specified key converted to the specified type. |
| `virtual Newtonsoft.Json.Linq.JToken get_First()` |  |
| `virtual Newtonsoft.Json.Linq.JToken get_Last()` |  |
| `virtual Newtonsoft.Json.Linq.JEnumerable<Newtonsoft.Json.Linq.JToken> Children(? )` | Returns a collection of the child tokens of this token, in document order. |
| `Newtonsoft.Json.Linq.JEnumerable<T0> Children(? )` | Returns a collection of the child tokens of this token, in document order, filtered by the specified type. |
| `virtual System.Collections.Generic.IEnumerable<T0> Values(? )` | Returns a collection of the child values of this token, in document order. |
| `void Remove()` | Removes this token from its parent. |
| `void Replace(Newtonsoft.Json.Linq.JToken value)` | Replaces this token with the specified token. |
| `abstract void WriteTo(Newtonsoft.Json.JsonWriter writer, Newtonsoft.Json.JsonConverter[] converters)` | Writes this token to a . |
| `virtual string ToString()` | Returns the indented JSON for this token. |
| `string ToString(Newtonsoft.Json.Formatting formatting, Newtonsoft.Json.JsonConverter[] converters)` | Returns the JSON for this token using the given formatting and converters. |
| `static bool op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static System.DateTimeOffset op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static System.Nullable<bool> op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static long op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static System.Nullable<System.DateTime> op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static System.Nullable<System.DateTimeOffset> op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static System.Nullable<System.Decimal> op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static System.Nullable<double> op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static System.Nullable<char> op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static int op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static short op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static ushort op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static char op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static byte op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static sbyte op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static System.Nullable<int> op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static System.Nullable<short> op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static System.Nullable<ushort> op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static System.Nullable<byte> op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static System.Nullable<sbyte> op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static System.DateTime op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static System.Nullable<long> op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static System.Nullable<float> op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static System.Decimal op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static System.Nullable<uint> op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static System.Nullable<ulong> op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static double op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static float op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static string op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static uint op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static ulong op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static byte[] op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static System.Guid op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static System.Nullable<System.Guid> op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static System.TimeSpan op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static System.Nullable<System.TimeSpan> op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static System.Uri op_Explicit(Newtonsoft.Json.Linq.JToken value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(bool value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(System.DateTimeOffset value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(byte value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(System.Nullable<byte> value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(sbyte value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(System.Nullable<sbyte> value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(System.Nullable<bool> value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(long value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(System.Nullable<System.DateTime> value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(System.Nullable<System.DateTimeOffset> value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(System.Nullable<System.Decimal> value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(System.Nullable<double> value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(short value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(ushort value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(int value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(System.Nullable<int> value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(System.DateTime value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(System.Nullable<long> value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(System.Nullable<float> value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(System.Decimal value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(System.Nullable<short> value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(System.Nullable<ushort> value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(System.Nullable<uint> value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(System.Nullable<ulong> value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(double value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(float value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(string value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(uint value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(ulong value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(byte[] value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(System.Uri value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(System.TimeSpan value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(System.Nullable<System.TimeSpan> value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(System.Guid value)` |  |
| `static Newtonsoft.Json.Linq.JToken op_Implicit(System.Nullable<System.Guid> value)` |  |
| `Newtonsoft.Json.JsonReader CreateReader()` | Creates a for this token. |
| `static Newtonsoft.Json.Linq.JToken FromObject(object o)` | Creates a from an object. |
| `static Newtonsoft.Json.Linq.JToken FromObject(object o, Newtonsoft.Json.JsonSerializer jsonSerializer)` | Creates a from an object using the specified . |
| `T0 ToObject()` | Creates an instance of the specified .NET type from the . |
| `object ToObject(System.Type , ? objectType)` | Creates an instance of the specified .NET type from the . |
| `T0 ToObject(Newtonsoft.Json.JsonSerializer jsonSerializer)` | Creates an instance of the specified .NET type from the using the specified . |
| `object ToObject(System.Type objectType, Newtonsoft.Json.JsonSerializer jsonSerializer)` | Creates an instance of the specified .NET type from the using the specified . |
| `static Newtonsoft.Json.Linq.JToken ReadFrom(Newtonsoft.Json.JsonReader reader)` | Creates a from a . |
| `static Newtonsoft.Json.Linq.JToken ReadFrom(Newtonsoft.Json.JsonReader reader, Newtonsoft.Json.Linq.JsonLoadSettings settings)` | Creates a from a . |
| `static Newtonsoft.Json.Linq.JToken Parse(string json)` | Load a from a string that contains JSON. |
| `static Newtonsoft.Json.Linq.JToken Parse(string json, Newtonsoft.Json.Linq.JsonLoadSettings settings)` | Load a from a string that contains JSON. |
| `static Newtonsoft.Json.Linq.JToken Load(Newtonsoft.Json.JsonReader reader, Newtonsoft.Json.Linq.JsonLoadSettings settings)` | Creates a from a . |
| `static Newtonsoft.Json.Linq.JToken Load(Newtonsoft.Json.JsonReader reader)` | Creates a from a . |
| `Newtonsoft.Json.Linq.JToken SelectToken(string , ? path)` | Selects a using a JSONPath expression. Selects the token that matches the object path. |
| `Newtonsoft.Json.Linq.JToken SelectToken(string , bool path, ? errorWhenNoMatch)` | Selects a using a JSONPath expression. Selects the token that matches the object path. |
| `Newtonsoft.Json.Linq.JToken SelectToken(string path, Newtonsoft.Json.Linq.JsonSelectSettings settings)` | Selects a using a JSONPath expression. Selects the token that matches the object path. |
| `System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken> SelectTokens(string path)` | Selects a collection of elements using a JSONPath expression. |
| `System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken> SelectTokens(string path, bool errorWhenNoMatch)` | Selects a collection of elements using a JSONPath expression. |
| `System.Collections.Generic.IEnumerable<Newtonsoft.Json.Linq.JToken> SelectTokens(string path, Newtonsoft.Json.Linq.JsonSelectSettings settings)` | Selects a collection of elements using a JSONPath expression. |
| `virtual System.Dynamic.DynamicMetaObject GetMetaObject(System.Linq.Expressions.Expression parameter)` | Returns the responsible for binding operations performed on this object. |
| `Newtonsoft.Json.Linq.JToken DeepClone()` | Creates a new instance of the . All child tokens are recursively cloned. |
| `Newtonsoft.Json.Linq.JToken DeepClone(Newtonsoft.Json.Linq.JsonCloneSettings settings)` | Creates a new instance of the . All child tokens are recursively cloned. |
| `void AddAnnotation(object annotation)` | Adds an object to the annotation list of this . |
| `T0 Annotation(? )` | Get the first annotation object of the specified type from this . |
| `object Annotation(System.Type , ? type)` | Gets the first annotation object of the specified type from this . |
| `System.Collections.Generic.IEnumerable<T0> Annotations()` | Gets a collection of annotations of the specified type for this . |
| `System.Collections.Generic.IEnumerable<object> Annotations(System.Type type)` | Gets a collection of annotations of the specified type for this . |
| `void RemoveAnnotations()` | Removes the annotations of the specified type from this . |
| `void RemoveAnnotations(System.Type type)` | Removes the annotations of the specified type from this . |

---

### `class JTokenEqualityComparer`

Compares tokens to determine whether they are equal.

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual bool Equals(Newtonsoft.Json.Linq.JToken x, Newtonsoft.Json.Linq.JToken y)` | Determines whether the specified objects are equal. |
| `virtual int GetHashCode(Newtonsoft.Json.Linq.JToken obj)` | Returns a hash code for the specified object. |
| `JTokenEqualityComparer()` |  |

---

### `class JTokenReader : Newtonsoft.Json.JsonReader, Newtonsoft.Json.IJsonLineInfo`

Represents a reader that provides fast, non-cached, forward-only access to serialized JSON data.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `CurrentToken` | `Newtonsoft.Json.Linq.JToken` | Gets the at the reader's current position. |
| `Path` | `string` | Gets the path of the current JSON token. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `Newtonsoft.Json.Linq.JToken get_CurrentToken()` |  |
| `JTokenReader(Newtonsoft.Json.Linq.JToken token)` | Initializes a new instance of the class. |
| `JTokenReader(Newtonsoft.Json.Linq.JToken token, string initialPath)` | Initializes a new instance of the class. |
| `virtual bool Read()` | Reads the next JSON token from the underlying . |
| `virtual string get_Path()` |  |

---

### `sealed enum JTokenType`

Specifies the type of token.

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `value__` | `int` |  |
| `None` | `Newtonsoft.Json.Linq.JTokenType` | No token type has been set. |
| `Object` | `Newtonsoft.Json.Linq.JTokenType` | A JSON object. |
| `Array` | `Newtonsoft.Json.Linq.JTokenType` | A JSON array. |
| `Constructor` | `Newtonsoft.Json.Linq.JTokenType` | A JSON constructor. |
| `Property` | `Newtonsoft.Json.Linq.JTokenType` | A JSON object property. |
| `Comment` | `Newtonsoft.Json.Linq.JTokenType` | A comment. |
| `Integer` | `Newtonsoft.Json.Linq.JTokenType` | An integer value. |
| `Float` | `Newtonsoft.Json.Linq.JTokenType` | A float value. |
| `String` | `Newtonsoft.Json.Linq.JTokenType` | A string value. |
| `Boolean` | `Newtonsoft.Json.Linq.JTokenType` | A boolean value. |
| `Null` | `Newtonsoft.Json.Linq.JTokenType` | A null value. |
| `Undefined` | `Newtonsoft.Json.Linq.JTokenType` | An undefined value. |
| `Date` | `Newtonsoft.Json.Linq.JTokenType` | A date value. |
| `Raw` | `Newtonsoft.Json.Linq.JTokenType` | A raw JSON value. |
| `Bytes` | `Newtonsoft.Json.Linq.JTokenType` | A collection of bytes value. |
| `Guid` | `Newtonsoft.Json.Linq.JTokenType` | A Guid value. |
| `Uri` | `Newtonsoft.Json.Linq.JTokenType` | A Uri value. |
| `TimeSpan` | `Newtonsoft.Json.Linq.JTokenType` | A TimeSpan value. |

---

### `class JTokenWriter : Newtonsoft.Json.JsonWriter`

Represents a writer that provides a fast, non-cached, forward-only way of generating JSON data.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `CurrentToken` | `Newtonsoft.Json.Linq.JToken` | Gets the at the writer's current position. |
| `Token` | `Newtonsoft.Json.Linq.JToken` | Gets the token being written. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `Newtonsoft.Json.Linq.JToken get_CurrentToken()` |  |
| `Newtonsoft.Json.Linq.JToken get_Token()` |  |
| `JTokenWriter(Newtonsoft.Json.Linq.JContainer container)` | Initializes a new instance of the class writing to the given . |
| `JTokenWriter()` | Initializes a new instance of the class. |
| `virtual void Flush()` | Flushes whatever is in the buffer to the underlying . |
| `virtual void Close()` | Closes this writer. If is set to true, the JSON is auto-completed. |
| `virtual void WriteStartObject()` | Writes the beginning of a JSON object. |
| `virtual void WriteStartArray()` | Writes the beginning of a JSON array. |
| `virtual void WriteStartConstructor(string name)` | Writes the start of a constructor with the given name. |
| `virtual void WriteEnd(Newtonsoft.Json.JsonToken token)` | Writes the end. |
| `virtual void WritePropertyName(string name)` | Writes the property name of a name/value pair on a JSON object. |
| `virtual void WriteValue(object value)` | Writes a value. An error will be raised if the value cannot be written as a single JSON token. |
| `virtual void WriteNull()` | Writes a null value. |
| `virtual void WriteUndefined()` | Writes an undefined value. |
| `virtual void WriteRaw(string json)` | Writes raw JSON. |
| `virtual void WriteComment(string text)` | Writes a comment /*...*/ containing the specified text. |
| `virtual void WriteValue(string value)` | Writes a value. |
| `virtual void WriteValue(int value)` | Writes a value. |
| `virtual void WriteValue(uint value)` | Writes a value. |
| `virtual void WriteValue(long value)` | Writes a value. |
| `virtual void WriteValue(ulong value)` | Writes a value. |
| `virtual void WriteValue(float value)` | Writes a value. |
| `virtual void WriteValue(double value)` | Writes a value. |
| `virtual void WriteValue(bool value)` | Writes a value. |
| `virtual void WriteValue(short value)` | Writes a value. |
| `virtual void WriteValue(ushort value)` | Writes a value. |
| `virtual void WriteValue(char value)` | Writes a value. |
| `virtual void WriteValue(byte value)` | Writes a value. |
| `virtual void WriteValue(sbyte value)` | Writes a value. |
| `virtual void WriteValue(System.Decimal value)` | Writes a value. |
| `virtual void WriteValue(System.DateTime value)` | Writes a value. |
| `virtual void WriteValue(System.DateTimeOffset value)` | Writes a value. |
| `virtual void WriteValue(byte[] value)` | Writes a [] value. |
| `virtual void WriteValue(System.TimeSpan value)` | Writes a value. |
| `virtual void WriteValue(System.Guid value)` | Writes a value. |
| `virtual void WriteValue(System.Uri value)` | Writes a value. |

---

### `class JValue : Newtonsoft.Json.Linq.JToken, System.IFormattable, System.IComparable, System.IConvertible`

Represents a value in JSON (string, integer, date, etc).

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `HasValues` | `bool` | Gets a value indicating whether this token has child tokens. |
| `Type` | `Newtonsoft.Json.Linq.JTokenType` | Gets the node type for this . |
| `Value` | `object` | Gets or sets the underlying token value. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual System.Threading.Tasks.Task WriteToAsync(Newtonsoft.Json.JsonWriter writer, System.Threading.CancellationToken cancellationToken, Newtonsoft.Json.JsonConverter[] converters)` | Writes this token to a asynchronously. |
| `JValue(Newtonsoft.Json.Linq.JValue other)` | Initializes a new instance of the class from another object. |
| `JValue(long value)` | Initializes a new instance of the class with the given value. |
| `JValue(System.Decimal value)` | Initializes a new instance of the class with the given value. |
| `JValue(char value)` | Initializes a new instance of the class with the given value. |
| `JValue(ulong value)` | Initializes a new instance of the class with the given value. |
| `JValue(double value)` | Initializes a new instance of the class with the given value. |
| `JValue(float value)` | Initializes a new instance of the class with the given value. |
| `JValue(System.DateTime value)` | Initializes a new instance of the class with the given value. |
| `JValue(System.DateTimeOffset value)` | Initializes a new instance of the class with the given value. |
| `JValue(bool value)` | Initializes a new instance of the class with the given value. |
| `JValue(string value)` | Initializes a new instance of the class with the given value. |
| `JValue(System.Guid value)` | Initializes a new instance of the class with the given value. |
| `JValue(System.Uri value)` | Initializes a new instance of the class with the given value. |
| `JValue(System.TimeSpan value)` | Initializes a new instance of the class with the given value. |
| `JValue(object value)` | Initializes a new instance of the class with the given value. |
| `virtual bool get_HasValues()` |  |
| `static Newtonsoft.Json.Linq.JValue CreateComment(string value)` | Creates a comment with the given value. |
| `static Newtonsoft.Json.Linq.JValue CreateString(string value)` | Creates a string with the given value. |
| `static Newtonsoft.Json.Linq.JValue CreateNull()` | Creates a null value. |
| `static Newtonsoft.Json.Linq.JValue CreateUndefined()` | Creates a undefined value. |
| `virtual Newtonsoft.Json.Linq.JTokenType get_Type()` |  |
| `object get_Value()` |  |
| `void set_Value(object value)` |  |
| `virtual void WriteTo(Newtonsoft.Json.JsonWriter writer, Newtonsoft.Json.JsonConverter[] converters)` | Writes this token to a . |
| `virtual bool Equals(Newtonsoft.Json.Linq.JValue other)` | Indicates whether the current object is equal to another object of the same type. |
| `virtual bool Equals(object obj)` | Determines whether the specified is equal to the current . |
| `virtual int GetHashCode()` | Serves as a hash function for a particular type. |
| `virtual string ToString()` | Returns a that represents this instance. |
| `string ToString(string format)` | Returns a that represents this instance. |
| `virtual string ToString(System.IFormatProvider formatProvider)` | Returns a that represents this instance. |
| `virtual string ToString(string , System.IFormatProvider format, ? formatProvider)` | Returns a that represents this instance. |
| `virtual System.Dynamic.DynamicMetaObject GetMetaObject(System.Linq.Expressions.Expression parameter)` | Returns the responsible for binding operations performed on this object. |
| `virtual int CompareTo(Newtonsoft.Json.Linq.JValue obj)` | Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object. |

---

### `class JsonCloneSettings`

Specifies the settings used when cloning JSON.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `CopyAnnotations` | `bool` | Gets or sets a flag that indicates whether to copy annotations when cloning a . The default value is true. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `JsonCloneSettings()` | Initializes a new instance of the class. |
| `bool get_CopyAnnotations()` |  |
| `void set_CopyAnnotations(bool value)` |  |

---

### `class JsonLoadSettings`

Specifies the settings used when loading JSON.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `CommentHandling` | `Newtonsoft.Json.Linq.CommentHandling` | Gets or sets how JSON comments are handled when loading JSON. The default value is . |
| `LineInfoHandling` | `Newtonsoft.Json.Linq.LineInfoHandling` | Gets or sets how JSON line info is handled when loading JSON. The default value is . |
| `DuplicatePropertyNameHandling` | `Newtonsoft.Json.Linq.DuplicatePropertyNameHandling` | Gets or sets how duplicate property names in JSON objects are handled when loading JSON. The default value is . |

#### Methods

| Signature | Description |
|-----------|-------------|
| `JsonLoadSettings()` | Initializes a new instance of the class. |
| `Newtonsoft.Json.Linq.CommentHandling get_CommentHandling()` |  |
| `void set_CommentHandling(Newtonsoft.Json.Linq.CommentHandling value)` |  |
| `Newtonsoft.Json.Linq.LineInfoHandling get_LineInfoHandling()` |  |
| `void set_LineInfoHandling(Newtonsoft.Json.Linq.LineInfoHandling value)` |  |
| `Newtonsoft.Json.Linq.DuplicatePropertyNameHandling get_DuplicatePropertyNameHandling()` |  |
| `void set_DuplicatePropertyNameHandling(Newtonsoft.Json.Linq.DuplicatePropertyNameHandling value)` |  |

---

### `class JsonMergeSettings`

Specifies the settings used when merging JSON.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `MergeArrayHandling` | `Newtonsoft.Json.Linq.MergeArrayHandling` | Gets or sets the method used when merging JSON arrays. |
| `MergeNullValueHandling` | `Newtonsoft.Json.Linq.MergeNullValueHandling` | Gets or sets how null value properties are merged. |
| `PropertyNameComparison` | `System.StringComparison` | Gets or sets the comparison used to match property names while merging. The exact property name will be searched for first and if no matching property is found then the will be used to match a property. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `JsonMergeSettings()` | Initializes a new instance of the class. |
| `Newtonsoft.Json.Linq.MergeArrayHandling get_MergeArrayHandling()` |  |
| `void set_MergeArrayHandling(Newtonsoft.Json.Linq.MergeArrayHandling value)` |  |
| `Newtonsoft.Json.Linq.MergeNullValueHandling get_MergeNullValueHandling()` |  |
| `void set_MergeNullValueHandling(Newtonsoft.Json.Linq.MergeNullValueHandling value)` |  |
| `System.StringComparison get_PropertyNameComparison()` |  |
| `void set_PropertyNameComparison(System.StringComparison value)` |  |

---

### `class JsonSelectSettings`

Specifies the settings used when selecting JSON.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `RegexMatchTimeout` | `System.Nullable<System.TimeSpan>` | Gets or sets a timeout that will be used when executing regular expressions. |
| `ErrorWhenNoMatch` | `bool` | Gets or sets a flag that indicates whether an error should be thrown if no tokens are found when evaluating part of the expression. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `System.Nullable<System.TimeSpan> get_RegexMatchTimeout()` |  |
| `void set_RegexMatchTimeout(System.Nullable<System.TimeSpan> value)` |  |
| `bool get_ErrorWhenNoMatch()` |  |
| `void set_ErrorWhenNoMatch(bool value)` |  |
| `JsonSelectSettings()` |  |

---

### `sealed enum LineInfoHandling`

Specifies how line information is handled when loading JSON.

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `value__` | `int` |  |
| `Ignore` | `Newtonsoft.Json.Linq.LineInfoHandling` | Ignore line information. |
| `Load` | `Newtonsoft.Json.Linq.LineInfoHandling` | Load line information. |

---

### `sealed enum MergeArrayHandling`

Specifies how JSON arrays are merged together.

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `value__` | `int` |  |
| `Concat` | `Newtonsoft.Json.Linq.MergeArrayHandling` | Concatenate arrays. |
| `Union` | `Newtonsoft.Json.Linq.MergeArrayHandling` | Union arrays, skipping items that already exist. |
| `Replace` | `Newtonsoft.Json.Linq.MergeArrayHandling` | Replace all array items. |
| `Merge` | `Newtonsoft.Json.Linq.MergeArrayHandling` | Merge array items together, matched by index. |

---

### `sealed enum MergeNullValueHandling`

Specifies how null value properties are merged.

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `value__` | `int` |  |
| `Ignore` | `Newtonsoft.Json.Linq.MergeNullValueHandling` | The content's null value properties will be ignored during merging. |
| `Merge` | `Newtonsoft.Json.Linq.MergeNullValueHandling` | The content's null value properties will be merged. |

---

## Newtonsoft.Json.Schema

### `static class Extensions`

Contains the JSON schema extension methods. JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details.

#### Methods

| Signature | Description |
|-----------|-------------|
| `static bool IsValid(Newtonsoft.Json.Linq.JToken source, Newtonsoft.Json.Schema.JsonSchema schema)` | Determines whether the is valid. JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details. |
| `static bool IsValid(Newtonsoft.Json.Linq.JToken source, Newtonsoft.Json.Schema.JsonSchema schema, ref ref System.Collections.Generic.IList<string> errorMessages)` |  |
| `static void Validate(Newtonsoft.Json.Linq.JToken source, Newtonsoft.Json.Schema.JsonSchema schema)` | Validates the specified . JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details. |
| `static void Validate(Newtonsoft.Json.Linq.JToken source, Newtonsoft.Json.Schema.JsonSchema schema, Newtonsoft.Json.Schema.ValidationEventHandler validationEventHandler)` | Validates the specified . JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details. |

---

### `class JsonSchema`

An in-memory representation of a JSON Schema. JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `Id` | `string` | Gets or sets the id. |
| `Title` | `string` | Gets or sets the title. |
| `Required` | `System.Nullable<bool>` | Gets or sets whether the object is required. |
| `ReadOnly` | `System.Nullable<bool>` | Gets or sets whether the object is read-only. |
| `Hidden` | `System.Nullable<bool>` | Gets or sets whether the object is visible to users. |
| `Transient` | `System.Nullable<bool>` | Gets or sets whether the object is transient. |
| `Description` | `string` | Gets or sets the description of the object. |
| `Type` | `System.Nullable<Newtonsoft.Json.Schema.JsonSchemaType>` | Gets or sets the types of values allowed by the object. |
| `Pattern` | `string` | Gets or sets the pattern. |
| `MinimumLength` | `System.Nullable<int>` | Gets or sets the minimum length. |
| `MaximumLength` | `System.Nullable<int>` | Gets or sets the maximum length. |
| `DivisibleBy` | `System.Nullable<double>` | Gets or sets a number that the value should be divisible by. |
| `Minimum` | `System.Nullable<double>` | Gets or sets the minimum. |
| `Maximum` | `System.Nullable<double>` | Gets or sets the maximum. |
| `ExclusiveMinimum` | `System.Nullable<bool>` | Gets or sets a flag indicating whether the value can not equal the number defined by the minimum attribute (). |
| `ExclusiveMaximum` | `System.Nullable<bool>` | Gets or sets a flag indicating whether the value can not equal the number defined by the maximum attribute (). |
| `MinimumItems` | `System.Nullable<int>` | Gets or sets the minimum number of items. |
| `MaximumItems` | `System.Nullable<int>` | Gets or sets the maximum number of items. |
| `Items` | `System.Collections.Generic.IList<Newtonsoft.Json.Schema.JsonSchema>` | Gets or sets the of items. |
| `PositionalItemsValidation` | `bool` | Gets or sets a value indicating whether items in an array are validated using the instance at their array position from . |
| `AdditionalItems` | `Newtonsoft.Json.Schema.JsonSchema` | Gets or sets the of additional items. |
| `AllowAdditionalItems` | `bool` | Gets or sets a value indicating whether additional items are allowed. |
| `UniqueItems` | `bool` | Gets or sets whether the array items must be unique. |
| `Properties` | `System.Collections.Generic.IDictionary<string, Newtonsoft.Json.Schema.JsonSchema>` | Gets or sets the of properties. |
| `AdditionalProperties` | `Newtonsoft.Json.Schema.JsonSchema` | Gets or sets the of additional properties. |
| `PatternProperties` | `System.Collections.Generic.IDictionary<string, Newtonsoft.Json.Schema.JsonSchema>` | Gets or sets the pattern properties. |
| `AllowAdditionalProperties` | `bool` | Gets or sets a value indicating whether additional properties are allowed. |
| `Requires` | `string` | Gets or sets the required property if this property is present. |
| `Enum` | `System.Collections.Generic.IList<Newtonsoft.Json.Linq.JToken>` | Gets or sets the a collection of valid enum values allowed. |
| `Disallow` | `System.Nullable<Newtonsoft.Json.Schema.JsonSchemaType>` | Gets or sets disallowed types. |
| `Default` | `Newtonsoft.Json.Linq.JToken` | Gets or sets the default value. |
| `Extends` | `System.Collections.Generic.IList<Newtonsoft.Json.Schema.JsonSchema>` | Gets or sets the collection of that this schema extends. |
| `Format` | `string` | Gets or sets the format. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `string get_Id()` |  |
| `void set_Id(string value)` |  |
| `string get_Title()` |  |
| `void set_Title(string value)` |  |
| `System.Nullable<bool> get_Required()` |  |
| `void set_Required(System.Nullable<bool> value)` |  |
| `System.Nullable<bool> get_ReadOnly()` |  |
| `void set_ReadOnly(System.Nullable<bool> value)` |  |
| `System.Nullable<bool> get_Hidden()` |  |
| `void set_Hidden(System.Nullable<bool> value)` |  |
| `System.Nullable<bool> get_Transient()` |  |
| `void set_Transient(System.Nullable<bool> value)` |  |
| `string get_Description()` |  |
| `void set_Description(string value)` |  |
| `System.Nullable<Newtonsoft.Json.Schema.JsonSchemaType> get_Type()` |  |
| `void set_Type(System.Nullable<Newtonsoft.Json.Schema.JsonSchemaType> value)` |  |
| `string get_Pattern()` |  |
| `void set_Pattern(string value)` |  |
| `System.Nullable<int> get_MinimumLength()` |  |
| `void set_MinimumLength(System.Nullable<int> value)` |  |
| `System.Nullable<int> get_MaximumLength()` |  |
| `void set_MaximumLength(System.Nullable<int> value)` |  |
| `System.Nullable<double> get_DivisibleBy()` |  |
| `void set_DivisibleBy(System.Nullable<double> value)` |  |
| `System.Nullable<double> get_Minimum()` |  |
| `void set_Minimum(System.Nullable<double> value)` |  |
| `System.Nullable<double> get_Maximum()` |  |
| `void set_Maximum(System.Nullable<double> value)` |  |
| `System.Nullable<bool> get_ExclusiveMinimum()` |  |
| `void set_ExclusiveMinimum(System.Nullable<bool> value)` |  |
| `System.Nullable<bool> get_ExclusiveMaximum()` |  |
| `void set_ExclusiveMaximum(System.Nullable<bool> value)` |  |
| `System.Nullable<int> get_MinimumItems()` |  |
| `void set_MinimumItems(System.Nullable<int> value)` |  |
| `System.Nullable<int> get_MaximumItems()` |  |
| `void set_MaximumItems(System.Nullable<int> value)` |  |
| `System.Collections.Generic.IList<Newtonsoft.Json.Schema.JsonSchema> get_Items()` |  |
| `void set_Items(System.Collections.Generic.IList<Newtonsoft.Json.Schema.JsonSchema> value)` |  |
| `bool get_PositionalItemsValidation()` |  |
| `void set_PositionalItemsValidation(bool value)` |  |
| `Newtonsoft.Json.Schema.JsonSchema get_AdditionalItems()` |  |
| `void set_AdditionalItems(Newtonsoft.Json.Schema.JsonSchema value)` |  |
| `bool get_AllowAdditionalItems()` |  |
| `void set_AllowAdditionalItems(bool value)` |  |
| `bool get_UniqueItems()` |  |
| `void set_UniqueItems(bool value)` |  |
| `System.Collections.Generic.IDictionary<string, Newtonsoft.Json.Schema.JsonSchema> get_Properties()` |  |
| `void set_Properties(System.Collections.Generic.IDictionary<string, Newtonsoft.Json.Schema.JsonSchema> value)` |  |
| `Newtonsoft.Json.Schema.JsonSchema get_AdditionalProperties()` |  |
| `void set_AdditionalProperties(Newtonsoft.Json.Schema.JsonSchema value)` |  |
| `System.Collections.Generic.IDictionary<string, Newtonsoft.Json.Schema.JsonSchema> get_PatternProperties()` |  |
| `void set_PatternProperties(System.Collections.Generic.IDictionary<string, Newtonsoft.Json.Schema.JsonSchema> value)` |  |
| `bool get_AllowAdditionalProperties()` |  |
| `void set_AllowAdditionalProperties(bool value)` |  |
| `string get_Requires()` |  |
| `void set_Requires(string value)` |  |
| `System.Collections.Generic.IList<Newtonsoft.Json.Linq.JToken> get_Enum()` |  |
| `void set_Enum(System.Collections.Generic.IList<Newtonsoft.Json.Linq.JToken> value)` |  |
| `System.Nullable<Newtonsoft.Json.Schema.JsonSchemaType> get_Disallow()` |  |
| `void set_Disallow(System.Nullable<Newtonsoft.Json.Schema.JsonSchemaType> value)` |  |
| `Newtonsoft.Json.Linq.JToken get_Default()` |  |
| `void set_Default(Newtonsoft.Json.Linq.JToken value)` |  |
| `System.Collections.Generic.IList<Newtonsoft.Json.Schema.JsonSchema> get_Extends()` |  |
| `void set_Extends(System.Collections.Generic.IList<Newtonsoft.Json.Schema.JsonSchema> value)` |  |
| `string get_Format()` |  |
| `void set_Format(string value)` |  |
| `JsonSchema()` | Initializes a new instance of the class. |
| `static Newtonsoft.Json.Schema.JsonSchema Read(Newtonsoft.Json.JsonReader reader)` | Reads a from the specified . |
| `static Newtonsoft.Json.Schema.JsonSchema Read(Newtonsoft.Json.JsonReader reader, Newtonsoft.Json.Schema.JsonSchemaResolver resolver)` | Reads a from the specified . |
| `static Newtonsoft.Json.Schema.JsonSchema Parse(string json)` | Load a from a string that contains JSON Schema. |
| `static Newtonsoft.Json.Schema.JsonSchema Parse(string json, Newtonsoft.Json.Schema.JsonSchemaResolver resolver)` | Load a from a string that contains JSON Schema using the specified . |
| `void WriteTo(Newtonsoft.Json.JsonWriter writer)` | Writes this schema to a . |
| `void WriteTo(Newtonsoft.Json.JsonWriter writer, Newtonsoft.Json.Schema.JsonSchemaResolver resolver)` | Writes this schema to a using the specified . |
| `virtual string ToString()` | Returns a that represents the current . |

---

### `class JsonSchemaException : Newtonsoft.Json.JsonException`

Returns detailed information about the schema exception. JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `LineNumber` | `int` | Gets the line number indicating where the error occurred. |
| `LinePosition` | `int` | Gets the line position indicating where the error occurred. |
| `Path` | `string` | Gets the path to the JSON where the error occurred. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `int get_LineNumber()` |  |
| `int get_LinePosition()` |  |
| `string get_Path()` |  |
| `JsonSchemaException()` | Initializes a new instance of the class. |
| `JsonSchemaException(string message)` | Initializes a new instance of the class with a specified error message. |
| `JsonSchemaException(string message, System.Exception innerException)` | Initializes a new instance of the class with a specified error message and a reference to the inner exception that is the cause of this exception. |
| `JsonSchemaException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)` | Initializes a new instance of the class. |

---

### `class JsonSchemaGenerator`

Generates a from a specified . JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `UndefinedSchemaIdHandling` | `Newtonsoft.Json.Schema.UndefinedSchemaIdHandling` | Gets or sets how undefined schemas are handled by the serializer. |
| `ContractResolver` | `Newtonsoft.Json.Serialization.IContractResolver` | Gets or sets the contract resolver. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `Newtonsoft.Json.Schema.UndefinedSchemaIdHandling get_UndefinedSchemaIdHandling()` |  |
| `void set_UndefinedSchemaIdHandling(Newtonsoft.Json.Schema.UndefinedSchemaIdHandling value)` |  |
| `Newtonsoft.Json.Serialization.IContractResolver get_ContractResolver()` |  |
| `void set_ContractResolver(Newtonsoft.Json.Serialization.IContractResolver value)` |  |
| `Newtonsoft.Json.Schema.JsonSchema Generate(System.Type type)` | Generate a from the specified type. |
| `Newtonsoft.Json.Schema.JsonSchema Generate(System.Type type, Newtonsoft.Json.Schema.JsonSchemaResolver resolver)` | Generate a from the specified type. |
| `Newtonsoft.Json.Schema.JsonSchema Generate(System.Type type, bool rootSchemaNullable)` | Generate a from the specified type. |
| `Newtonsoft.Json.Schema.JsonSchema Generate(System.Type type, Newtonsoft.Json.Schema.JsonSchemaResolver resolver, bool rootSchemaNullable)` | Generate a from the specified type. |
| `JsonSchemaGenerator()` |  |

---

### `class JsonSchemaResolver`

Resolves from an id. JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `LoadedSchemas` | `System.Collections.Generic.IList<Newtonsoft.Json.Schema.JsonSchema>` | Gets or sets the loaded schemas. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `System.Collections.Generic.IList<Newtonsoft.Json.Schema.JsonSchema> get_LoadedSchemas()` |  |
| `void set_LoadedSchemas(System.Collections.Generic.IList<Newtonsoft.Json.Schema.JsonSchema> value)` |  |
| `JsonSchemaResolver()` | Initializes a new instance of the class. |
| `virtual Newtonsoft.Json.Schema.JsonSchema GetSchema(string reference)` | Gets a for the specified reference. |

---

### `sealed enum JsonSchemaType`

The value types allowed by the . JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details.

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `value__` | `int` |  |
| `None` | `Newtonsoft.Json.Schema.JsonSchemaType` | No type specified. |
| `String` | `Newtonsoft.Json.Schema.JsonSchemaType` | String type. |
| `Float` | `Newtonsoft.Json.Schema.JsonSchemaType` | Float type. |
| `Integer` | `Newtonsoft.Json.Schema.JsonSchemaType` | Integer type. |
| `Boolean` | `Newtonsoft.Json.Schema.JsonSchemaType` | Boolean type. |
| `Object` | `Newtonsoft.Json.Schema.JsonSchemaType` | Object type. |
| `Array` | `Newtonsoft.Json.Schema.JsonSchemaType` | Array type. |
| `Null` | `Newtonsoft.Json.Schema.JsonSchemaType` | Null type. |
| `Any` | `Newtonsoft.Json.Schema.JsonSchemaType` | Any type. |

---

### `sealed enum UndefinedSchemaIdHandling`

Specifies undefined schema Id handling options for the . JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details.

#### Fields

| Name | Type | Description |
|------|------|-------------|
| `value__` | `int` |  |
| `None` | `Newtonsoft.Json.Schema.UndefinedSchemaIdHandling` | Do not infer a schema Id. |
| `UseTypeName` | `Newtonsoft.Json.Schema.UndefinedSchemaIdHandling` | Use the .NET type name as the schema Id. |
| `UseAssemblyQualifiedName` | `Newtonsoft.Json.Schema.UndefinedSchemaIdHandling` | Use the assembly qualified .NET type name as the schema Id. |

---

### `class ValidationEventArgs : System.EventArgs`

Returns detailed information related to the . JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `Exception` | `Newtonsoft.Json.Schema.JsonSchemaException` | Gets the associated with the validation error. |
| `Path` | `string` | Gets the path of the JSON location where the validation error occurred. |
| `Message` | `string` | Gets the text description corresponding to the validation error. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `Newtonsoft.Json.Schema.JsonSchemaException get_Exception()` |  |
| `string get_Path()` |  |
| `string get_Message()` |  |

---

### `sealed delegate ValidationEventHandler : System.MulticastDelegate`

Represents the callback method that will handle JSON schema validation events and the . JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details.

#### Methods

| Signature | Description |
|-----------|-------------|
| `ValidationEventHandler(object object, nint method)` |  |
| `virtual void Invoke(object sender, Newtonsoft.Json.Schema.ValidationEventArgs e)` |  |
| `virtual System.IAsyncResult BeginInvoke(object sender, Newtonsoft.Json.Schema.ValidationEventArgs e, System.AsyncCallback callback, object object)` |  |
| `virtual void EndInvoke(System.IAsyncResult result)` |  |

---

## Newtonsoft.Json.Serialization

### `class CamelCaseNamingStrategy : Newtonsoft.Json.Serialization.NamingStrategy`

A camel case naming strategy.

#### Methods

| Signature | Description |
|-----------|-------------|
| `CamelCaseNamingStrategy(bool processDictionaryKeys, bool overrideSpecifiedNames)` | Initializes a new instance of the class. |
| `CamelCaseNamingStrategy(bool processDictionaryKeys, bool overrideSpecifiedNames, bool processExtensionDataNames)` | Initializes a new instance of the class. |
| `CamelCaseNamingStrategy()` | Initializes a new instance of the class. |
| `virtual string ResolvePropertyName(string name)` | Resolves the specified property name. |

---

### `class CamelCasePropertyNamesContractResolver : Newtonsoft.Json.Serialization.DefaultContractResolver`

Resolves member mappings for a type, camel casing property names.

#### Methods

| Signature | Description |
|-----------|-------------|
| `CamelCasePropertyNamesContractResolver()` | Initializes a new instance of the class. |
| `virtual Newtonsoft.Json.Serialization.JsonContract ResolveContract(System.Type type)` | Resolves the contract for a given type. |

---

### `class DefaultContractResolver : Newtonsoft.Json.Serialization.IContractResolver`

Used by to resolve a for a given .

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `DynamicCodeGeneration` | `bool` | Gets a value indicating whether members are being get and set using dynamic code generation. This value is determined by the runtime permissions available. |
| `DefaultMembersSearchFlags` | `System.Reflection.BindingFlags` | Gets or sets the default members search flags. |
| `SerializeCompilerGeneratedMembers` | `bool` | Gets or sets a value indicating whether compiler generated members should be serialized. |
| `IgnoreSerializableInterface` | `bool` | Gets or sets a value indicating whether to ignore the interface when serializing and deserializing types. |
| `IgnoreSerializableAttribute` | `bool` | Gets or sets a value indicating whether to ignore the attribute when serializing and deserializing types. |
| `IgnoreIsSpecifiedMembers` | `bool` | Gets or sets a value indicating whether to ignore IsSpecified members when serializing and deserializing types. |
| `IgnoreShouldSerializeMembers` | `bool` | Gets or sets a value indicating whether to ignore ShouldSerialize members when serializing and deserializing types. |
| `NamingStrategy` | `Newtonsoft.Json.Serialization.NamingStrategy` | Gets or sets the naming strategy used to resolve how property names and dictionary keys are serialized. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `bool get_DynamicCodeGeneration()` |  |
| `System.Reflection.BindingFlags get_DefaultMembersSearchFlags()` |  |
| `void set_DefaultMembersSearchFlags(System.Reflection.BindingFlags value)` |  |
| `bool get_SerializeCompilerGeneratedMembers()` |  |
| `void set_SerializeCompilerGeneratedMembers(bool value)` |  |
| `bool get_IgnoreSerializableInterface()` |  |
| `void set_IgnoreSerializableInterface(bool value)` |  |
| `bool get_IgnoreSerializableAttribute()` |  |
| `void set_IgnoreSerializableAttribute(bool value)` |  |
| `bool get_IgnoreIsSpecifiedMembers()` |  |
| `void set_IgnoreIsSpecifiedMembers(bool value)` |  |
| `bool get_IgnoreShouldSerializeMembers()` |  |
| `void set_IgnoreShouldSerializeMembers(bool value)` |  |
| `Newtonsoft.Json.Serialization.NamingStrategy get_NamingStrategy()` |  |
| `void set_NamingStrategy(Newtonsoft.Json.Serialization.NamingStrategy value)` |  |
| `DefaultContractResolver()` | Initializes a new instance of the class. |
| `virtual Newtonsoft.Json.Serialization.JsonContract ResolveContract(System.Type type)` | Resolves the contract for a given type. |
| `virtual System.Collections.Generic.List<System.Reflection.MemberInfo> GetSerializableMembers(System.Type objectType)` | Gets the serializable members for the type. |
| `virtual Newtonsoft.Json.Serialization.JsonObjectContract CreateObjectContract(System.Type objectType)` | Creates a for the given type. |
| `virtual System.Collections.Generic.IList<Newtonsoft.Json.Serialization.JsonProperty> CreateConstructorParameters(System.Reflection.ConstructorInfo constructor, Newtonsoft.Json.Serialization.JsonPropertyCollection memberProperties)` | Creates the constructor parameters. |
| `virtual Newtonsoft.Json.Serialization.JsonProperty CreatePropertyFromConstructorParameter(Newtonsoft.Json.Serialization.JsonProperty matchingMemberProperty, System.Reflection.ParameterInfo parameterInfo)` | Creates a for the given . |
| `virtual Newtonsoft.Json.JsonConverter ResolveContractConverter(System.Type , ? objectType)` | Resolves the default for the contract. |
| `virtual Newtonsoft.Json.Serialization.JsonDictionaryContract CreateDictionaryContract(System.Type objectType)` | Creates a for the given type. |
| `virtual Newtonsoft.Json.Serialization.JsonArrayContract CreateArrayContract(System.Type objectType)` | Creates a for the given type. |
| `virtual Newtonsoft.Json.Serialization.JsonPrimitiveContract CreatePrimitiveContract(System.Type objectType)` | Creates a for the given type. |
| `virtual Newtonsoft.Json.Serialization.JsonLinqContract CreateLinqContract(System.Type objectType)` | Creates a for the given type. |
| `virtual Newtonsoft.Json.Serialization.JsonISerializableContract CreateISerializableContract(System.Type objectType)` | Creates a for the given type. |
| `virtual Newtonsoft.Json.Serialization.JsonDynamicContract CreateDynamicContract(System.Type objectType)` | Creates a for the given type. |
| `virtual Newtonsoft.Json.Serialization.JsonStringContract CreateStringContract(System.Type objectType)` | Creates a for the given type. |
| `virtual Newtonsoft.Json.Serialization.JsonContract CreateContract(System.Type objectType)` | Determines which contract type is created for the given type. |
| `virtual System.Collections.Generic.IList<Newtonsoft.Json.Serialization.JsonProperty> CreateProperties(System.Type type, Newtonsoft.Json.MemberSerialization memberSerialization)` | Creates properties for the given . |
| `virtual Newtonsoft.Json.Serialization.IValueProvider CreateMemberValueProvider(System.Reflection.MemberInfo member)` | Creates the used by the serializer to get and set values from a member. |
| `virtual Newtonsoft.Json.Serialization.JsonProperty CreateProperty(System.Reflection.MemberInfo member, Newtonsoft.Json.MemberSerialization memberSerialization)` | Creates a for the given . |
| `virtual string ResolvePropertyName(string propertyName)` | Resolves the name of the property. |
| `virtual string ResolveExtensionDataName(string extensionDataName)` | Resolves the name of the extension data. By default no changes are made to extension data names. |
| `virtual string ResolveDictionaryKey(string dictionaryKey)` | Resolves the key of the dictionary. By default is used to resolve dictionary keys. |
| `string GetResolvedPropertyName(string propertyName)` | Gets the resolved name of the property. |

---

### `class DefaultNamingStrategy : Newtonsoft.Json.Serialization.NamingStrategy`

The default naming strategy. Property names and dictionary keys are unchanged.

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual string ResolvePropertyName(string name)` | Resolves the specified property name. |
| `DefaultNamingStrategy()` |  |

---

### `class DefaultSerializationBinder : System.Runtime.Serialization.SerializationBinder, Newtonsoft.Json.Serialization.ISerializationBinder`

The default serialization binder used when resolving and loading classes from type names.

#### Methods

| Signature | Description |
|-----------|-------------|
| `DefaultSerializationBinder()` | Initializes a new instance of the class. |
| `virtual System.Type BindToType(string assemblyName, string typeName)` | When overridden in a derived class, controls the binding of a serialized object to a type. |
| `virtual void BindToName(System.Type serializedType, ref ref string assemblyName, ref ref string typeName)` | When overridden in a derived class, controls the binding of a serialized object to a type. |

---

### `class DiagnosticsTraceWriter : Newtonsoft.Json.Serialization.ITraceWriter`

Represents a trace writer that writes to the application's instances.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `LevelFilter` | `System.Diagnostics.TraceLevel` | Gets the that will be used to filter the trace messages passed to the writer. For example a filter level of will exclude messages and include , and messages. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual System.Diagnostics.TraceLevel get_LevelFilter()` |  |
| `void set_LevelFilter(System.Diagnostics.TraceLevel value)` |  |
| `virtual void Trace(System.Diagnostics.TraceLevel level, string message, System.Exception ex)` | Writes the specified trace level, message and optional exception. |
| `DiagnosticsTraceWriter()` |  |

---

### `class DynamicValueProvider : Newtonsoft.Json.Serialization.IValueProvider`

Get and set values for a using dynamic methods.

#### Methods

| Signature | Description |
|-----------|-------------|
| `DynamicValueProvider(System.Reflection.MemberInfo memberInfo)` | Initializes a new instance of the class. |
| `virtual void SetValue(object target, object value)` | Sets the value. |
| `virtual object GetValue(object , ? target)` | Gets the value. |

---

### `class ErrorContext`

Provides information surrounding an error.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `Error` | `System.Exception` | Gets the error. |
| `OriginalObject` | `object` | Gets the original object that caused the error. |
| `Member` | `object` | Gets the member that caused the error. |
| `Path` | `string` | Gets the path of the JSON location where the error occurred. |
| `Handled` | `bool` | Gets or sets a value indicating whether this is handled. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `System.Exception get_Error()` |  |
| `object get_OriginalObject()` |  |
| `object get_Member()` |  |
| `string get_Path()` |  |
| `bool get_Handled()` |  |
| `void set_Handled(bool value)` |  |

---

### `class ErrorEventArgs : System.EventArgs`

Provides data for the Error event.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `CurrentObject` | `object` | Gets the current object the error event is being raised against. |
| `ErrorContext` | `Newtonsoft.Json.Serialization.ErrorContext` | Gets the error context. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `object get_CurrentObject()` |  |
| `Newtonsoft.Json.Serialization.ErrorContext get_ErrorContext()` |  |
| `ErrorEventArgs(object currentObject, Newtonsoft.Json.Serialization.ErrorContext errorContext)` | Initializes a new instance of the class. |

---

### `class ExpressionValueProvider : Newtonsoft.Json.Serialization.IValueProvider`

Get and set values for a using dynamic methods.

#### Methods

| Signature | Description |
|-----------|-------------|
| `ExpressionValueProvider(System.Reflection.MemberInfo memberInfo)` | Initializes a new instance of the class. |
| `virtual void SetValue(object target, object value)` | Sets the value. |
| `virtual object GetValue(object , ? target)` | Gets the value. |

---

### `sealed delegate ExtensionDataGetter : System.MulticastDelegate`

Gets extension data for an object during serialization.

#### Methods

| Signature | Description |
|-----------|-------------|
| `ExtensionDataGetter(object object, nint method)` |  |
| `virtual System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object, object>> Invoke(object , ? o)` |  |
| `virtual System.IAsyncResult BeginInvoke(object o, System.AsyncCallback callback, object object)` |  |
| `virtual System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object, object>> EndInvoke(System.IAsyncResult , ? result)` |  |

---

### `sealed delegate ExtensionDataSetter : System.MulticastDelegate`

Sets extension data for an object during deserialization.

#### Methods

| Signature | Description |
|-----------|-------------|
| `ExtensionDataSetter(object object, nint method)` |  |
| `virtual void Invoke(object o, string key, object value)` |  |
| `virtual System.IAsyncResult BeginInvoke(object o, string key, object value, System.AsyncCallback callback, object object)` |  |
| `virtual void EndInvoke(System.IAsyncResult result)` |  |

---

### `abstract interface IAttributeProvider`

Provides methods to get attributes.

#### Methods

| Signature | Description |
|-----------|-------------|
| `abstract System.Collections.Generic.IList<System.Attribute> GetAttributes(bool inherit)` | Returns a collection of all of the attributes, or an empty collection if there are no attributes. |
| `abstract System.Collections.Generic.IList<System.Attribute> GetAttributes(System.Type attributeType, bool inherit)` | Returns a collection of attributes, identified by type, or an empty collection if there are no attributes. |

---

### `abstract interface IContractResolver`

Used by to resolve a for a given .

#### Methods

| Signature | Description |
|-----------|-------------|
| `abstract Newtonsoft.Json.Serialization.JsonContract ResolveContract(System.Type type)` | Resolves the contract for a given type. |

---

### `abstract interface IReferenceResolver`

Used to resolve references when serializing and deserializing JSON by the .

#### Methods

| Signature | Description |
|-----------|-------------|
| `abstract object ResolveReference(object context, string reference)` | Resolves a reference to its object. |
| `abstract string GetReference(object context, object value)` | Gets the reference for the specified object. |
| `abstract bool IsReferenced(object context, object value)` | Determines whether the specified object is referenced. |
| `abstract void AddReference(object context, string reference, object value)` | Adds a reference to the specified object. |

---

### `abstract interface ISerializationBinder`

Allows users to control class loading and mandate what class to load.

#### Methods

| Signature | Description |
|-----------|-------------|
| `abstract System.Type BindToType(string assemblyName, string typeName)` | When implemented, controls the binding of a serialized object to a type. |
| `abstract void BindToName(System.Type serializedType, ref ref string assemblyName, ref ref string typeName)` | When implemented, controls the binding of a serialized object to a type. |

---

### `abstract interface ITraceWriter`

Represents a trace writer.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `LevelFilter` | `System.Diagnostics.TraceLevel` | Gets the that will be used to filter the trace messages passed to the writer. For example a filter level of will exclude messages and include , and messages. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `abstract System.Diagnostics.TraceLevel get_LevelFilter()` |  |
| `abstract void Trace(System.Diagnostics.TraceLevel level, string message, System.Exception ex)` | Writes the specified trace level, message and optional exception. |

---

### `abstract interface IValueProvider`

Provides methods to get and set values.

#### Methods

| Signature | Description |
|-----------|-------------|
| `abstract void SetValue(object target, object value)` | Sets the value. |
| `abstract object GetValue(object , ? target)` | Gets the value. |

---

### `class JsonArrayContract : Newtonsoft.Json.Serialization.JsonContainerContract`

Contract details for a used by the .

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `CollectionItemType` | `System.Type` | Gets the of the collection items. |
| `IsMultidimensionalArray` | `bool` | Gets a value indicating whether the collection type is a multidimensional array. |
| `OverrideCreator` | `Newtonsoft.Json.Serialization.ObjectConstructor<object>` | Gets or sets the function used to create the object. When set this function will override . |
| `HasParameterizedCreator` | `bool` | Gets a value indicating whether the creator has a parameter with the collection values. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `System.Type get_CollectionItemType()` |  |
| `bool get_IsMultidimensionalArray()` |  |
| `Newtonsoft.Json.Serialization.ObjectConstructor<object> get_OverrideCreator(? )` |  |
| `void set_OverrideCreator(Newtonsoft.Json.Serialization.ObjectConstructor<object> value)` |  |
| `bool get_HasParameterizedCreator()` |  |
| `void set_HasParameterizedCreator(bool value)` |  |
| `JsonArrayContract(System.Type underlyingType)` | Initializes a new instance of the class. |

---

### `class JsonContainerContract : Newtonsoft.Json.Serialization.JsonContract`

Contract details for a used by the .

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `ItemConverter` | `Newtonsoft.Json.JsonConverter` | Gets or sets the default collection items . |
| `ItemIsReference` | `System.Nullable<bool>` | Gets or sets a value indicating whether the collection items preserve object references. |
| `ItemReferenceLoopHandling` | `System.Nullable<Newtonsoft.Json.ReferenceLoopHandling>` | Gets or sets the collection item reference loop handling. |
| `ItemTypeNameHandling` | `System.Nullable<Newtonsoft.Json.TypeNameHandling>` | Gets or sets the collection item type name handling. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `Newtonsoft.Json.JsonConverter get_ItemConverter()` |  |
| `void set_ItemConverter(Newtonsoft.Json.JsonConverter value)` |  |
| `System.Nullable<bool> get_ItemIsReference()` |  |
| `void set_ItemIsReference(System.Nullable<bool> value)` |  |
| `System.Nullable<Newtonsoft.Json.ReferenceLoopHandling> get_ItemReferenceLoopHandling()` |  |
| `void set_ItemReferenceLoopHandling(System.Nullable<Newtonsoft.Json.ReferenceLoopHandling> value)` |  |
| `System.Nullable<Newtonsoft.Json.TypeNameHandling> get_ItemTypeNameHandling()` |  |
| `void set_ItemTypeNameHandling(System.Nullable<Newtonsoft.Json.TypeNameHandling> value)` |  |

---

### `abstract class JsonContract`

Contract details for a used by the .

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `UnderlyingType` | `System.Type` | Gets the underlying type for the contract. |
| `CreatedType` | `System.Type` | Gets or sets the type created during deserialization. |
| `IsReference` | `System.Nullable<bool>` | Gets or sets whether this type contract is serialized as a reference. |
| `Converter` | `Newtonsoft.Json.JsonConverter` | Gets or sets the default for this contract. |
| `InternalConverter` | `Newtonsoft.Json.JsonConverter` | Gets the internally resolved for the contract's type. This converter is used as a fallback converter when no other converter is resolved. Setting will always override this converter. |
| `OnDeserializedCallbacks` | `System.Collections.Generic.IList<Newtonsoft.Json.Serialization.SerializationCallback>` | Gets or sets all methods called immediately after deserialization of the object. |
| `OnDeserializingCallbacks` | `System.Collections.Generic.IList<Newtonsoft.Json.Serialization.SerializationCallback>` | Gets or sets all methods called during deserialization of the object. |
| `OnSerializedCallbacks` | `System.Collections.Generic.IList<Newtonsoft.Json.Serialization.SerializationCallback>` | Gets or sets all methods called after serialization of the object graph. |
| `OnSerializingCallbacks` | `System.Collections.Generic.IList<Newtonsoft.Json.Serialization.SerializationCallback>` | Gets or sets all methods called before serialization of the object. |
| `OnErrorCallbacks` | `System.Collections.Generic.IList<Newtonsoft.Json.Serialization.SerializationErrorCallback>` | Gets or sets all method called when an error is thrown during the serialization of the object. |
| `DefaultCreator` | `System.Func<object>` | Gets or sets the default creator method used to create the object. |
| `DefaultCreatorNonPublic` | `bool` | Gets or sets a value indicating whether the default creator is non-public. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `System.Type get_UnderlyingType()` |  |
| `System.Type get_CreatedType()` |  |
| `void set_CreatedType(System.Type value)` |  |
| `System.Nullable<bool> get_IsReference()` |  |
| `void set_IsReference(System.Nullable<bool> value)` |  |
| `Newtonsoft.Json.JsonConverter get_Converter()` |  |
| `void set_Converter(Newtonsoft.Json.JsonConverter value)` |  |
| `Newtonsoft.Json.JsonConverter get_InternalConverter()` |  |
| `System.Collections.Generic.IList<Newtonsoft.Json.Serialization.SerializationCallback> get_OnDeserializedCallbacks()` |  |
| `System.Collections.Generic.IList<Newtonsoft.Json.Serialization.SerializationCallback> get_OnDeserializingCallbacks()` |  |
| `System.Collections.Generic.IList<Newtonsoft.Json.Serialization.SerializationCallback> get_OnSerializedCallbacks()` |  |
| `System.Collections.Generic.IList<Newtonsoft.Json.Serialization.SerializationCallback> get_OnSerializingCallbacks()` |  |
| `System.Collections.Generic.IList<Newtonsoft.Json.Serialization.SerializationErrorCallback> get_OnErrorCallbacks()` |  |
| `System.Func<object> get_DefaultCreator(? )` |  |
| `void set_DefaultCreator(System.Func<object> value)` |  |
| `bool get_DefaultCreatorNonPublic()` |  |
| `void set_DefaultCreatorNonPublic(bool value)` |  |

---

### `class JsonDictionaryContract : Newtonsoft.Json.Serialization.JsonContainerContract`

Contract details for a used by the .

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `DictionaryKeyResolver` | `System.Func<string, string>` | Gets or sets the dictionary key resolver. |
| `DictionaryKeyType` | `System.Type` | Gets the of the dictionary keys. |
| `DictionaryValueType` | `System.Type` | Gets the of the dictionary values. |
| `OverrideCreator` | `Newtonsoft.Json.Serialization.ObjectConstructor<object>` | Gets or sets the function used to create the object. When set this function will override . |
| `HasParameterizedCreator` | `bool` | Gets a value indicating whether the creator has a parameter with the dictionary values. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `System.Func<string, string> get_DictionaryKeyResolver(? )` |  |
| `void set_DictionaryKeyResolver(System.Func<string, string> value)` |  |
| `System.Type get_DictionaryKeyType()` |  |
| `System.Type get_DictionaryValueType()` |  |
| `Newtonsoft.Json.Serialization.ObjectConstructor<object> get_OverrideCreator(? )` |  |
| `void set_OverrideCreator(Newtonsoft.Json.Serialization.ObjectConstructor<object> value)` |  |
| `bool get_HasParameterizedCreator()` |  |
| `void set_HasParameterizedCreator(bool value)` |  |
| `JsonDictionaryContract(System.Type underlyingType)` | Initializes a new instance of the class. |

---

### `class JsonDynamicContract : Newtonsoft.Json.Serialization.JsonContainerContract`

Contract details for a used by the .

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `Properties` | `Newtonsoft.Json.Serialization.JsonPropertyCollection` | Gets the object's properties. |
| `PropertyNameResolver` | `System.Func<string, string>` | Gets or sets the property name resolver. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `Newtonsoft.Json.Serialization.JsonPropertyCollection get_Properties()` |  |
| `System.Func<string, string> get_PropertyNameResolver(? )` |  |
| `void set_PropertyNameResolver(System.Func<string, string> value)` |  |
| `JsonDynamicContract(System.Type underlyingType)` | Initializes a new instance of the class. |

---

### `class JsonISerializableContract : Newtonsoft.Json.Serialization.JsonContainerContract`

Contract details for a used by the .

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `ISerializableCreator` | `Newtonsoft.Json.Serialization.ObjectConstructor<object>` | Gets or sets the object constructor. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `Newtonsoft.Json.Serialization.ObjectConstructor<object> get_ISerializableCreator(? )` |  |
| `void set_ISerializableCreator(Newtonsoft.Json.Serialization.ObjectConstructor<object> value)` |  |
| `JsonISerializableContract(System.Type underlyingType)` | Initializes a new instance of the class. |

---

### `class JsonLinqContract : Newtonsoft.Json.Serialization.JsonContract`

Contract details for a used by the .

#### Methods

| Signature | Description |
|-----------|-------------|
| `JsonLinqContract(System.Type underlyingType)` | Initializes a new instance of the class. |

---

### `class JsonObjectContract : Newtonsoft.Json.Serialization.JsonContainerContract`

Contract details for a used by the .

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `MemberSerialization` | `Newtonsoft.Json.MemberSerialization` | Gets or sets the object member serialization. |
| `MissingMemberHandling` | `System.Nullable<Newtonsoft.Json.MissingMemberHandling>` | Gets or sets the missing member handling used when deserializing this object. |
| `ItemRequired` | `System.Nullable<Newtonsoft.Json.Required>` | Gets or sets a value that indicates whether the object's properties are required. |
| `ItemNullValueHandling` | `System.Nullable<Newtonsoft.Json.NullValueHandling>` | Gets or sets how the object's properties with null values are handled during serialization and deserialization. |
| `Properties` | `Newtonsoft.Json.Serialization.JsonPropertyCollection` | Gets the object's properties. |
| `CreatorParameters` | `Newtonsoft.Json.Serialization.JsonPropertyCollection` | Gets a collection of instances that define the parameters used with . |
| `OverrideCreator` | `Newtonsoft.Json.Serialization.ObjectConstructor<object>` | Gets or sets the function used to create the object. When set this function will override . This function is called with a collection of arguments which are defined by the collection. |
| `ExtensionDataSetter` | `Newtonsoft.Json.Serialization.ExtensionDataSetter` | Gets or sets the extension data setter. |
| `ExtensionDataGetter` | `Newtonsoft.Json.Serialization.ExtensionDataGetter` | Gets or sets the extension data getter. |
| `ExtensionDataValueType` | `System.Type` | Gets or sets the extension data value type. |
| `ExtensionDataNameResolver` | `System.Func<string, string>` | Gets or sets the extension data name resolver. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `Newtonsoft.Json.MemberSerialization get_MemberSerialization()` |  |
| `void set_MemberSerialization(Newtonsoft.Json.MemberSerialization value)` |  |
| `System.Nullable<Newtonsoft.Json.MissingMemberHandling> get_MissingMemberHandling()` |  |
| `void set_MissingMemberHandling(System.Nullable<Newtonsoft.Json.MissingMemberHandling> value)` |  |
| `System.Nullable<Newtonsoft.Json.Required> get_ItemRequired()` |  |
| `void set_ItemRequired(System.Nullable<Newtonsoft.Json.Required> value)` |  |
| `System.Nullable<Newtonsoft.Json.NullValueHandling> get_ItemNullValueHandling()` |  |
| `void set_ItemNullValueHandling(System.Nullable<Newtonsoft.Json.NullValueHandling> value)` |  |
| `Newtonsoft.Json.Serialization.JsonPropertyCollection get_Properties()` |  |
| `Newtonsoft.Json.Serialization.JsonPropertyCollection get_CreatorParameters()` |  |
| `Newtonsoft.Json.Serialization.ObjectConstructor<object> get_OverrideCreator(? )` |  |
| `void set_OverrideCreator(Newtonsoft.Json.Serialization.ObjectConstructor<object> value)` |  |
| `Newtonsoft.Json.Serialization.ExtensionDataSetter get_ExtensionDataSetter()` |  |
| `void set_ExtensionDataSetter(Newtonsoft.Json.Serialization.ExtensionDataSetter value)` |  |
| `Newtonsoft.Json.Serialization.ExtensionDataGetter get_ExtensionDataGetter()` |  |
| `void set_ExtensionDataGetter(Newtonsoft.Json.Serialization.ExtensionDataGetter value)` |  |
| `System.Type get_ExtensionDataValueType()` |  |
| `void set_ExtensionDataValueType(System.Type value)` |  |
| `System.Func<string, string> get_ExtensionDataNameResolver(? )` |  |
| `void set_ExtensionDataNameResolver(System.Func<string, string> value)` |  |
| `JsonObjectContract(System.Type underlyingType)` | Initializes a new instance of the class. |

---

### `class JsonPrimitiveContract : Newtonsoft.Json.Serialization.JsonContract`

Contract details for a used by the .

#### Methods

| Signature | Description |
|-----------|-------------|
| `JsonPrimitiveContract(System.Type underlyingType)` | Initializes a new instance of the class. |

---

### `class JsonProperty`

Maps a JSON property to a .NET member or constructor parameter.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `PropertyName` | `string` | Gets or sets the name of the property. |
| `DeclaringType` | `System.Type` | Gets or sets the type that declared this property. |
| `Order` | `System.Nullable<int>` | Gets or sets the order of serialization of a member. |
| `UnderlyingName` | `string` | Gets or sets the name of the underlying member or parameter. |
| `ValueProvider` | `Newtonsoft.Json.Serialization.IValueProvider` | Gets the that will get and set the during serialization. |
| `AttributeProvider` | `Newtonsoft.Json.Serialization.IAttributeProvider` | Gets or sets the for this property. |
| `PropertyType` | `System.Type` | Gets or sets the type of the property. |
| `Converter` | `Newtonsoft.Json.JsonConverter` | Gets or sets the for the property. If set this converter takes precedence over the contract converter for the property type. |
| `MemberConverter` | `Newtonsoft.Json.JsonConverter` | Gets or sets the member converter. |
| `Ignored` | `bool` | Gets or sets a value indicating whether this is ignored. |
| `Readable` | `bool` | Gets or sets a value indicating whether this is readable. |
| `Writable` | `bool` | Gets or sets a value indicating whether this is writable. |
| `HasMemberAttribute` | `bool` | Gets or sets a value indicating whether this has a member attribute. |
| `DefaultValue` | `object` | Gets the default value. |
| `Required` | `Newtonsoft.Json.Required` | Gets or sets a value indicating whether this is required. |
| `IsRequiredSpecified` | `bool` | Gets a value indicating whether has a value specified. |
| `IsReference` | `System.Nullable<bool>` | Gets or sets a value indicating whether this property preserves object references. |
| `NullValueHandling` | `System.Nullable<Newtonsoft.Json.NullValueHandling>` | Gets or sets the property null value handling. |
| `DefaultValueHandling` | `System.Nullable<Newtonsoft.Json.DefaultValueHandling>` | Gets or sets the property default value handling. |
| `ReferenceLoopHandling` | `System.Nullable<Newtonsoft.Json.ReferenceLoopHandling>` | Gets or sets the property reference loop handling. |
| `ObjectCreationHandling` | `System.Nullable<Newtonsoft.Json.ObjectCreationHandling>` | Gets or sets the property object creation handling. |
| `TypeNameHandling` | `System.Nullable<Newtonsoft.Json.TypeNameHandling>` | Gets or sets or sets the type name handling. |
| `ShouldSerialize` | `System.Predicate<object>` | Gets or sets a predicate used to determine whether the property should be serialized. |
| `ShouldDeserialize` | `System.Predicate<object>` | Gets or sets a predicate used to determine whether the property should be deserialized. |
| `GetIsSpecified` | `System.Predicate<object>` | Gets or sets a predicate used to determine whether the property should be serialized. |
| `SetIsSpecified` | `System.Action<object, object>` | Gets or sets an action used to set whether the property has been deserialized. |
| `ItemConverter` | `Newtonsoft.Json.JsonConverter` | Gets or sets the converter used when serializing the property's collection items. |
| `ItemIsReference` | `System.Nullable<bool>` | Gets or sets whether this property's collection items are serialized as a reference. |
| `ItemTypeNameHandling` | `System.Nullable<Newtonsoft.Json.TypeNameHandling>` | Gets or sets the type name handling used when serializing the property's collection items. |
| `ItemReferenceLoopHandling` | `System.Nullable<Newtonsoft.Json.ReferenceLoopHandling>` | Gets or sets the reference loop handling used when serializing the property's collection items. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `string get_PropertyName()` |  |
| `void set_PropertyName(string value)` |  |
| `System.Type get_DeclaringType()` |  |
| `void set_DeclaringType(System.Type value)` |  |
| `System.Nullable<int> get_Order()` |  |
| `void set_Order(System.Nullable<int> value)` |  |
| `string get_UnderlyingName()` |  |
| `void set_UnderlyingName(string value)` |  |
| `Newtonsoft.Json.Serialization.IValueProvider get_ValueProvider()` |  |
| `void set_ValueProvider(Newtonsoft.Json.Serialization.IValueProvider value)` |  |
| `Newtonsoft.Json.Serialization.IAttributeProvider get_AttributeProvider()` |  |
| `void set_AttributeProvider(Newtonsoft.Json.Serialization.IAttributeProvider value)` |  |
| `System.Type get_PropertyType()` |  |
| `void set_PropertyType(System.Type value)` |  |
| `Newtonsoft.Json.JsonConverter get_Converter()` |  |
| `void set_Converter(Newtonsoft.Json.JsonConverter value)` |  |
| `Newtonsoft.Json.JsonConverter get_MemberConverter()` |  |
| `void set_MemberConverter(Newtonsoft.Json.JsonConverter value)` |  |
| `bool get_Ignored()` |  |
| `void set_Ignored(bool value)` |  |
| `bool get_Readable()` |  |
| `void set_Readable(bool value)` |  |
| `bool get_Writable()` |  |
| `void set_Writable(bool value)` |  |
| `bool get_HasMemberAttribute()` |  |
| `void set_HasMemberAttribute(bool value)` |  |
| `object get_DefaultValue()` |  |
| `void set_DefaultValue(object value)` |  |
| `Newtonsoft.Json.Required get_Required()` |  |
| `void set_Required(Newtonsoft.Json.Required value)` |  |
| `bool get_IsRequiredSpecified()` |  |
| `System.Nullable<bool> get_IsReference()` |  |
| `void set_IsReference(System.Nullable<bool> value)` |  |
| `System.Nullable<Newtonsoft.Json.NullValueHandling> get_NullValueHandling()` |  |
| `void set_NullValueHandling(System.Nullable<Newtonsoft.Json.NullValueHandling> value)` |  |
| `System.Nullable<Newtonsoft.Json.DefaultValueHandling> get_DefaultValueHandling()` |  |
| `void set_DefaultValueHandling(System.Nullable<Newtonsoft.Json.DefaultValueHandling> value)` |  |
| `System.Nullable<Newtonsoft.Json.ReferenceLoopHandling> get_ReferenceLoopHandling()` |  |
| `void set_ReferenceLoopHandling(System.Nullable<Newtonsoft.Json.ReferenceLoopHandling> value)` |  |
| `System.Nullable<Newtonsoft.Json.ObjectCreationHandling> get_ObjectCreationHandling()` |  |
| `void set_ObjectCreationHandling(System.Nullable<Newtonsoft.Json.ObjectCreationHandling> value)` |  |
| `System.Nullable<Newtonsoft.Json.TypeNameHandling> get_TypeNameHandling()` |  |
| `void set_TypeNameHandling(System.Nullable<Newtonsoft.Json.TypeNameHandling> value)` |  |
| `System.Predicate<object> get_ShouldSerialize(? )` |  |
| `void set_ShouldSerialize(System.Predicate<object> value)` |  |
| `System.Predicate<object> get_ShouldDeserialize(? )` |  |
| `void set_ShouldDeserialize(System.Predicate<object> value)` |  |
| `System.Predicate<object> get_GetIsSpecified(? )` |  |
| `void set_GetIsSpecified(System.Predicate<object> value)` |  |
| `System.Action<object, object> get_SetIsSpecified(? )` |  |
| `void set_SetIsSpecified(System.Action<object, object> value)` |  |
| `virtual string ToString()` | Returns a that represents this instance. |
| `Newtonsoft.Json.JsonConverter get_ItemConverter()` |  |
| `void set_ItemConverter(Newtonsoft.Json.JsonConverter value)` |  |
| `System.Nullable<bool> get_ItemIsReference()` |  |
| `void set_ItemIsReference(System.Nullable<bool> value)` |  |
| `System.Nullable<Newtonsoft.Json.TypeNameHandling> get_ItemTypeNameHandling()` |  |
| `void set_ItemTypeNameHandling(System.Nullable<Newtonsoft.Json.TypeNameHandling> value)` |  |
| `System.Nullable<Newtonsoft.Json.ReferenceLoopHandling> get_ItemReferenceLoopHandling()` |  |
| `void set_ItemReferenceLoopHandling(System.Nullable<Newtonsoft.Json.ReferenceLoopHandling> value)` |  |
| `JsonProperty()` |  |

---

### `class JsonPropertyCollection`

A collection of objects.

#### Methods

| Signature | Description |
|-----------|-------------|
| `JsonPropertyCollection(System.Type type)` | Initializes a new instance of the class. |
| `virtual string GetKeyForItem(Newtonsoft.Json.Serialization.JsonProperty item)` | When implemented in a derived class, extracts the key from the specified element. |
| `void AddProperty(Newtonsoft.Json.Serialization.JsonProperty property)` | Adds a object. |
| `Newtonsoft.Json.Serialization.JsonProperty GetClosestMatchProperty(string , ? propertyName)` | Gets the closest matching object. First attempts to get an exact case match of and then a case insensitive match. |
| `Newtonsoft.Json.Serialization.JsonProperty GetProperty(string , System.StringComparison propertyName, ? comparisonType)` | Gets a property by property name. |

---

### `class JsonStringContract : Newtonsoft.Json.Serialization.JsonPrimitiveContract`

Contract details for a used by the .

#### Methods

| Signature | Description |
|-----------|-------------|
| `JsonStringContract(System.Type underlyingType)` | Initializes a new instance of the class. |

---

### `class KebabCaseNamingStrategy : Newtonsoft.Json.Serialization.NamingStrategy`

A kebab case naming strategy.

#### Methods

| Signature | Description |
|-----------|-------------|
| `KebabCaseNamingStrategy(bool processDictionaryKeys, bool overrideSpecifiedNames)` | Initializes a new instance of the class. |
| `KebabCaseNamingStrategy(bool processDictionaryKeys, bool overrideSpecifiedNames, bool processExtensionDataNames)` | Initializes a new instance of the class. |
| `KebabCaseNamingStrategy()` | Initializes a new instance of the class. |
| `virtual string ResolvePropertyName(string name)` | Resolves the specified property name. |

---

### `class MemoryTraceWriter : Newtonsoft.Json.Serialization.ITraceWriter`

Represents a trace writer that writes to memory. When the trace message limit is reached then old trace messages will be removed as new messages are added.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `LevelFilter` | `System.Diagnostics.TraceLevel` | Gets the that will be used to filter the trace messages passed to the writer. For example a filter level of will exclude messages and include , and messages. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `virtual System.Diagnostics.TraceLevel get_LevelFilter()` |  |
| `void set_LevelFilter(System.Diagnostics.TraceLevel value)` |  |
| `MemoryTraceWriter()` | Initializes a new instance of the class. |
| `virtual void Trace(System.Diagnostics.TraceLevel level, string message, System.Exception ex)` | Writes the specified trace level, message and optional exception. |
| `System.Collections.Generic.IEnumerable<string> GetTraceMessages()` | Returns an enumeration of the most recent trace messages. |
| `virtual string ToString()` | Returns a of the most recent trace messages. |

---

### `abstract class NamingStrategy`

A base class for resolving how property names and dictionary keys are serialized.

#### Properties

| Name | Type | Description |
|------|------|-------------|
| `ProcessDictionaryKeys` | `bool` | A flag indicating whether dictionary keys should be processed. Defaults to false. |
| `ProcessExtensionDataNames` | `bool` | A flag indicating whether extension data names should be processed. Defaults to false. |
| `OverrideSpecifiedNames` | `bool` | A flag indicating whether explicitly specified property names, e.g. a property name customized with a , should be processed. Defaults to false. |

#### Methods

| Signature | Description |
|-----------|-------------|
| `bool get_ProcessDictionaryKeys()` |  |
| `void set_ProcessDictionaryKeys(bool value)` |  |
| `bool get_ProcessExtensionDataNames()` |  |
| `void set_ProcessExtensionDataNames(bool value)` |  |
| `bool get_OverrideSpecifiedNames()` |  |
| `void set_OverrideSpecifiedNames(bool value)` |  |
| `virtual string GetPropertyName(string name, bool hasSpecifiedName)` | Gets the serialized name for a given property name. |
| `virtual string GetExtensionDataName(string name)` | Gets the serialized name for a given extension data name. |
| `virtual string GetDictionaryKey(string key)` | Gets the serialized key for a given dictionary key. |
| `abstract string ResolvePropertyName(string name)` | Resolves the specified property name. |
| `virtual int GetHashCode()` | Hash code calculation |
| `virtual bool Equals(object obj)` | Object equality implementation |
| `bool Equals(Newtonsoft.Json.Serialization.NamingStrategy other)` | Compare to another NamingStrategy |
| `NamingStrategy()` |  |

---

### `sealed delegate ObjectConstructor`1<T> : System.MulticastDelegate`

Represents a method that constructs an object.

#### Methods

| Signature | Description |
|-----------|-------------|
| `ObjectConstructor`1(object object, nint method)` |  |
| `virtual object Invoke(object[] args)` |  |
| `virtual System.IAsyncResult BeginInvoke(object[] args, System.AsyncCallback callback, object object)` |  |
| `virtual object EndInvoke(System.IAsyncResult , ? result)` |  |

---

### `sealed class OnErrorAttribute : System.Attribute`

When applied to a method, specifies that the method is called when an error occurs serializing an object.

#### Methods

| Signature | Description |
|-----------|-------------|
| `OnErrorAttribute()` |  |

---

### `class ReflectionAttributeProvider : Newtonsoft.Json.Serialization.IAttributeProvider`

Provides methods to get attributes from a , , or .

#### Methods

| Signature | Description |
|-----------|-------------|
| `ReflectionAttributeProvider(object attributeProvider)` | Initializes a new instance of the class. |
| `virtual System.Collections.Generic.IList<System.Attribute> GetAttributes(bool inherit)` | Returns a collection of all of the attributes, or an empty collection if there are no attributes. |
| `virtual System.Collections.Generic.IList<System.Attribute> GetAttributes(System.Type attributeType, bool inherit)` | Returns a collection of attributes, identified by type, or an empty collection if there are no attributes. |

---

### `class ReflectionValueProvider : Newtonsoft.Json.Serialization.IValueProvider`

Get and set values for a using reflection.

#### Methods

| Signature | Description |
|-----------|-------------|
| `ReflectionValueProvider(System.Reflection.MemberInfo memberInfo)` | Initializes a new instance of the class. |
| `virtual void SetValue(object target, object value)` | Sets the value. |
| `virtual object GetValue(object , ? target)` | Gets the value. |

---

### `sealed delegate SerializationCallback : System.MulticastDelegate`

Handles serialization callback events.

#### Methods

| Signature | Description |
|-----------|-------------|
| `SerializationCallback(object object, nint method)` |  |
| `virtual void Invoke(object o, System.Runtime.Serialization.StreamingContext context)` |  |
| `virtual System.IAsyncResult BeginInvoke(object o, System.Runtime.Serialization.StreamingContext context, System.AsyncCallback callback, object object)` |  |
| `virtual void EndInvoke(System.IAsyncResult result)` |  |

---

### `sealed delegate SerializationErrorCallback : System.MulticastDelegate`

Handles serialization error callback events.

#### Methods

| Signature | Description |
|-----------|-------------|
| `SerializationErrorCallback(object object, nint method)` |  |
| `virtual void Invoke(object o, System.Runtime.Serialization.StreamingContext context, Newtonsoft.Json.Serialization.ErrorContext errorContext)` |  |
| `virtual System.IAsyncResult BeginInvoke(object o, System.Runtime.Serialization.StreamingContext context, Newtonsoft.Json.Serialization.ErrorContext errorContext, System.AsyncCallback callback, object object)` |  |
| `virtual void EndInvoke(System.IAsyncResult result)` |  |

---

### `class SnakeCaseNamingStrategy : Newtonsoft.Json.Serialization.NamingStrategy`

A snake case naming strategy.

#### Methods

| Signature | Description |
|-----------|-------------|
| `SnakeCaseNamingStrategy(bool processDictionaryKeys, bool overrideSpecifiedNames)` | Initializes a new instance of the class. |
| `SnakeCaseNamingStrategy(bool processDictionaryKeys, bool overrideSpecifiedNames, bool processExtensionDataNames)` | Initializes a new instance of the class. |
| `SnakeCaseNamingStrategy()` | Initializes a new instance of the class. |
| `virtual string ResolvePropertyName(string name)` | Resolves the specified property name. |

---


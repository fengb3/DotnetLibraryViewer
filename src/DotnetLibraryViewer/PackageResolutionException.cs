namespace DotnetLibraryViewer;

public sealed class PackageResolutionException : Exception
{
    public PackageResolutionException(string message) : base(message) { }
    public PackageResolutionException(string message, Exception inner) : base(message, inner) { }
}

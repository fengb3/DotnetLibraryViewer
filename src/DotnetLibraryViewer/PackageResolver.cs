using System.Diagnostics;

namespace DotnetLibraryViewer;

public sealed record ResolvedPackage(string DllPath, string? XmlPath);

public static class PackageResolver
{
    private static readonly string[] TfmPriority =
    [
        "net10.0", "net9.0", "net8.0", "net7.0", "net6.0",
        "netstandard2.1", "netstandard2.0", "netstandard1.0"
    ];

    public static async Task<ResolvedPackage> ResolveFromNuGetAsync(
        string packageName, string? version, string? framework, CancellationToken ct)
    {
        var tempDir = Path.Combine(Path.GetTempPath(), $"dlv-{Guid.NewGuid():N}");
        Directory.CreateDirectory(tempDir);

        try
        {
            // Create a temp project to restore the package
            var projectName = "dlv-temp";
            await RunDotnetAsync($"new console --name {projectName} --force -o \"{tempDir}\"", ct);
            await RunDotnetAsync($"add \"{Path.Combine(tempDir, projectName + ".csproj")}\" package {packageName}{(version is not null ? $" --version {version}" : "")}", ct);
            await RunDotnetAsync($"restore \"{Path.Combine(tempDir, projectName + ".csproj")}\"", ct);

            // Find the package in the NuGet global cache
            var cachePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                ".nuget", "packages", packageName.ToLowerInvariant());

            if (!Directory.Exists(cachePath))
                throw new InvalidOperationException($"Package not found in cache: {packageName}");

            var resolvedVersion = version ?? FindLatestVersion(cachePath);
            if (resolvedVersion is null)
                throw new InvalidOperationException($"No version found for package: {packageName}");

            var pkgDir = Path.Combine(cachePath, resolvedVersion);
            var libDir = Path.Combine(pkgDir, "lib");

            // Find the best TFM
            var bestTfm = FindBestTfm(libDir, framework);
            if (bestTfm is null)
                throw new InvalidOperationException($"No compatible assembly found for package: {packageName}");

            var tfmDir = Path.Combine(libDir, bestTfm);

            // Find DLL and XML
            var dllPath = Directory.GetFiles(tfmDir, "*.dll").FirstOrDefault()
                ?? throw new FileNotFoundException($"No DLL found in {tfmDir}");
            var xmlPath = Directory.GetFiles(tfmDir, "*.xml").FirstOrDefault();

            return new ResolvedPackage(dllPath, xmlPath);
        }
        finally
        {
            try { Directory.Delete(tempDir, true); } catch { }
        }
    }

    public static ResolvedPackage ResolveFromLocalPath(string dllPath, string? xmlPath)
    {
        if (!File.Exists(dllPath))
            throw new FileNotFoundException($"DLL not found: {dllPath}");
        return new ResolvedPackage(dllPath, xmlPath);
    }

    private static async Task RunDotnetAsync(string arguments, CancellationToken ct)
    {
        using var process = Process.Start(new ProcessStartInfo("dotnet", arguments)
        {
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        }) ?? throw new InvalidOperationException("Failed to start dotnet process");

        await process.WaitForExitAsync(ct);
        if (process.ExitCode != 0)
        {
            var error = await process.StandardError.ReadToEndAsync(ct);
            throw new InvalidOperationException($"dotnet failed: {error}");
        }
    }

    private static string? FindLatestVersion(string cachePath)
    {
        var versions = Directory.GetDirectories(cachePath)
            .Select(d => Path.GetFileName(d))
            .Where(v => !v.StartsWith("."))
            .OrderByDescending(v => v, StringComparer.OrdinalIgnoreCase)
            .FirstOrDefault();
        return versions;
    }

    private static string? FindBestTfm(string libDir, string? preferredTfm)
    {
        if (!Directory.Exists(libDir))
            return null;

        var availableTfms = Directory.GetDirectories(libDir)
            .Select(d => Path.GetFileName(d))
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        // If user specified a TFM, use it if available
        if (preferredTfm is not null && availableTfms.Contains(preferredTfm))
            return preferredTfm;

        // Otherwise pick the best available
        foreach (var tfm in TfmPriority)
        {
            if (availableTfms.Contains(tfm))
                return tfm;
        }

        // Fallback: return first available
        return availableTfms.FirstOrDefault();
    }
}

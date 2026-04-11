using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DotnetLibraryViewer;

[JsonSerializable(typeof(JsonElement))]
internal partial class NuGetVersionsContext : JsonSerializerContext;

internal static class UpdateChecker
{
    private static readonly string? CacheDir = InitCacheDir();

    private static string? InitCacheDir()
    {
        var profile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        return string.IsNullOrEmpty(profile) ? null : Path.Combine(profile, ".dotnet-lib-view");
    }

    private static string? LastCheckFile => CacheDir is null ? null : Path.Combine(CacheDir, "last-update-check");

    private const string NuGetVersionsUrl =
        "https://api.nuget.org/v3-flatcontainer/dotnetlibraryviewer/index.json";

    /// <summary>
    /// Checks for updates in a fire-and-forget manner. Never blocks or throws.
    /// </summary>
    public static void CheckForUpdate()
    {
        _ = Task.Run(async () =>
        {
            try
            {
                await CheckForUpdateCoreAsync();
            }
            catch
            {
                // Silently ignore all errors — never block the CLI
            }
        });
    }

    private static async Task CheckForUpdateCoreAsync()
    {
        if (CacheDir is null || LastCheckFile is null) return;

        var today = DateOnly.FromDateTime(DateTime.Now);

        // Fast path: already checked today
        if (File.Exists(LastCheckFile))
        {
            var lastCheck = await File.ReadAllTextAsync(LastCheckFile);
            if (DateOnly.TryParse(lastCheck.Trim(), out var lastDate) && lastDate == today)
                return;
        }

        // Record today's check date immediately to avoid repeated attempts on failure
        Directory.CreateDirectory(CacheDir);
        await File.WriteAllTextAsync(LastCheckFile, today.ToString("yyyy-MM-dd"));

        // Get current version
        var currentVersion = Assembly.GetEntryAssembly()?.GetName().Version;
        if (currentVersion is null) return;

        // Query NuGet for latest version
        using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(3) };
        http.DefaultRequestHeaders.Add("User-Agent", "dotnet-lib-view-update-check");

        var response = await http.GetStringAsync(NuGetVersionsUrl);
        var json = JsonSerializer.Deserialize(response, NuGetVersionsContext.Default.JsonElement);

        if (!json.TryGetProperty("versions", out var versionsArr)) return;

        // Filter to stable versions (no hyphens) and take the latest
        var latestVersionStr = versionsArr.EnumerateArray()
            .Select(e => e.ValueKind == JsonValueKind.String ? e.GetString() : null)
            .Where(v => v is not null && !v.Contains('-'))
            .LastOrDefault();

        if (latestVersionStr is null) return;
        if (!Version.TryParse(latestVersionStr, out var latestVersion)) return;

        // Compare versions
        if (latestVersion > currentVersion)
        {
            var fg = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Error.WriteLine($"A new version of dotnet-lib-view is available: {latestVersionStr} (current: {currentVersion})");
            Console.Error.WriteLine("Update with: dotnet tool update -g DotnetLibraryViewer");
            Console.ForegroundColor = fg;
        }
    }
}

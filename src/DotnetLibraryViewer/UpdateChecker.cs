using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DotnetLibraryViewer;

[JsonSerializable(typeof(JsonElement))]
internal partial class NuGetVersionsContext : JsonSerializerContext;

internal static class UpdateChecker
{
    private static readonly string CacheDir = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
        ".dotnet-lib-view");

    private static readonly string LastCheckFile = Path.Combine(CacheDir, "last-update-check");

    private const string NuGetVersionsUrl =
        "https://api.nuget.org/v3-flatcontainer/dotnetlibraryviewer/index.json";

    public static async Task CheckForUpdateAsync()
    {
        try
        {
            var today = DateOnly.FromDateTime(DateTime.Now);

            // Fast path: already checked today
            if (File.Exists(LastCheckFile))
            {
                var lastCheck = await File.ReadAllTextAsync(LastCheckFile);
                if (DateOnly.TryParse(lastCheck.Trim(), out var lastDate) && lastDate == today)
                    return;
            }

            // Get current version
            var currentVersion = Assembly.GetEntryAssembly()?.GetName().Version;
            if (currentVersion is null) return;

            // Query NuGet for latest version
            using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(3) };
            http.DefaultRequestHeaders.Add("User-Agent", "dotnet-lib-view-update-check");

            var response = await http.GetStringAsync(NuGetVersionsUrl);
            var json = JsonSerializer.Deserialize(response, NuGetVersionsContext.Default.JsonElement);

            if (!json.TryGetProperty("versions", out var versionsArr)) return;

            // Take the last version as the latest
            var latestVersionStr = versionsArr.EnumerateArray().LastOrDefault().GetString();
            if (latestVersionStr is null) return;

            if (!Version.TryParse(latestVersionStr, out var latestVersion)) return;

            // Save check date
            Directory.CreateDirectory(CacheDir);
            await File.WriteAllTextAsync(LastCheckFile, today.ToString("yyyy-MM-dd"));

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
        catch
        {
            // Silently ignore all errors — never block the CLI
        }
    }
}

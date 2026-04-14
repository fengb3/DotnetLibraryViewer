using System.Text.Json;
using System.Text.Json.Serialization;

namespace DotnetLibraryViewer;

[JsonSerializable(typeof(JsonElement))]
internal partial class NuGetSearchContext : JsonSerializerContext;

public sealed record NuGetPackageResult(
    string Id,
    string? Description,
    long TotalDownloads,
    string Version
);

public static class NuGetSearchClient
{
    private const string SearchUrl = "https://azuresearch-usnc.nuget.org/query";

    public static async Task<IReadOnlyList<NuGetPackageResult>> SearchAsync(
        string query, int take = 20, CancellationToken ct = default)
    {
        using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(10) };
        http.DefaultRequestHeaders.Add("User-Agent", "dotnet-lib-view-package-search");

        var url = $"{SearchUrl}?q={Uri.EscapeDataString(query)}&take={take}";
        var response = await http.GetStringAsync(url, ct);

        var json = JsonSerializer.Deserialize(response, NuGetSearchContext.Default.JsonElement);

        if (json.ValueKind != JsonValueKind.Object) return [];
        if (!json.TryGetProperty("data", out var dataArr)) return [];
        if (dataArr.ValueKind != JsonValueKind.Array) return [];

        var results = new List<NuGetPackageResult>();
        foreach (var item in dataArr.EnumerateArray())
        {
            var id = item.TryGetProperty("id", out var idProp) ? idProp.GetString() ?? "" : "";
            var description = item.TryGetProperty("description", out var descProp) ? descProp.GetString() : null;
            var downloads = item.TryGetProperty("totalDownloads", out var dlProp) && dlProp.ValueKind == JsonValueKind.Number
                ? dlProp.GetInt64() : 0;
            var version = item.TryGetProperty("version", out var verProp) ? verProp.GetString() ?? "" : "";

            results.Add(new NuGetPackageResult(id, description, downloads, version));
        }

        return results;
    }
}

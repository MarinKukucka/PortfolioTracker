using System.Text.Json;

namespace PortfolioTrackerAPI.Infrastructure.Services.ApiServices
{
    public abstract class BaseApiClient(HttpClient httpClient)
    {
        protected readonly HttpClient _httpClient = httpClient;
        protected static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        protected async Task<T?> GetAsync<T>(string relativeUri, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync(relativeUri, cancellationToken);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<T>(json, _jsonOptions);
        }
    }
}

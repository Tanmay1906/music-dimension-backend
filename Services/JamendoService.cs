using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System;

public class JamendoService
{
    private readonly HttpClient _httpClient;
    private readonly string _clientId;

    public JamendoService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _clientId = config["Jamendo:ClientId"] ?? throw new ArgumentNullException(nameof(config), "Jamendo:ClientId configuration is missing");
        _httpClient.BaseAddress = new Uri("https://api.jamendo.com/v3.0/");
    }

    public async Task<string> SearchTracks(string query, int limit = 20)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            throw new ArgumentException("Query cannot be empty", nameof(query));
        }

        var response = await _httpClient.GetAsync($"tracks/?client_id={_clientId}&format=json&search={query}&limit={limit}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GetPopularTracks(int limit = 20)
    {
        var response = await _httpClient.GetAsync($"tracks/?client_id={_clientId}&format=json&order=popularity_total&limit={limit}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}
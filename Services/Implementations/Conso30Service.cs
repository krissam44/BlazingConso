using BlazingConso.Entities;
using BlazingConso.Services.Interfaces;
using System.Text.Json;

namespace BlazingConso.Services.Implementations;

public class Conso30Service : IConso30Service
{
    private readonly HttpClient client;

    public Conso30Service(IHttpClientFactory httpClientFactory)
    {
        client = httpClientFactory.CreateClient("ConsommationClient");

        if (client.BaseAddress == null)
            throw new InvalidOperationException("HttpClient BaseAddress est null !");
    }


    // -----------------------------------------------------------------------------------------------------------------
    public async Task<List<Conso30>> GetConso30Today()
    {
        var response = await client.GetAsync("conso30Today");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var conso30Today = JsonSerializer.Deserialize<List<Conso30>>(json);

            if (conso30Today == null)
                throw new InvalidOperationException("Impossible de désérialiser la réponse JSON en ConsoDay.");

            return conso30Today;
        }

        throw new HttpRequestException("La requête API a échoué.");
    }

}

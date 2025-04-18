using BlazingConso.Entities;
using BlazingConso.Services.Interfaces;
using System.Text.Json;

namespace BlazingConso.Services.Implementations;

public class InfosCoutsService : IInfosCoutsService
{
    private readonly HttpClient client;

    // -----------------------------------------------------------------------------------------------------------------
    public InfosCoutsService(IHttpClientFactory httpClientFactory)
    {
        client = httpClientFactory.CreateClient("ConsommationClient");

        if (client.BaseAddress == null)
            throw new InvalidOperationException("HttpClient BaseAddress est null !");

    }

    // -----------------------------------------------------------------------------------------------------------------
    public async Task<InfoCout> GetInfoCouts()
    {
        var response = await client.GetAsync("infoCouts");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var infoCout = JsonSerializer.Deserialize<InfoCout>(json);
            return infoCout;
        }
        else
        {
            // Gérer l'erreur ici
            return null;
        }
    }
}

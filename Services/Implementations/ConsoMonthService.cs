using BlazingConso.Entities;
using BlazingConso.Services.Interfaces;
using System.Text.Json;

namespace BlazingConso.Services.Implementations;

public class ConsoMonthService : IConsoMonthService
{
    private readonly HttpClient client;
    private readonly ILogger<ConsoMonthService> logger;

    public ConsoMonthService(IHttpClientFactory httpClientFactory, ILogger<ConsoMonthService> logger)
    {
        client = httpClientFactory.CreateClient("ConsommationClient");

        if (client.BaseAddress == null)
            throw new InvalidOperationException("HttpClient BaseAddress est null !");
        this.logger = logger;
    }

    // -----------------------------------------------------------------------------------------------------------------
    // Récupère la consommation mensuelle sur une période
    // -----------------------------------------------------------------------------------------------------------------
    public async Task<List<ConsoMonth>> GetConsoMonthsOfYearAsync(int startMonth, int startYear, int endMonth, int endYear)
    {
        string query = $"consoMonthPeriod?startMonth={startMonth}&startYear={startYear}&endMonth={endMonth}&endYear={endYear}";
        
        var response = await client.GetAsync(query);
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();

            // ----- Vérifie si la réponse est vide ou uniquement des espaces
            if (string.IsNullOrWhiteSpace(json))
            {
                logger.LogInformation("Réponse API vide, retour d'une liste vide.");
                return new List<ConsoMonth>();
            }
            var consoMonths = JsonSerializer.Deserialize<List<ConsoMonth>>(json);
            if (consoMonths == null)
                throw new InvalidOperationException("Impossible de désérialiser la réponse JSON en ConsoMonth.");
            return consoMonths;
        }
        throw new HttpRequestException("La requête API a échoué.");
    }

    // -----------------------------------------------------------------------------------------------------------------
    // Récupère la consommation du mois en cours
    // -----------------------------------------------------------------------------------------------------------------
    public async Task<List<ConsoMonth>> GetConsoMonthsOfYearAsync(int year)
    {
        string query = $"consomonthsofyear?yearSearch={year}";

        var response = await client.GetAsync(query);
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            // ----- Vérifie si la réponse est vide ou uniquement des espaces
            if (string.IsNullOrWhiteSpace(json))
            {
                logger.LogInformation("Réponse API vide, retour d'une liste vide.");
                return new List<ConsoMonth>();
            }
            var consoMonths = JsonSerializer.Deserialize<List<ConsoMonth>>(json);
            if (consoMonths == null)
                throw new InvalidOperationException("Impossible de désérialiser la réponse JSON en ConsoMonth.");
            return consoMonths;
        }
        throw new HttpRequestException("La requête API a échoué.");
    }


}

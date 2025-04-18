using System.Text.Json;
using BlazingConso.Entities;
using BlazingConso.Services.Interfaces;

namespace BlazingConso.Services.Implementations;

public class ConsoDayService : IConsoDayService
{
    private readonly HttpClient client;
    private readonly ILogger<ConsoDayService> logger;

    public ConsoDayService(IHttpClientFactory httpClientFactory, ILogger<ConsoDayService> logger)
    {
        client = httpClientFactory.CreateClient("ConsommationClient");

        if (client.BaseAddress == null)
            throw new InvalidOperationException("HttpClient BaseAddress est null !");
        this.logger = logger;
    }


    // -----------------------------------------------------------------------------------------------------------------
    public async Task<ConsoDay> GetConsoToday()
    {
        var response = await client.GetAsync("consotoday");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var consoToday = JsonSerializer.Deserialize<ConsoDay>(json);

            if (consoToday == null)
                throw new InvalidOperationException("Impossible de désérialiser la réponse JSON en ConsoDay.");

            return consoToday;
        }

        throw new HttpRequestException("La requête API a échoué.");
    }


    // -----------------------------------------------------------------------------------------------------------------
    public async Task<List<ConsoDay>> GetConsoDaysOfMonthAsync(int month, int year)
    {
        string query = $"consodaysamonth?monthSearch={month}&yearSearch={year}";

        var response = await client.GetAsync(query);

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();

            // Vérifie si la réponse est vide ou uniquement des espaces
            if (string.IsNullOrWhiteSpace(json))
            {
                logger.LogInformation("Réponse API vide, retour d'une liste vide.");
                return new List<ConsoDay>();
            }

            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                return JsonSerializer.Deserialize<List<ConsoDay>>(json, options) ?? new List<ConsoDay>();
            }
            catch (JsonException ex)
            {
                logger.LogError(ex, "Erreur de désérialisation JSON");
                return new List<ConsoDay>();
            }
        }
        else
        {
            logger.LogWarning("Erreur API : {StatusCode}", response.StatusCode);
            return new List<ConsoDay>();
        }
    }


    // ------------------------------------------------------------------------------------------------------
    public async Task<List<ConsoDay>> GetConsoDaysPeriod(DateTime? startDate, DateTime? endDate)
    {
        // ----- Conversion des dates en string pour l'appel API
        string dateStart = startDate.Value.ToString("dd/MM/yyyy");
        string dateEnd = endDate.Value.ToString("dd/MM/yyyy");

        var response = await client.GetAsync($"consoDaysPeriod?dateStart={dateStart}&dateEnd={dateEnd}");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();       

            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var consoDays = JsonSerializer.Deserialize<List<ConsoDay>>(json, options);
                return consoDays ?? new List<ConsoDay>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Erreur de désérialisation : {ex.Message}");
                return new List<ConsoDay>();
            }
        }
        else
        {
            Console.WriteLine($"Erreur API : {response.StatusCode}");
            return new List<ConsoDay>();
        }
    }


    // -----------------------------------------------------------------------------------------------------------------
    public async Task<ConsoMonth> GetConsoCurrentMonth()
    {
        var response = await client.GetAsync("consoCurrentMonth");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            logger.LogInformation("Réponse API : {Json}", json);

            var consoCurrentMonth = JsonSerializer.Deserialize<ConsoMonth>(json);
            return consoCurrentMonth;
        }
        else
        {
            // Gérer l'erreur ici
            return null;
        }
    }

}
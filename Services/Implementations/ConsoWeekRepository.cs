using BlazingConso.Entities;
using BlazingConso.Services.Interfaces;
using System.Text.Json;

namespace BlazingConso.Services.Implementations
{
    public class ConsoWeekRepository : IConsoWeekRepository
    {
        private readonly HttpClient client;
        private readonly ILogger<ConsoMonthService> logger;


        // -----------------------------------------------------------------------------------------------------------------
        public ConsoWeekRepository(IHttpClientFactory httpClientFactory, ILogger<ConsoMonthService> logger)
        {
            client = httpClientFactory.CreateClient("ConsommationClient");

            if (client.BaseAddress == null)
                throw new InvalidOperationException("HttpClient BaseAddress est null !");
            this.logger = logger;
        }

        // -----------------------------------------------------------------------------------------------------------------
        // Récupère la consommation hebdomadaire sur une période
        // -----------------------------------------------------------------------------------------------------------------
        public async Task<List<ConsoWeek>> GetConsoWeeksAsync(int startWeek, int endWeek, int year)
        {
            string query = $"consoWeek?startWeek={startWeek}&endWeek={endWeek}&year={year}";

            var response = await client.GetAsync(query);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                // ----- Vérifie si la réponse est vide ou uniquement des espaces
                if (string.IsNullOrWhiteSpace(json))
                {
                    logger.LogInformation("Réponse API vide, retour d'une liste vide.");
                    return new List<ConsoWeek>();
                }
                var consoWeeks = JsonSerializer.Deserialize<List<ConsoWeek>>(json);
                if (consoWeeks == null)
                    throw new InvalidOperationException("Impossible de désérialiser la réponse JSON en ConsoMonth.");
                return consoWeeks;
            }
            throw new HttpRequestException("La requête API a échoué.");
        }

    }
}
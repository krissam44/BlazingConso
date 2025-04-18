using BlazingConso.Entities;
using BlazingConso.Services.Interfaces;
using System.Text.Json;

namespace BlazingConso.Services.Implementations
{
    public class InfosConsoService : IInfosConsoService
    {
        private readonly HttpClient client;
        private readonly ILogger<InfosConsoService> logger;

        // -----------------------------------------------------------------------------------------------------------------
        public InfosConsoService(IHttpClientFactory httpClientFactory, ILogger<InfosConsoService> logger)
        {
            client = httpClientFactory.CreateClient("ConsommationClient");

            if (client.BaseAddress == null)
                throw new InvalidOperationException("HttpClient BaseAddress est null !");

        }

        // -----------------------------------------------------------------------------------------------------------------
        public async Task<InfoLinky> GetInfoLinky()
        {
            var response = await client.GetAsync("infoLinky");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var infoLinky = JsonSerializer.Deserialize<InfoLinky>(json);
                return infoLinky;
            }
            else
            {
                // Gérer l'erreur ici
                return null;
            }
        }

        // -----------------------------------------------------------------------------------------------------------------
        public async Task<ConsoResume> GetConsoResume()
        {
            var response = await client.GetAsync("consoResume");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var consoResume = JsonSerializer.Deserialize<ConsoResume>(json);
                return consoResume;
            }
            else
            {
                // Gérer l'erreur ici
                return null;
            }
        }


        // -----------------------------------------------------------------------------------------------------------------
        public async Task<List<ConsoHoraire>> GetConsoBy1H(DateTime dateSearch)
        {
            // ----- Conversion des dates en string pour l'appel API
            string dateJour = dateSearch.ToString("dd/MM/yyyy");

            var response = await client.GetAsync($"consoBy1H?dateJour={dateJour}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                //logger.LogInformation("Réponse API : {Json}", json);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                try
                {

                    var consoBy1H = JsonSerializer.Deserialize<List<ConsoHoraire>>(json, options);
                    return consoBy1H ?? new List<ConsoHoraire>();
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Erreur de désérialisation : {ex.Message}");
                    return new List<ConsoHoraire>();
                }
            }
            else
            {
                Console.WriteLine($"Erreur API : {response.StatusCode}");
                return new List<ConsoHoraire>();
            }
        }


        // -----------------------------------------------------------------------------------------------------------------
        public async Task<List<ConsoHoraire>> GetConsoBy2H(DateTime dateSearch)
        {
            // ----- Conversion des dates en string pour l'appel API
            string dateJour = dateSearch.ToString("dd/MM/yyyy");

            var response = await client.GetAsync($"consoBy2H?dateJour={dateJour}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                //logger.LogInformation("Réponse API : {Json}", json);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                try
                {

                    var consoBy2H = JsonSerializer.Deserialize<List<ConsoHoraire>>(json, options);
                    return consoBy2H ?? new List<ConsoHoraire>();
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Erreur de désérialisation : {ex.Message}");
                    return new List<ConsoHoraire>();
                }
            }
            else
            {
                Console.WriteLine($"Erreur API : {response.StatusCode}");
                return new List<ConsoHoraire>();
            }
        }

        // -----------------------------------------------------------------------------------------------------------------
        public async Task<List<ConsoHoraire>> GetConsoBy3H(DateTime dateSearch)
        {
            // ----- Conversion des dates en string pour l'appel API
            string dateJour = dateSearch.ToString("dd/MM/yyyy");

            var response = await client.GetAsync($"consoBy3H?dateJour={dateJour}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                //logger.LogInformation("Réponse API : {Json}", json);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                try
                {

                    var consoBy2H = JsonSerializer.Deserialize<List<ConsoHoraire>>(json, options);
                    return consoBy2H ?? new List<ConsoHoraire>();
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Erreur de désérialisation : {ex.Message}");
                    return new List<ConsoHoraire>();
                }
            }
            else
            {
                Console.WriteLine($"Erreur API : {response.StatusCode}");
                return new List<ConsoHoraire>();
            }
        }
    }
}
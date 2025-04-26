using System.Text.Json.Serialization;

namespace BlazingConso.Entities;

public class ConsoWeek
{
    [JsonPropertyName("premierJour")]
    public string PremierJour { get; set; }

    [JsonPropertyName("annee")]
    public int Annee { get; set; }

    [JsonPropertyName("semaine")]
    public int Semaine { get; set; }

    // Valeur brute en Wh depuis l'API
    [JsonPropertyName("consoPH")]
    public decimal? ConsoHP { get; set; }

    [JsonPropertyName("consoHC")]
    public decimal? ConsoHC { get; set; }

    [JsonPropertyName("consoTotale")]
    public decimal? ConsoTotale { get; set; }

    [JsonPropertyName("coutAbonnement")]
    public decimal CoutAbonnement { get; set; }

    [JsonPropertyName("coutConsommationHP")]
    public decimal CoutConsommationHP { get; set; }

    [JsonPropertyName("coutConsommationHC")]
    public decimal CoutConsommationHC { get; set; }

    [JsonPropertyName("coutConsommation")]
    public decimal CoutConsommation { get; set; }

    [JsonPropertyName("coutTotal")]
    public decimal CoutTotal { get; set; }

    // ----- Propriétés calculées en kWh
    [JsonIgnore]
    public decimal? ConsoHPkWh => ConsoHP.HasValue ? Math.Round(ConsoHP.Value / 1000, 2) : null;

    [JsonIgnore]
    public decimal? ConsoHCkWh => ConsoHC.HasValue ? Math.Round(ConsoHC.Value / 1000, 2) : null;

    [JsonIgnore]
    public decimal? ConsoTotaleKWh => ConsoTotale.HasValue ? Math.Round(ConsoTotale.Value / 1000, 2) : null;
}
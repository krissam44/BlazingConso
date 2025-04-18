using System.Text.Json.Serialization;

namespace BlazingConso.Entities;

public class ConsoDay
{
    [JsonPropertyName("dateJour")]
    public string? DateJour { get; set; }

    [JsonPropertyName("heure")]
    public string? Heure { get; set; }

    [JsonPropertyName("jour")]
    public int? Jour { get; set; }

    [JsonPropertyName("semaine")]
    public string? Semaine { get; set; }

    [JsonPropertyName("indexHP")]
    public long? IndexHp { get; set; }

    [JsonPropertyName("indexHC")]
    public long? IndexHc { get; set; }

    [JsonPropertyName("indexTotal")]
    public long? IndexTotal { get; set; }

    [JsonPropertyName("consoJourHP")]
    public int? ConsoJourHP { get; set; }

    [JsonPropertyName("consoJourHC")]
    public int? ConsoJourHC { get; set; }

    [JsonPropertyName("consoJourTotal")]
    public int? ConsoJourTotal { get; set; }

    [JsonPropertyName("powerMax")]
    public int? PowerMax { get; set; }

    [JsonPropertyName("heureMax")]
    public string HeureMax { get; set; } = string.Empty;

    [JsonPropertyName("powerMin")]
    public int? PowerMin { get; set; }

    [JsonPropertyName("heureMin")]
    public string HeureMin { get; set; } = string.Empty;

    [JsonPropertyName("tempMax")]
    public double? TempMax { get; set; }

    [JsonPropertyName("tempMin")]
    public double? TempMin { get; set; }

    [JsonPropertyName("tarif")]
    public int Tarif { get; set; }

    [JsonPropertyName("coutAbonnement")]
    public decimal CoutAbonnement { get; set; }

    [JsonPropertyName("coutConsommation")]
    public decimal CoutConsommation { get; set; }

    [JsonPropertyName("coutJour")]
    public decimal CoutJour { get; set; }

    [JsonPropertyName("indexHPVeille")]
    public long? IndexHPVeille { get; set; }

    [JsonPropertyName("indexHCVeille")]
    public long? IndexHCVeille { get; set; }

    [JsonPropertyName("indexTotalVeille")]
    public long? IndexTotalVeille { get; set; }
}
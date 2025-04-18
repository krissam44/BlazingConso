using System.Text.Json.Serialization;

namespace BlazingConso.Entities;

public class ConsoResume
{
    [JsonPropertyName("consoJour")]
    public int? ConsoJour { get; set; }

    [JsonPropertyName("consoVeille")]
    public int? ConsoVeille { get; set; }

    [JsonPropertyName("consoHebdoEnCours")]
    public int? ConsoHebdoEnCours { get; set; }

    [JsonPropertyName("consoHebdoPrecedent")]
    public int? ConsoHebdoPrecedent { get; set; }

    [JsonPropertyName("consoMoisEnCours")]
    public int? ConsoMoisEnCours { get; set; }

    [JsonPropertyName("consoMoisPrecedent")]
    public int? ConsoMoisPrecedent { get; set; }

    [JsonPropertyName("consoHeureEnCours")]
    public int? ConsoHeureEnCours { get; set; }

    [JsonPropertyName("consoHeurePrecedent")]
    public int? ConsoHeurePrecedent { get; set; }

    [JsonPropertyName("consoLast30mn")]
    public int? ConsoLast30mn { get; set; }
}

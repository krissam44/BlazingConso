using System.Text.Json.Serialization;

namespace BlazingConso.Entities;

public class InfoCout
{
    [JsonPropertyName("coutJour")]
    public decimal CoutJour { get; set; }

    [JsonPropertyName("coutVeille")]
    public decimal CoutVeille { get; set; }

    [JsonPropertyName("coutHebdoCourant")]
    public decimal CoutHebdoCourant { get; set; }

    [JsonPropertyName("coutHebdoPrecedent")]
    public decimal CoutHebdoPrecedent { get; set; }

    [JsonPropertyName("coutMoisCourant")]
    public decimal CoutMoisCourant { get; set; }

    [JsonPropertyName("coutMoisPrecedent")]
    public decimal CoutMoisPrecedent { get; set; }
}

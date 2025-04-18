using System.Text.Json.Serialization;

namespace BlazingConso.Entities;

public class InfoLinky
{
    [JsonPropertyName("heure")]
    public TimeSpan? Heure { get; set; }

    [JsonPropertyName("indexTotal")]
    public long? IndexTotal { get; set; }

    [JsonPropertyName("indexHp")]
    public long? IndexHp { get; set; }

    [JsonPropertyName("indexHc")]
    public long? IndexHc { get; set; }

    [JsonPropertyName("puissance")]
    public int? Puissance { get; set; }

    [JsonPropertyName("intensite")]
    public int? Intensite { get; set; }

    [JsonPropertyName("tension")]
    public int? Tension { get; set; }
}

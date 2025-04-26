namespace BlazingConso.Entities;

public class ConsoMonth
{
    public int annee { get; set; }

    public int mois { get; set; }

    public string nomMois { get; set; } = string.Empty;

    public decimal? consoHP { get; set; }
    public decimal? consoHC { get; set; }
    public decimal? consoTotale { get; set; }
    public decimal? consoMoyenne { get; set; }
    public decimal? consoMax { get; set; }
    public string? jourMax { get; set; }
    public decimal? consoMin { get; set; }
    public string? jourMin { get; set; }

    public decimal? coutAbonnement { get; set; }
    public decimal? coutConsommationHP { get; set; }
    public decimal? coutConsommationHC { get; set; }
    public decimal? coutTotal { get; set; }

    // ----- Conversion automatique en kWh
    public decimal? ConsoHPkWh => consoHP / 1000;
    public decimal? ConsoHCkWh => consoHC / 1000;
    public decimal? ConsoTotalekWh => consoTotale / 1000;
    public decimal? ConsoMoyennekWh => consoMoyenne / 1000;
    public decimal? ConsoMaxkWh => consoMax / 1000;
    public decimal? ConsoMinkWh => consoMin / 1000;

    // ----- Période formatée
    public string periode => $"{nomMois} {annee}";
}

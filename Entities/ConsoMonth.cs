namespace BlazingConso.Entities;

public class ConsoMonth
{
    public int annee { get; set; }

    public int mois { get; set; }

    public string nomMois { get; set; }

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

    public string periode => $"{nomMois} {annee}";
}

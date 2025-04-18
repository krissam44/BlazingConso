namespace BlazingConso.Entities;

public class ConsoHoraire
{
    public string TrancheHoraire { get; set; }

    public int? TotalConso { get; set; }

    public int? TotalHP { get; set; }

    public int? TotalHC { get; set; }

    public decimal? TempMoyenne { get; set; }

    public int? PowerMax { get; set; }

    public int? PowerMin { get; set; }

    public decimal coutConsommation { get; set; }

    // Ajout pour afficher le pourcentage
    public double? Pourcentage { get; set; }

    public string? LabelDisplay => Pourcentage.HasValue ? $"{Pourcentage:0.0} %" : TrancheHoraire;
}

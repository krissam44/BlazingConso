namespace BlazingConso.Dtos;

public class WeeklyComparaisonConsoDto
{
    public string JourSemaine { get; set; }    // "Lundi"

    public int JourNumero { get; set; }        // 1 à 7

    public string? DateJour { get; set; }

    public decimal ConsoSemaine0 { get; set; }

    public decimal ConsoSemaineMoins1 { get; set; }

    public decimal ConsoSemaineMoins2 { get; set; }
}

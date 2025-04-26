namespace BlazingConso.Dtos;

public class WeeklyComparaisonCoutDto
{
public string JourSemaine { get; set; }    // "Lundi"

    public int JourNumero { get; set; }        // 1 à 7

    public decimal CoutSemaine0 { get; set; }

    public decimal CoutSemaineMoins1 { get; set; }

    public decimal CoutSemaineMoins2 { get; set; }
}

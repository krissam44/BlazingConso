using BlazingConso.Entities;

namespace BlazingConso.Dtos;

public class MonthlyComparaisonConsoDto
{
    public int Mois { get; set; }
    public string NomMois { get; set; } = "";

    public ConsoMonth? AnneeN { get; set; }
    public ConsoMonth? AnneeNmoins1 { get; set; }
    public ConsoMonth? AnneeNmoins2 { get; set; }
}

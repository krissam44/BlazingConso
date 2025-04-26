namespace BlazingConso.Dtos;

public class WeeklyChartCoutDto
{
    public int Week { get; set; }

    public int Year { get; set; }

    public decimal? CoutConsommationHP { get; set; }

    public decimal? CoutConsommationHC { get; set; }

    public decimal? CoutTotal { get; set; }

    public string Periode => Week.ToString() + '-' + Year.ToString();
}

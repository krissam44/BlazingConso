namespace BlazingConso.Entities
{
    public class WeeklyChartConsoDto
    {
        public int Week { get; set; }

        public int Year { get; set; }

        public decimal? ConsoHPkWh { get; set; }

        public decimal? ConsoHCkWh { get; set; }

        public decimal? Consommation => (ConsoHPkWh ?? 0) + (ConsoHCkWh ?? 0);
 
        public string Periode => (Week.ToString()) + '-' + (Year.ToString());
    }
}

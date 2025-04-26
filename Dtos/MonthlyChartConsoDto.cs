namespace BlazingConso.Dtos
{
    public class MonthlyChartConsoDto
    {
        public string Periode { get; set; }

        public decimal? ConsoHP { get; set; }

        public decimal? ConsoHC { get; set; }

        public decimal? Consommation => (ConsoHP ?? 0) + (ConsoHC ?? 0);
    }
}

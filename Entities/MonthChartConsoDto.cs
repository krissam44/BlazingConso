namespace BlazingConso.Entities
{
    public class MonthChartConsoDto
    {
        public string Periode { get; set; }

        public decimal? ConsoHP { get; set; }

        public decimal? ConsoHC { get; set; }

        public decimal? Consommation => (ConsoHP ?? 0) + (ConsoHC ?? 0);
    }
}

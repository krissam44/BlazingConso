namespace BlazingConso.Entities
{
    public class ConsoDayChartItem
    {
        public string JourSemaine { get; set; } = string.Empty; // "Lun", "Mar", ...
        public decimal SemaineMoins2 { get; set; }
        public decimal SemaineMoins1 { get; set; }
        public decimal SemaineActuelle { get; set; }
    }
}

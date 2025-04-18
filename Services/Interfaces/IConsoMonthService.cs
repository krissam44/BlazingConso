using BlazingConso.Entities;

namespace BlazingConso.Services.Interfaces
{
    public interface IConsoMonthService
    {
        Task<List<ConsoMonth>> GetConsoMonthsOfYearAsync(int year);
        Task<List<ConsoMonth>> GetConsoMonthsOfYearAsync(int startMonth, int startYear, int endMonth, int endYear);
    }
}
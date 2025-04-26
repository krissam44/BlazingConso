using BlazingConso.Entities;

namespace BlazingConso.Services.Interfaces
{
    public interface IConsoDayService
    {
        Task<ConsoMonth> GetConsoCurrentMonth();

        Task<List<ConsoDay>> GetConsoDaysOfMonthAsync(int month, int year);

        Task<List<ConsoDay>> GetConsoDaysPeriod(DateTime? startDate, DateTime? endDate);

        Task<ConsoDay> GetConsoToday();
    }
}
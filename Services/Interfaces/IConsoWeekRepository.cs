using BlazingConso.Entities;

namespace BlazingConso.Services.Interfaces
{
    public interface IConsoWeekRepository
    {
        Task<List<ConsoWeek>> GetConsoWeeksAsync(int startWeek, int endWeek, int year);
    }
}
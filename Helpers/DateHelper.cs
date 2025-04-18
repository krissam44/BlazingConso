namespace BlazingConso.Helpers;

public static class DateHelper
{
    public static (DateTime? startDate, DateTime? endDate) RecalculateDates(string selectedMode, DateTime? date, int duration)
    {
        if (selectedMode == "debut" && date.HasValue)
        {
            return (date, date.Value.AddDays(duration));
        }
        else if (selectedMode == "fin" && date.HasValue)
        {
            return (date.Value.AddDays(-duration), date);
        }
        return (null, null);
    }
}

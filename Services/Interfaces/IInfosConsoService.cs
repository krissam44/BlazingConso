using BlazingConso.Entities;

namespace BlazingConso.Services.Interfaces
{
    public interface IInfosConsoService
    {
        Task<ConsoResume> GetConsoResume();

        Task<InfoLinky> GetInfoLinky();

        Task<List<ConsoHoraire>> GetConsoBy1H(DateTime dateSearch);

        Task<List<ConsoHoraire>> GetConsoBy2H(DateTime dateSearch);

        Task<List<ConsoHoraire>> GetConsoBy3H(DateTime dateSearch);
    }
}
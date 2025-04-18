using BlazingConso.Entities;

namespace BlazingConso.Services.Interfaces
{
    public interface IConso30Service
    {
        Task<List<Conso30>> GetConso30Today();
    }
}
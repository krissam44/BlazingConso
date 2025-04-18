using BlazingConso.Entities;

namespace BlazingConso.Services.Interfaces;

public interface IInfosCoutsService
{
    Task<InfoCout> GetInfoCouts();
}
using BlazorCrud.Shared;

namespace BlazorCrud.Client.Services.Interfaces
{
    public interface IRangoPersonalService
    {
        Task<List<RangoPersonalDTO>> MostrarRangoPersonal();
    }
}

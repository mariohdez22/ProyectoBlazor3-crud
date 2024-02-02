using BlazorCrud.Shared;

namespace BlazorCrud.Client.Services.Interfaces
{
    public interface IPersonalService
    {
        Task<APIResponse<List<PersonalDTO>>> MostrarTrabajadores(ParametrosPaginacion pp);

        Task<PersonalDTO> BuscarTrabajador(int id);

        Task<string> CrearTrabajador(PersonalDTO trabajador);

        Task<string> EditarTrabajador(PersonalDTO trabajador, int id);

        Task<string> BorrarTrabajador(int id);
    }
}


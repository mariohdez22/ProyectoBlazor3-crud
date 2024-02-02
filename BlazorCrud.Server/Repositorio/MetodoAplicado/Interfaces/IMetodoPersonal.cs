using BlazorCrud.Server.Models.Entidades;
using BlazorCrud.Shared;

namespace BlazorCrud.Server.Repositorio.MetodoAplicado.Interfaces
{
    public interface IMetodoPersonal
    {
        Task<(List<Personal>, int totalRegistros)> ConsultaPersonal(ParametrosPaginacion parametros);

        Task<Personal> BuscarPersonal(int ID);

        Task<Personal> CrearPersonal(Personal entidad);

        Task<Personal> EditarPersonal(Personal entidad);

        Task BorrarPersonal(Personal entidad);
    }                                                                                                                                                                                   
}

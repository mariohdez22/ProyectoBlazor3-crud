using BlazorCrud.Server.Models.Entidades;

namespace BlazorCrud.Server.Repositorio.MetodoAplicado.Interfaces
{
    public interface IMetodoRangoPersonal
    {
        Task<List<RangoPersonal>> ConsultaRango();
    }
}

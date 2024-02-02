using BlazorCrud.Server.Models.Entidades;
using BlazorCrud.Server.Repositorio.MetodoAplicado.Interfaces;
using BlazorCrud.Server.Repositorio.MetodoGenerico.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Server.Repositorio.MetodoAplicado.Implementacion
{
    public class MetodoRangoPersonal : IMetodoRangoPersonal
    {
        public readonly IMetodoLookupGenerico<RangoPersonal> _repositorio;

        public MetodoRangoPersonal(IMetodoLookupGenerico<RangoPersonal> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<RangoPersonal>> ConsultaRango()
        {
            IQueryable<RangoPersonal> listaRango = await _repositorio.Consulta();

            return await listaRango.ToListAsync();
        }
    }
}

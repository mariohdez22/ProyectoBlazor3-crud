using BlazorCrud.Server.Models;
using BlazorCrud.Server.Repositorio.MetodoGenerico.Interfaces;

namespace BlazorCrud.Server.Repositorio.MetodoGenerico.Implementacion
{
    public class MetodoLookupGenerico<TEntity> : IMetodoLookupGenerico<TEntity> where TEntity : class
    {
        private readonly NominasDbContext _baseDatos;

        public MetodoLookupGenerico(NominasDbContext baseDatos)
        {
            _baseDatos = baseDatos;
        }

        public async Task<IQueryable<TEntity>> Consulta()
        {
            IQueryable<TEntity> lista = _baseDatos.Set<TEntity>();

            return lista;
        }
    }
}

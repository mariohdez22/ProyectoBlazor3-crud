namespace BlazorCrud.Server.Repositorio.MetodoGenerico.Interfaces
{
    public interface IMetodoLookupGenerico<TEntity> where TEntity : class
    {
        Task<IQueryable<TEntity>> Consulta();
    }
}

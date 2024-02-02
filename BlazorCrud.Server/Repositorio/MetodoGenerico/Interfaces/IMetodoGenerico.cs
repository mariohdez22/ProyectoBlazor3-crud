namespace BlazorCrud.Server.Repositorio.MetodoGenerico.Interfaces
{
    public interface IMetodoGenerico<TEntity> where TEntity : class
    {
        Task<IQueryable<TEntity>> Consulta();
        
        Task<TEntity> Buscar (int ID);
            
        Task<TEntity> Crear (TEntity entidad);

        Task<TEntity> Editar (TEntity entidad);

        Task Borrar (TEntity entidad);
    }
}

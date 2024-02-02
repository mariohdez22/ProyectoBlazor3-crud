using BlazorCrud.Server.Models.Entidades;
using BlazorCrud.Server.Repositorio.MetodoAplicado.Interfaces;
using BlazorCrud.Server.Repositorio.MetodoGenerico.Interfaces;
using BlazorCrud.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Linq.Expressions;

namespace BlazorCrud.Server.Repositorio.MetodoAplicado.Implementacion
{
    public class MetodoPersonal : IMetodoPersonal
    {
        private readonly IMetodoGenerico<Personal> _repositorio;

        public MetodoPersonal(IMetodoGenerico<Personal> repositorio)
        {
            _repositorio = repositorio;
        }

        public IQueryable<Personal> OrdenarPersonal(IQueryable<Personal> lista, Expression<Func<Personal, int>> criterioOrden, string FormatoOrden)
        {
            var resultado = FormatoOrden == "Ascendente"
                                         ? lista.OrderBy(criterioOrden)
                                         : FormatoOrden == "Descendente"
                                                        ? lista.OrderByDescending(criterioOrden) 
                                                        : null;

            if (resultado == null)
                return lista;
            else
                return resultado;
        }

        //int numeroPagina, int tamañoPagina, int idRango, string Orden, string buscar
        public async Task<(List<Personal>, int totalRegistros)> ConsultaPersonal(ParametrosPaginacion pp)
        {
            IQueryable<Personal> lista = await _repositorio.Consulta();
            
            if(pp.IdRango != 0)
            {
                lista = lista.Where(p => p.IdRangoPersonal == pp.IdRango);
            }

            if (!String.IsNullOrEmpty(pp.Buscar))
            {
                lista = lista.Where(

                    b => b.Nombres!.Contains(pp.Buscar) ||
                         b.Celular!.Contains(pp.Buscar) ||
                         b.Correo!.Contains(pp.Buscar));
            }

            int totalRegistros = await lista.CountAsync();

            var listaOrdenada = OrdenarPersonal(lista, p => p.IdPersonal, pp.Orden);

            var listaPersonal = await listaOrdenada 
                                          .Include(r => r.RangosPersonales)
                                          .Skip((pp.NumeroPagina - 1) * pp.TamañoPagina)
                                          .Take(pp.TamañoPagina)
                                          .ToListAsync();

            return (listaPersonal, totalRegistros);
        }

        public async Task<Personal> BuscarPersonal(int ID)
        {
            return await _repositorio.Buscar(ID);
        }

        public async Task<Personal> CrearPersonal(Personal entidad)
        {
            try
            {
                Personal creacionPersonal = await _repositorio.Crear(entidad);

                return creacionPersonal;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Personal> EditarPersonal(Personal entidad)
        {
            try
            {
                return await _repositorio.Editar(entidad);             
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task BorrarPersonal(Personal entidad)
        {
            try
            {
                await _repositorio.Borrar(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

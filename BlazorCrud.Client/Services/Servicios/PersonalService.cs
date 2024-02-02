using BlazorCrud.Client.Services.Interfaces;
using BlazorCrud.Shared;
using System.Net;
using System.Net.Http.Json;

namespace BlazorCrud.Client.Services.Servicios
{
    public class PersonalService : IPersonalService
    {
        private readonly HttpClient _httpClient;

        public PersonalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // int numeroPagina, int tamanoPagina, int idRango, string Orden, string? buscar
        public async Task<APIResponse<List<PersonalDTO>>> MostrarTrabajadores(ParametrosPaginacion pp)
        {
            string url = $"api/Personal/Consulta?NumeroPagina={pp.NumeroPagina}&TamañoPagina={pp.TamañoPagina}&IdRango={pp.IdRango}&Orden={pp.Orden}";

            if (!string.IsNullOrEmpty(pp.Buscar))
            {
                url += $"&Buscar={Uri.EscapeDataString(pp.Buscar)}";
            }

            var resultado = await _httpClient.GetFromJsonAsync<APIResponse<List<PersonalDTO>>>(url);

            if (resultado!.EsExitoso == true) 
            {
                return resultado;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

        public async Task<PersonalDTO> BuscarTrabajador(int id)
        {
            var resultado = await _httpClient.GetFromJsonAsync<APIResponse<PersonalDTO>>($"api/Personal/Obtener/{id}");

            if (resultado!.EsExitoso == true)
            {
                PersonalDTO personal = resultado.Resultado;

                return personal;
            }
            else
            {
                throw new Exception(resultado.MensajeError);
            }
        }

        public async Task<string> CrearTrabajador(PersonalDTO trabajador)
        {
            var resultado = await _httpClient.PostAsJsonAsync("api/Personal/Agregar", trabajador);
            var respuesta = await resultado.Content.ReadFromJsonAsync<APIResponse<string>>();

            if (respuesta!.CodigoEstado == HttpStatusCode.Created && respuesta!.EsExitoso == true)
            {
                return respuesta.Resultado;
            }
            else
            {
                throw new Exception(respuesta.MensajeError);
            }
        }

        public async Task<string> EditarTrabajador(PersonalDTO trabajador, int id)
        {
            var resultado = await _httpClient.PutAsJsonAsync($"api/Personal/Editar/{id}", trabajador);
            var respuesta = await resultado.Content.ReadFromJsonAsync<APIResponse<string>>();

            if (respuesta!.CodigoEstado == HttpStatusCode.NoContent && respuesta!.EsExitoso == true)
            {
                return respuesta.Resultado;
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<string> BorrarTrabajador(int id)
        {
            var resultado = await _httpClient.DeleteAsync($"api/Personal/Eliminar/{id}");
            var respuesta = await resultado.Content.ReadFromJsonAsync<APIResponse<string>>();

            if (respuesta!.CodigoEstado == HttpStatusCode.NoContent && respuesta!.EsExitoso == true)
            {
                return respuesta.Resultado;
            }
            else
            {
                throw new Exception();
            }
        }

    }
}

using AutoMapper;
using BlazorCrud.Server.Models.Entidades;
using BlazorCrud.Server.Repositorio.MetodoAplicado.Interfaces;
using BlazorCrud.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BlazorCrud.Server.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController : ControllerBase
    {
        private readonly ILogger<PersonalController> _logger;
        private readonly IMetodoPersonal _repositorio;
        private readonly IMapper _mapper;

        public PersonalController(ILogger<PersonalController> logger,
                                  IMetodoPersonal repositorio,
                                  IMapper mapper)
        {
            _logger = logger;
            _repositorio = repositorio;
            _mapper = mapper;
        }

        //-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

        [HttpGet("Consulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultarPersonal([FromQuery] ParametrosPaginacion parametros)
        {
            var _apiResponse = new APIResponse<List<PersonalDTO>>();

            try
            {
                _logger.LogInformation("Obtener todos los trabajadores");

                (List<Personal> lista, int totalRegistros) = await _repositorio.ConsultaPersonal(parametros);

                _apiResponse.Resultado = _mapper.Map<List<PersonalDTO>>(lista);
                _apiResponse.TotalRegistros = totalRegistros;
                _apiResponse.CodigoEstado = HttpStatusCode.OK;
                _apiResponse.EsExitoso = true;
            }
            catch (Exception ex)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajesError = new List<string>() { ex.ToString() };
                _apiResponse.MensajeError = ex.Message;
            }

            return Ok(_apiResponse);
        }

        //-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

        [HttpGet("Obtener/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscarPersonal(int id)
        {
            var _apiResponse = new APIResponse<PersonalDTO>();

            try
            {
                if (id == 0)
                {
                    _logger.LogError($"Error al traer villa con Id {id}");
                    _apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
                    _apiResponse.EsExitoso = false;

                    return BadRequest(_apiResponse);
                }

                var personal = await _repositorio.BuscarPersonal(id);

                if (personal == null)
                {
                    _apiResponse.CodigoEstado = HttpStatusCode.NotFound;
                    _apiResponse.EsExitoso = false;

                    return NotFound(_apiResponse);
                }

                _apiResponse.Resultado = _mapper.Map<PersonalDTO>(personal);
                _apiResponse.CodigoEstado = HttpStatusCode.OK;
                _apiResponse.EsExitoso = true;
            }
            catch (Exception ex)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajesError = new List<string>() { ex.ToString() };
                _apiResponse.MensajeError = ex.Message;
            }

            return Ok(_apiResponse);
        }

        //-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

        [HttpPost("Agregar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CrearPersonal(PersonalDTO personalDTO)
        {
            var _apiResponse = new APIResponse<string>();

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (personalDTO == null)
                {
                    return BadRequest(personalDTO);
                }

                Personal personal = _mapper.Map<Personal>(personalDTO);
                await _repositorio.CrearPersonal(personal);

                _apiResponse.CodigoEstado = HttpStatusCode.Created;
                _apiResponse.EsExitoso = true;
                _apiResponse.Resultado = "Ejecucion Correcta";
            }
            catch (Exception ex)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajesError = new List<string>() { ex.ToString() };
            }

            return Ok(_apiResponse);
        }

        //-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

        [HttpPut("Editar/{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditarPersonal(PersonalDTO personalDTO, int id)
        {
            var _apiResponse = new APIResponse<string>();

            try
            {
                if (personalDTO == null || id != personalDTO.IdPersonal)
                {
                    _apiResponse.EsExitoso = false;
                    _apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
                    return BadRequest(_apiResponse);
                }

                Personal personal = _mapper.Map<Personal>(personalDTO);
                await _repositorio.EditarPersonal(personal);

                _apiResponse.CodigoEstado = HttpStatusCode.NoContent;
                _apiResponse.EsExitoso = true;
                _apiResponse.Resultado = "Ejecucion Correcta";

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajesError = new List<string>() { ex.ToString() };
            }

            return BadRequest(_apiResponse);
        }

        //-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

        [HttpDelete("Eliminar/{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarPersonal(int id)
        {
            var _apiResponse = new APIResponse<string>();

            try
            {
                if (id == 0)
                {
                    _apiResponse.EsExitoso = false;
                    _apiResponse.CodigoEstado = HttpStatusCode.BadRequest;
                    return BadRequest(_apiResponse);
                }

                var personal = await _repositorio.BuscarPersonal(id);

                if (personal == null)
                {
                    _apiResponse.EsExitoso = false;
                    _apiResponse.CodigoEstado = HttpStatusCode.NotFound;
                    return NotFound();
                }

                await _repositorio.BorrarPersonal(personal);

                _apiResponse.CodigoEstado = HttpStatusCode.NoContent;
                _apiResponse.EsExitoso = true;
                _apiResponse.Resultado = "Ejecucion Correcta";

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.EsExitoso = false;
                _apiResponse.MensajesError = new List<string>() { ex.ToString() };
            }

            return BadRequest(_apiResponse);
        }

    }
}

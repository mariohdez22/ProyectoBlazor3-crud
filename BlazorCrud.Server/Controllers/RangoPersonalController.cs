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
    public class RangoPersonalController : ControllerBase
    {
        private readonly ILogger<PersonalController> _logger;
        private readonly IMetodoRangoPersonal _repositorio;
        private readonly IMapper _mapper;

        public RangoPersonalController(ILogger<PersonalController> logger,
                                       IMetodoRangoPersonal repositorio,
                                       IMapper mapper)
        {
            _logger = logger;
            _repositorio = repositorio;
            _mapper = mapper;
        }

        [HttpGet("Consulta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultaRangoPersonal()
        {
            var _apiResponse = new APIResponse<List<RangoPersonalDTO>>();

            try
            {
                _logger.LogInformation("Obtener todos los Rangos");

                List<RangoPersonal> lista = await _repositorio.ConsultaRango();

                _apiResponse.Resultado = _mapper.Map<List<RangoPersonalDTO>>(lista);
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

    }
}

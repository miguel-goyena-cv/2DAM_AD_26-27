using _4VGymAPI.Models;
using GrsEF.Models;
using GrsEF.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GrsEF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GrsController : ControllerBase
    {
        private readonly GrsRepository _grsRepository;
        public GrsController(GrsRepository grsRepository)
        {
            _grsRepository = grsRepository;
        }

        [HttpGet("lasGrs")]
        [ProducesResponseType(typeof(List<Gr>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespuestaError), StatusCodes.Status500InternalServerError)]
        public  ActionResult<List<Gr>> GetGrs()
        {
            try
            {
                var listaGrs =  _grsRepository.GetGrs();
                return Ok(listaGrs);
            }
            catch (Exception exc)
            {
                {
                    var error = new { Id = 500, Description = $"Error al obtener las Grs: {exc.Message}" };
                    return StatusCode(StatusCodes.Status500InternalServerError, error);
                }
            }
        }

        [HttpGet("GrsConEtapas")]
        [ProducesResponseType(typeof(List<Gr>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespuestaError), StatusCodes.Status500InternalServerError)]
        public  ActionResult<List<Gr>> ObtenerGrsConEtapas()
        {
            try
            {
                var listaGrs =  _grsRepository.ObtenerGrsConEtapas();
                return Ok(listaGrs);
            }
            catch (Exception exc)
            {
                {
                    var error = new { Id = 500, Description = $"Error al obtener las Grs: {exc.Message}" };
                    return StatusCode(StatusCodes.Status500InternalServerError, error);
                }
            }
        }

        [HttpGet("GrsConSusEtapas")]
        [ProducesResponseType(typeof(List<Gr>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespuestaError), StatusCodes.Status500InternalServerError)]
        public  ActionResult<List<Gr>> ObtenerGrsConSusEtapas()
        {
            try
            {
                var listaGrs =  _grsRepository.ObtenerGrsConSusEtapas();
                return Ok(listaGrs);
            }
            catch (Exception exc)
            {
                {
                    var error = new { Id = 500, Description = $"Error al obtener las Grs: {exc.Message}" };
                    return StatusCode(StatusCodes.Status500InternalServerError, error);
                }
            }
        }

        [HttpGet("GrsConSusEtapasDTO")]
        [ProducesResponseType(typeof(List<Gr>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespuestaError), StatusCodes.Status500InternalServerError)]
        public  ActionResult<List<Gr>> ObtenerGrsConSusEtapasDTO()
        {
            try
            {
                var listaGrs =  _grsRepository.ObtenerGrsConSusEtapasDto();
                return Ok(listaGrs);
            }
            catch (Exception exc)
            {
                {
                    var error = new { Id = 500, Description = $"Error al obtener las Grs: {exc.Message}" };
                    return StatusCode(StatusCodes.Status500InternalServerError, error);
                }
            }
        }

    }

}

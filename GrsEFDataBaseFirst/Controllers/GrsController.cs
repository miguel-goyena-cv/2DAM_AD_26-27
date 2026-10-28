using GrsEFDataBaseFirst.Models;
using GrsEFDataBaseFirst.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GrsEFDataBaseFirst.Controllers
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
        public async Task<ActionResult<List<Gr>>> GetGrs()
        {
            try
            {
                var listaGrs = await _grsRepository.GetGrs();
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
        public async Task<ActionResult<List<Gr>>> GetGrsConEtapas()
        {
            try
            {
                var listaGrs = await _grsRepository.GetGrsConEtapas();
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
        public async Task<ActionResult<List<Gr>>> GetGrsConSusEtapas()
        {
            try
            {
                var listaGrs = await _grsRepository.GetGrsConSusEtapas();
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
        public async Task<ActionResult<List<Gr>>> GetGrsConSusEtapasDTO()
        {
            try
            {
                var listaGrs = await _grsRepository.GetGrsConSusEtapasDto();
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

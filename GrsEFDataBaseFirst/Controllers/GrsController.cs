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
        public  ActionResult<List<Gr>> GetGrsConEtapas()
        {
            try
            {
                var listaGrs =  _grsRepository.GetGrsConEtapas();
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
        public  ActionResult<List<Gr>> GetGrsConSusEtapas()
        {
            try
            {
                var listaGrs =  _grsRepository.GetGrsConSusEtapas();
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
        public  ActionResult<List<Gr>> GetGrsConSusEtapasDTO()
        {
            try
            {
                var listaGrs =  _grsRepository.GetGrsConSusEtapasDto();
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

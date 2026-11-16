using _4VGymAPI.Models;
using GrsEF.Data;
using GrsEF.Dtos;
using GrsEF.Models;
using GrsEF.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GrsEF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EtapasController : ControllerBase
    {
        private readonly EtapasRepository _etapasRepository;
        public EtapasController(EtapasRepository etapasRepository)
        {
            _etapasRepository = etapasRepository;
        }
        // GET: api/etapas/GR1/1
        [HttpGet("{idGr}/{numEtapa}")]
        [ProducesResponseType(typeof(EtapaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespuestaError), StatusCodes.Status404NotFound)]
        public ActionResult<EtapaDto> ObtenerEtapaDeGr(string idGr, int numEtapa)
        {
            var etapaDto = _etapasRepository.ObtenerEtapaDeGr(idGr, numEtapa, out RespuestaError? respuestaError);

            if (etapaDto == null)
            {
                return NotFound(respuestaError);
            }

            return Ok(etapaDto);
        }
    }
}

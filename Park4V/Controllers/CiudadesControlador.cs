using Microsoft.AspNetCore.Mvc;
using Park4VMariaSolucion.Models;
using Park4VMariaSolucion.Repositories;
using Park4VMariaSolucion.Dtos;


namespace Park4VMariaSolucion.Controllers
{
    [ApiController]                
    [Route("ciudades")]     
    public class CiudadesControlador: ControllerBase
    {
        private readonly RepositorioCiudades _ciudadesRepository;

        public CiudadesControlador(RepositorioCiudades ciudadesRepository)
        {
            _ciudadesRepository = ciudadesRepository;
        }
       
        [HttpGet]
        [ProducesResponseType(typeof(List<CiudadDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
       // [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public ActionResult<List<CiudadDto>> GetCiudadesDto()
        {
            try
            {
                List<CiudadDto> ciudades = _ciudadesRepository.GetTodasCiudadesOrdenadasPorNombre();
                return Ok(ciudades);
            }
            catch (Exception )//catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(1, $"Error, no se puede conectar con la base de datos"));
            }
        }
    }
}

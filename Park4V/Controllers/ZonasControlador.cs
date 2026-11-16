using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Park4VMariaSolucion.Dtos;
using Park4VMariaSolucion.Models;
using Park4VMariaSolucion.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Park4VMariaSolucion.Controllers
{
    [ApiController]                  // 1. Permite comportamientos automáticos de API
    [Route("zonas")]      // 2. Asigna la ruta /Ciudades
    public class ZonasControlador : ControllerBase
    {
        private readonly RepositorioZonas _zonasRepository;

        public ZonasControlador(RepositorioZonas zonasRepository)
        {
            _zonasRepository = zonasRepository;
        }

        // GET: zonas/5
        // [HttpGet("{idCiudad:int}")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Zona>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public ActionResult<List<Zona>> GetZonasCiudad([FromQuery] int idCiudad)
        {
            try
            {
                if (idCiudad == null)
                {
                    return BadRequest(new ErrorResponse(1, "idCiudad es obligatorio"));
                }

                var zonas = _zonasRepository.GetZonasCiudad(idCiudad);
                if (zonas.Count == 0)
                {
                    return NotFound(new ErrorResponse(21, "NO existe la ciudad o no tiene zonas"));
                }
                return Ok(zonas);
            }
            catch (Exception)
            {
                return BadRequest(new ErrorResponse(1, "Error, no se puede conectar con la base de datos"));
            }
        }
    }
}

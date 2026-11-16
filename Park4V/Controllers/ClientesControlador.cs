using Microsoft.AspNetCore.Mvc;
using Park4VMariaSolucion.Dtos;
using Park4VMariaSolucion.Repositories;

namespace Park4VMariaSolucion.Controllers
{
    [ApiController]           
    [Route("clientes")]   
    public class ClientesControlador: ControllerBase
    {
        private readonly RepositorioClientes _repositorioClientes;

        public ClientesControlador(RepositorioClientes repositorioClientes)
        {
            this._repositorioClientes = repositorioClientes;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<ClienteDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public ActionResult<List<ClienteDto>> GetClientes([FromQuery] string? orden)
        {
            if (orden == null) orden = "asc";
            if (orden != "asc" && orden != "desc")
                return BadRequest(new ErrorResponse(1, "Debe ser null, 'asc' o 'desc'"));
            var clientes = _repositorioClientes.GetClientesOrdenados(orden);
            return Ok(clientes);
        }


        [HttpGet("{email}")]
        [ProducesResponseType(typeof(ClienteConEstacionamientosDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        //public ActionResult<ClienteConEstacionamientosDto> GetClienteConEstacionamientos([FromQuery] string? email)
        public ActionResult<ClienteConEstacionamientosDto> GetClienteConEstacionamientos(string? email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest(new ErrorResponse(2, "El parámetro 'email' es obligatorio."));
            }

            var cliente = _repositorioClientes.GetClienteConEstacionamientos(email);
            if (cliente == null )
            {
                return NotFound(new ErrorResponse(404, $"No se encontró ningún cliente con el email '{email}'."));
            }

            return Ok(cliente);
        }

    }
}

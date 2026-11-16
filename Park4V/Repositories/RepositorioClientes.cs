using Microsoft.EntityFrameworkCore;
using Park4VMariaSolucion.Data;
using Park4VMariaSolucion.Dtos;
using Park4VMariaSolucion.Models;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Park4VMariaSolucion.Repositories
{
    public class RepositorioClientes
    {
        Park4VContext _park4VContext;

        public RepositorioClientes(Park4VContext park4VContext)
        {
            this._park4VContext = park4VContext;
        }
        // todo Con 1 parámetro
        public List<ClienteDto> GetClientesOrdenados(string? orden)
        {
            
            //// Si no se especifica el parámetro de campo, por defecto es "email"
            if (orden == null || string.IsNullOrWhiteSpace(orden)) orden = "desc";

            bool esAscendente = string.Equals(orden, "asc", StringComparison.OrdinalIgnoreCase);


            // Aplicación del ordenamiento
            IEnumerable<Cliente> resultadoOrdenado;
            if (esAscendente)
            {
                resultadoOrdenado = _park4VContext.Clientes
                    .OrderBy(c => c.Saldo);
            }
            else
            {
                resultadoOrdenado = _park4VContext.Clientes
                    .OrderByDescending(c => c.Saldo);
            }

            // Hago la transformacion y ejecuto el toList()
            return resultadoOrdenado
                    .Select(c => new ClienteDto(c.Email, c.Saldo))
                    .ToList();
        }
        public ClienteConEstacionamientosDto? GetClienteConEstacionamientos(string? email)
        {

            // Caso en que no existe el email
            var cliente = _park4VContext.Clientes.Find(email);
            if (cliente == null)
            {
                return null;
            }

            // En todo lo demas
            var estacionamientosDeCliente = _park4VContext.Estacionamientos
                .Where(e => e.Email.Equals(email))
                .Select(e => new EstacionamientoDto(
                    e.ZonaNavigation == null ? null :
                        new ZonaConCiudadDto(e.ZonaNavigation.Zona1, e.ZonaNavigation.PrecioMinuto, e.ZonaNavigation.MinMaximos,
                        new CiudadDto(e.ZonaNavigation.IdCiudad, e.ZonaNavigation.IdCiudadNavigation.Nombre)), e.Matricula, e.NumMovimiento, e.FechaHoraInicio, e.FechaHoraFin))
                .ToList();

            return new ClienteConEstacionamientosDto(cliente.Email, cliente.Saldo, estacionamientosDeCliente);

        }
    }
}

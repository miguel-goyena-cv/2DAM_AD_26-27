using Microsoft.EntityFrameworkCore;
using Park4VMariaSolucion.Data;
using Park4VMariaSolucion.Dtos;
using Park4VMariaSolucion.Models;

namespace Park4VMariaSolucion.Repositories
{
    public class RepositorioCiudades
    {
        Park4VContext _park4VContext;

        public RepositorioCiudades(Park4VContext park4VContext)
        {
            this._park4VContext = park4VContext;
        }

        public List<CiudadDto> GetTodasCiudadesOrdenadasPorNombre()
        {
            return _park4VContext.Ciudades
                .OrderBy(c => c.Nombre)
                .Select(c => new CiudadDto
                    {
                        Id = c.Id,
                        Nombre = c.Nombre
                    })
                .ToList();
        }
    }
}

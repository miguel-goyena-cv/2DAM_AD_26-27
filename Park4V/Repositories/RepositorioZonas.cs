using Microsoft.EntityFrameworkCore;
using Park4VMariaSolucion.Data;
using Park4VMariaSolucion.Models;
using Park4VMariaSolucion.Dtos;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Park4VMariaSolucion.Repositories
{
    public class RepositorioZonas
    {

        Park4VContext _park4VContext;

        public RepositorioZonas(Park4VContext park4VContext)
        {
            this._park4VContext = park4VContext;
        }

        // 2 Zonas definidas para una ciudad en concreto que se pasa por parámetro.De cada zona la información importante:
        //●	Nombre de la zona
        //●	Precio el minuto
        //●	Máximo de minutos
        //En la respuesta debemos dar la información completa de la ciudad.
        //El parámetro ciudad es obligatorio
        public List<ZonaConCiudadDto> GetZonasCiudad(int idCiudad)
        {
            List<ZonaConCiudadDto> zonas = _park4VContext.Zonas
                .Include(z => z.IdCiudadNavigation)
                .Where(z => z.IdCiudad == idCiudad)
                .Select(z => new ZonaConCiudadDto
                {
                    Zona1 = z.Zona1,
                    PrecioMinuto = z.PrecioMinuto,
                    MinMaximos = z.MinMaximos,
                    Ciudad = new CiudadDto(z.IdCiudad, z.IdCiudadNavigation.Nombre)
                })
                .ToList();
            return zonas;

        }
        public List<ZonaConCiudadDto> GetZonasCiudadDto(int idCiudad)
        {
            List<Zona> zonas = _park4VContext.Zonas
                .Include(z => z.IdCiudadNavigation)
                .Where(z => z.IdCiudad == idCiudad).ToList();

            return zonas.Select(z => new ZonaConCiudadDto
            {
                Zona1 = z.Zona1,
                PrecioMinuto = z.PrecioMinuto,
                MinMaximos = z.MinMaximos,
                Ciudad = new CiudadDto(z.IdCiudad,z.IdCiudadNavigation.Nombre)
            }).ToList();

        }

    }
}

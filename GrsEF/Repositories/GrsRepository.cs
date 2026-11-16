using GrsEF.Data;
using GrsEF.Dtos;
using GrsEF.Models;
using Microsoft.EntityFrameworkCore;

namespace GrsEF.Repositories
{
    public class GrsRepository
    {
        // _bdGrsContext será la instancia que sirve de puente entre el repositorio y la base de datos. Permite consultar y manipular las tablas (Grs, Etapas, Zonas, etc.) usando LINQ y EF Core
        private readonly BdGrsContext _bdGrsContext;

        public GrsRepository(BdGrsContext bdGrsContext)
        {
            _bdGrsContext = bdGrsContext;
        }
        public  List<Gr> GetGrs() // Carga de forma asíncrona sin datos relacionados
        {
            return  _bdGrsContext.Grs.ToList();
        }
        public  List<Gr> ObtenerGrsConEtapas() // Carga de forma asíncrona sin datos relacionados
        {
            return  _bdGrsContext.Grs
                      .Where(g=>g.Etapas.Count > 0)
                      .OrderBy(g=>g.Nombre)
                      .ToList();
        }
        public  List<Gr> ObtenerGrsConSusEtapas()
        {
            return  _bdGrsContext.Grs
                                  .Include(g => g.Etapas)
                                  .ToList();
        }
        public  List<GrConEtapasDTO> ObtenerGrsConSusEtapasDto()
        {
            // No necesita .Include(g => g.Etapas)
            // Al usar Select(), EF Core analiza los campos que estás intentando asignar.
            // Como esta leyendo datos de etapas y zonas, con g.Etapas y  e.IdZonaNavigation.Nombre el traductor de EF Core comprende automáticamente que necesita incluir esas tablas en la consulta SQL y genera los JOIN correspondientes sin necesidad de decírselo de forma manual.
            return  _bdGrsContext.Grs
              .Select(g => new GrConEtapasDTO
              {
                  Id = g.Id,
                  Nombre = g.Nombre,
                  Etapas = g.Etapas.Select(e => new EtapaDto
                  {
                      IdGr = e.IdGr,
                      NumEtapa = e.NumEtapa,
                      NombreZona = e.IdZonaNavigation.Nombre,
                      Km = e.Km,
                      Desnivel = e.Desnivel
                  }).ToList()
              }).ToList();
        }



    }
}

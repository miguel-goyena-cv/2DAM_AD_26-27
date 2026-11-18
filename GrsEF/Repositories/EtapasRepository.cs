using _4VGymAPI.Models;
using GrsEF.Data;
using GrsEF.Dtos;
using GrsEF.Models;
using Microsoft.EntityFrameworkCore;

namespace GrsEF.Repositories
{
    public class EtapasRepository
    {
        private readonly BdGrsContext _bdGrsContext;

        public EtapasRepository(BdGrsContext bdGrsContext)
        {
            _bdGrsContext = bdGrsContext;
        }
        public EtapaDto? ObtenerEtapaDeGr(string idGr, int numEtapa, out RespuestaError? errorResponse)
        {
            errorResponse = null;
            var gr = _bdGrsContext.Grs.Find(idGr);
            if (gr == null)
            {
                errorResponse = new RespuestaError(120, $"No se encontró la GR '{idGr}'.");
                return null;
            }
            EtapaDto? etapaDto = _bdGrsContext.Etapas
                             .Where(e => e.IdGr == idGr && e.NumEtapa == numEtapa)
                             .Include(e => e.IdZonaNavigation) // No hace falta por Select
                             .Select(e => new EtapaDto
                             {
                                 IdGr = e.IdGr,
                                 NumEtapa = e.NumEtapa,
                                 NombreZona = e.IdZonaNavigation.Nombre,
                                 Km = e.Km,
                                 Desnivel = e.Desnivel
                             })
                             .SingleOrDefault();


            if (etapaDto == null)
            {
                errorResponse = new RespuestaError(131, $"No se encontró la etapa número {numEtapa} para el GR '{idGr}'.");
                return null;
            }

            return etapaDto;
        }
    }
}

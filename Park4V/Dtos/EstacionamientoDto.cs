using Park4VMariaSolucion.Models;
using System.Text.Json.Serialization;

namespace Park4VMariaSolucion.Dtos
{
    public class EstacionamientoDto
    {
        public EstacionamientoDto()
        {
        }

        public EstacionamientoDto(ZonaConCiudadDto? zonaConCiudadDto,string matricula, int numMovimiento, DateTime fechaHoraInicio, DateTime fechaHoraFin)
        {
            this.ZonaConCiudadDto = zonaConCiudadDto;
            Matricula = matricula;
            NumMovimiento = numMovimiento;
            FechaHoraInicio = fechaHoraInicio;
            FechaHoraFin = fechaHoraFin;
        }
        [JsonPropertyName("zona")]
        public ZonaConCiudadDto? ZonaConCiudadDto { get; set; }

        [JsonPropertyName("matricula")]
        public string Matricula { get; set; } = string.Empty;

        [JsonPropertyName("numero")]
        public int NumMovimiento { get; set; }

        [JsonPropertyName("fecha_inicio")]
        public DateTime FechaHoraInicio { get; set; }

        [JsonPropertyName("fecha_fin")]
        public DateTime FechaHoraFin { get; set; }


        
    }
}

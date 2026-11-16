using System.Text.Json.Serialization;

namespace Park4VMariaSolucion.Dtos
{
    public class ZonaConCiudadDto
    {
        public ZonaConCiudadDto()
        {
        }

        public ZonaConCiudadDto(string zona1, decimal precioMinuto, int minMaximos, CiudadDto? ciudadDto)
        {
            Zona1 = zona1;
            PrecioMinuto = precioMinuto;
            MinMaximos = minMaximos;
            Ciudad = ciudadDto;
        }

        [JsonPropertyName("nombre")]
        public string Zona1 { get; set; } = null!;

        [JsonPropertyName("precio_minuto")]
        public decimal PrecioMinuto { get; set; }

        [JsonPropertyName("maximo_minutos")]
        public int MinMaximos { get; set; }

        [JsonPropertyName("ciudad")]
        public CiudadDto? Ciudad { get; set; }


    }
}

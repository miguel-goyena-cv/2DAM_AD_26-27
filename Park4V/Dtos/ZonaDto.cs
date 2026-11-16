using System.Text.Json.Serialization;

namespace Park4VMariaSolucion.Dtos
{
    public class ZonaDto
    {
        [JsonPropertyName("zona")]
        public string Zona1 { get; set; } = null!;

        [JsonPropertyName("precio_minuto")]
        public decimal? PrecioMinuto { get; set; }

        [JsonPropertyName("maximo_minutos")]
        public int? MinMaximos { get; set; }
    }
   
}

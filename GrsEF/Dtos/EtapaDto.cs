using System.Text.Json.Serialization;

namespace GrsEF.Dtos
{
    public class EtapaDto
    {
        [JsonPropertyName("id_gr")]
        public string IdGr { get; set; } = null!;
        [JsonPropertyName("num_etapa")]
        public int NumEtapa { get; set; }
        [JsonPropertyName("nombre_zona")]
        public string? NombreZona { get; set; }
        [JsonPropertyName("km")]
        public int? Km { get; set; }
        [JsonPropertyName("desnivel")]
        public int? Desnivel { get; set; }
    }
}

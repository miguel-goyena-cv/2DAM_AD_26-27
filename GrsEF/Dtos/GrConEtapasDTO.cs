using System.Text.Json.Serialization;

namespace GrsEF.Dtos
{
    public class GrConEtapasDTO
    {
        [JsonPropertyName("id_gr")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = null!;
        [JsonPropertyName("etapas")]
        public List<EtapaDto> Etapas { get; set; } = new();

    }
}

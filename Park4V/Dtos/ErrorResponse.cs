using System.Text.Json.Serialization;

namespace Park4VMariaSolucion.Dtos
{
    public class ErrorResponse
    {

        [JsonPropertyName("codigo")]
        public long Code { get; set; }

        [JsonPropertyName("descripcion")]
        public string Description { get; set; } = string.Empty;

        public ErrorResponse(int code, string description)
        {
            this.Code = code;
            this.Description = description;
        }
    }
}

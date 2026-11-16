using System.Text.Json.Serialization;

namespace _4VGymAPI.Models
{
    public class RespuestaError
    {

        [JsonPropertyName("codigo")]
        public int Codigo { get; set; }

        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; } = string.Empty;

        public RespuestaError(int codigo, string descripcion)
        {
            this.Codigo = codigo;
            this.Descripcion = descripcion;
        }
    }
}

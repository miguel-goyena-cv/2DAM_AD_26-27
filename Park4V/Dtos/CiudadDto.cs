using System.Text.Json.Serialization;

namespace Park4VMariaSolucion.Dtos
{
    public class CiudadDto
    {
        public CiudadDto()
        {
        }

        public CiudadDto(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = null!;

    }
}

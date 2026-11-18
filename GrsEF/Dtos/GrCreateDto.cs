using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GrsEF.Dtos
{
    public class GrCreateDto
    {
        [JsonPropertyName("id")]
        [Required(ErrorMessage = "El Id es obligatorio.")]
        [StringLength(5, ErrorMessage = "El Id no puede tener más de 5 caracteres.")]
        public string? Id { get; set; } = null!;

        [JsonPropertyName("nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
        public string? Nombre { get; set; } = null!;

        [JsonPropertyName("descripcion")]
        public string? Descripcion { get; set; }
    }

}

using System.Text.Json.Serialization;

namespace Park4VMariaSolucion.Dtos
{
    public class ClienteConEstacionamientosDto
    {
        public ClienteConEstacionamientosDto()
        {
        }

        public ClienteConEstacionamientosDto(string email, decimal saldo, List<EstacionamientoDto> estacionamientos)
        {
            Email = email;
            Saldo = saldo;
            EstacionamientosDto = estacionamientos;
        }

        [JsonPropertyName("email")]
        public string Email { get; set; } = null!;

        [JsonPropertyName("saldo_euros")]
        public decimal Saldo { get; set; }

        [JsonPropertyName("estacionamientos")]
        public List<EstacionamientoDto> EstacionamientosDto { get; set; } = null!;
    }
}

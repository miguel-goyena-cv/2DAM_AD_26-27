using System.Text.Json.Serialization;

namespace Park4VMariaSolucion.Dtos
{
    public class ClienteDto
    {
        public ClienteDto(string email, decimal saldo)
        {
            Email = email;
            Saldo = saldo;
        }

        [JsonPropertyName("email")]
        public string Email { get; set; } = null!;

        [JsonPropertyName("saldo")]
        public decimal Saldo { get; set; }
    }
}


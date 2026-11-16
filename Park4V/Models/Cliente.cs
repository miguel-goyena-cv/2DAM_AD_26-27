using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Park4VMariaSolucion.Models;

public partial class Cliente
{
    [JsonPropertyName("email")]
    public string Email { get; set; } = null!;
    [JsonPropertyName("saldo")]
    public decimal Saldo { get; set; }
    [JsonPropertyName("estacionamientos")]
    public virtual ICollection<Estacionamiento> Estacionamientos { get; set; } = new List<Estacionamiento>();
}

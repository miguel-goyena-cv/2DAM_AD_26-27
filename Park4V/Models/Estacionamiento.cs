using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Park4VMariaSolucion.Models;

public partial class Estacionamiento
{
    [JsonPropertyName("email")]
    public string Email { get; set; } = null!;

    [JsonPropertyName("numMovimiento")]
    public int NumMovimiento { get; set; }

    [JsonPropertyName("matricula")]
    public string Matricula { get; set; }

    [JsonPropertyName("fechaHoraInicio")]
    public DateTime FechaHoraInicio { get; set; }

    [JsonPropertyName("fechaHoraFin")]
    public DateTime FechaHoraFin { get; set; }

    [JsonPropertyName("idCiudad")]
    public int IdCiudad { get; set; }

    [JsonPropertyName("zona")]
    public string Zona { get; set; }

    [JsonPropertyName("emailNavigation")]
    public virtual Cliente EmailNavigation { get; set; } = null!;

    [JsonPropertyName("zonaNavigation")]
    public virtual Zona? ZonaNavigation { get; set; }
}

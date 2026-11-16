using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Park4VMariaSolucion.Models;

public partial class Ciudad
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("nombre")]

    public string Nombre { get; set; } = null!;

    [JsonPropertyName("zonas")]
    public virtual ICollection<Zona> Zonas { get; set; } = new List<Zona>();
}

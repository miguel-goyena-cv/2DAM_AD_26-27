using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Park4VMariaSolucion.Models;

public partial class Zona
{
    [JsonPropertyName("idCiudad")]
    public int IdCiudad { get; set; }

    [JsonPropertyName("nombre_zona")]
    public string Zona1 { get; set; } = null!;

    [JsonPropertyName("precio_minuto")]
    public decimal PrecioMinuto { get; set; }

    [JsonPropertyName("maximo_minutos")]
    public int MinMaximos { get; set; }

    [JsonPropertyName("estacionamientos")]
    public virtual ICollection<Estacionamiento> Estacionamientos { get; set; } = new List<Estacionamiento>();

    [JsonPropertyName("idCiudadNavigation")]
    public virtual Ciudad IdCiudadNavigation { get; set; } = null!;
}

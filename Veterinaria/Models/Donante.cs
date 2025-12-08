using System;
using System.Collections.Generic;

namespace Veterinaria.Models;

public partial class Donante
{
    public int IdDonante { get; set; }

    public string? NombreCompleto { get; set; }

    public decimal? CompromisoMontoMensual { get; set; }

    public virtual ICollection<Aporte> Aportes { get; set; } = new List<Aporte>();
}

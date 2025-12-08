using System;
using System.Collections.Generic;

namespace Veterinaria.Models;

public partial class Veterinario
{
    public int IdVeterinario { get; set; }

    public string? CodVeterinario { get; set; }

    public string? Especialidad { get; set; }

    public decimal? Sueldo { get; set; }

    public virtual Persona IdVeterinarioNavigation { get; set; } = null!;
}

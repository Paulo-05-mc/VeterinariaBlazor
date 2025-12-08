using System;
using System.Collections.Generic;

namespace Veterinaria.Models;

public partial class Persona
{
    public int IdPersona { get; set; }

    public string Ci { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public virtual Veterinario? Veterinario { get; set; }
}

using System;
using System.Collections.Generic;

namespace Veterinaria.Models;

public partial class Vacuna
{
    public int IdVacuna { get; set; }

    public string? CodVacuna { get; set; }

    public string Nombre { get; set; } = null!;

    public string? EnfermedadObjetivo { get; set; }

    public virtual ICollection<RegistroVacuna> RegistroVacunas { get; set; } = new List<RegistroVacuna>();
}

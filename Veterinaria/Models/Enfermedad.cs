using System;
using System.Collections.Generic;

namespace Veterinaria.Models;

public partial class Enfermedad
{
    public int IdEnfermedad { get; set; }

    public string? CodEnfermedad { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<HistorialMedico> HistorialMedicos { get; set; } = new List<HistorialMedico>();
}

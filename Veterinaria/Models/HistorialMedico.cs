using System;
using System.Collections.Generic;

namespace Veterinaria.Models;

public partial class HistorialMedico
{
    public int IdHistorial { get; set; }

    public string? CodHistorial { get; set; }

    public int? IdAtencion { get; set; }

    public int? IdEnfermedad { get; set; }

    public string? DiagnosticoDetalle { get; set; }

    public string? Tratamiento { get; set; }

    public virtual Atencion? IdAtencionNavigation { get; set; }

    public virtual Enfermedad? IdEnfermedadNavigation { get; set; }
}

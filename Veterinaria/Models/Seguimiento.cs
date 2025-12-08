using System;
using System.Collections.Generic;

namespace Veterinaria.Models;

public partial class Seguimiento
{
    public int IdSeguimiento { get; set; }

    public int? IdAdopcion { get; set; }

    public DateOnly? FechaVisita { get; set; }

    public string? TipoVisita { get; set; }

    public string? Observaciones { get; set; }

    public string? Estado { get; set; }

    public virtual Adopcion? IdAdopcionNavigation { get; set; }
}

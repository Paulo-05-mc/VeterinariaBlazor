using System;
using System.Collections.Generic;

namespace Veterinaria.Models;

public partial class CuidadoGasto
{
    public int IdGasto { get; set; }

    public int? IdEstadia { get; set; }

    public string? DescripcionGasto { get; set; }

    public decimal? CostoCuidado { get; set; }

    public DateTime? FechaCg { get; set; }

    public virtual Estadium? IdEstadiaNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace Veterinaria.Models;

public partial class Estadium
{
    public int IdEstadia { get; set; }

    public int? IdMascota { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public DateTime? FechaSalida { get; set; }

    public decimal? CostoDiario { get; set; }

    public virtual ICollection<CuidadoGasto> CuidadoGastos { get; set; } = new List<CuidadoGasto>();

    public virtual Mascota? IdMascotaNavigation { get; set; }
}

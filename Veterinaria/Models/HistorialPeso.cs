using System;
using System.Collections.Generic;

namespace Veterinaria.Models;

public partial class HistorialPeso
{
    public int IdPeso { get; set; }

    public int? IdMascota { get; set; }

    public DateOnly? FechaPeso { get; set; }

    public decimal? PesoRegistrado { get; set; }

    public virtual Mascota? IdMascotaNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace Veterinaria.Models;

public partial class RegistroVacuna
{
    public int IdRegistro { get; set; }

    public int? IdMascota { get; set; }

    public int? IdVacuna { get; set; }

    public DateOnly? FechaAplicacion { get; set; }

    public virtual Mascota? IdMascotaNavigation { get; set; }

    public virtual Vacuna? IdVacunaNavigation { get; set; }
}

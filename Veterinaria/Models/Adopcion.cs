using System;
using System.Collections.Generic;

namespace Veterinaria.Models;

public partial class Adopcion
{
    public int IdAdopcion { get; set; }

    public string? CodAdopcion { get; set; }

    public int? IdMascota { get; set; }

    public int? IdPostulante { get; set; }

    public DateOnly? FechaAdopcion { get; set; }

    public decimal? MontoCompromiso { get; set; }

    public virtual Mascota? IdMascotaNavigation { get; set; }

    public virtual Postulante? IdPostulanteNavigation { get; set; }

    public virtual ICollection<Seguimiento> Seguimientos { get; set; } = new List<Seguimiento>();
}

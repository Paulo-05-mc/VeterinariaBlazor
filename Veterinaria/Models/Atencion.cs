using System;
using System.Collections.Generic;

namespace Veterinaria.Models;

public partial class Atencion
{
    public int IdAtencion { get; set; }

    public int? IdMascota { get; set; }

    public int? IdVeterinario { get; set; }

    public DateTime? FechaAtencion { get; set; }

    public string? DescripcionMotivo { get; set; }

    public decimal? Costo { get; set; }

    public decimal? Bonificacion { get; set; }

    public virtual ICollection<HistorialMedico> HistorialMedicos { get; set; } = new List<HistorialMedico>();

    public virtual Mascota? IdMascotaNavigation { get; set; }
}

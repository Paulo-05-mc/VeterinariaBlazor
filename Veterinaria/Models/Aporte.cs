using System;
using System.Collections.Generic;

namespace Veterinaria.Models;

public partial class Aporte
{
    public int IdAporte { get; set; }

    public string? CodAporte { get; set; }

    public int? IdDonante { get; set; }

    public DateOnly? FechaAporte { get; set; }

    public decimal? MontoDonado { get; set; }

    public virtual Donante? IdDonanteNavigation { get; set; }
}

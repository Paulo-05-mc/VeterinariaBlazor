using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinaria.Models;

[Table("mascota")]
public partial class Mascota
{
    [Key]
    [Column("id_mascota")]
    public int IdMascota { get; set; }

    [Column("id_cliente")]
    public int? IdCliente { get; set; } // Puede ser nulo (si es del refugio)

    [Column("cod_mascota")]
    public string? CodMascota { get; set; }

    [Column("nombre")]
    public string Nombre { get; set; } = null!;

    [Column("especie")]
    public string Especie { get; set; } = null!;

    [Column("raza")]
    public string? Raza { get; set; }

    [Column("color_pelaje")]
    public string? ColorPelaje { get; set; }

    [Column("sexo")]
    public string? Sexo { get; set; }

    [Column("fecha_nacimiento")]
    public DateOnly? FechaNacimiento { get; set; } // O DateTime, según prefieras en C#

    [Column("peso_actual")]
    public decimal? PesoActual { get; set; }

    [Column("es_rescatado")]
    public bool? EsRescatado { get; set; }

    // Navegación hacia el dueño
    [ForeignKey("IdCliente")]
    public virtual Cliente? IdClienteNavigation { get; set; }
}
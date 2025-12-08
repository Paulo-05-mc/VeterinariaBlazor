using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinaria.Models;

[Table("postulante")]
public partial class Postulante
{
    [Key]
    [Column("id_postulante")]
    public int IdPostulante { get; set; }

    [Column("nombre_completo")]
    public string? NombreCompleto { get; set; }

    [Column("direccion")]
    public string? Direccion { get; set; }

    // --- ESTE ES EL NUEVO CAMPO ---
    [Column("telefono")]
    public string? Telefono { get; set; }
    // ------------------------------

    [Column("condicion_vivienda")]
    public string? CondicionVivienda { get; set; }

    [Column("preferencia_mascota")]
    public string? PreferenciaMascota { get; set; }

    public virtual ICollection<Adopcion> Adopcions { get; set; } = new List<Adopcion>();
}
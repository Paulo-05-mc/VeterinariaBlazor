using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinaria.Models;

[Table("cliente")] // Asegura que mapee a la tabla 'cliente' de Postgres
public partial class Cliente
{
    [Key]
    [Column("id_cliente")]
    public int IdCliente { get; set; }

    [Column("cod_cliente")]
    public string? CodCliente { get; set; }

    [Column("nombre_familia")]
    public string? NombreFamilia { get; set; } // En tu SQL es NOT NULL, cuidado en el form

    [Column("cuenta_banco")]
    public string? CuentaBanco { get; set; }

    [Column("fecha_asoc")]
    public DateOnly? FechaAsoc { get; set; }

    // --- NUEVOS CAMPOS ---
    [Column("direccion")]
    public string? Direccion { get; set; }

    [Column("telefono")]
    public string? Telefono { get; set; }

    [Column("email")]
    public string? Email { get; set; }
    // ---------------------

    // Relación: Un cliente tiene muchas mascotas
    public virtual ICollection<Mascota> Mascota { get; set; } = new List<Mascota>();
}
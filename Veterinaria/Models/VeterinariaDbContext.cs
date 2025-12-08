using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Veterinaria.Models;

namespace Veterinaria.Models;

public partial class VeterinariaDbContext : DbContext
{
    public VeterinariaDbContext()
    {
    }

    public VeterinariaDbContext(DbContextOptions<VeterinariaDbContext> options)
        : base(options)
    {
    }

    // LISTA COMPLETA DE TABLAS
    public virtual DbSet<Adopcion> Adopcions { get; set; }
    public virtual DbSet<Aporte> Aportes { get; set; }
    public virtual DbSet<Atencion> Atencions { get; set; }
    public virtual DbSet<Cliente> Clientes { get; set; }
    public virtual DbSet<CuidadoGasto> CuidadoGastos { get; set; }
    public virtual DbSet<Donante> Donantes { get; set; }
    public virtual DbSet<Enfermedad> Enfermedads { get; set; }
    public virtual DbSet<Estadium> Estadia { get; set; }
    public virtual DbSet<HistorialMedico> HistorialMedicos { get; set; }
    public virtual DbSet<HistorialPeso> HistorialPesos { get; set; }
    public virtual DbSet<Mascota> Mascota { get; set; }
    public virtual DbSet<Persona> Personas { get; set; }
    public virtual DbSet<Postulante> Postulantes { get; set; }
    public virtual DbSet<RegistroVacuna> RegistroVacunas { get; set; }
    public virtual DbSet<Seguimiento> Seguimientos { get; set; }
    public virtual DbSet<Vacuna> Vacunas { get; set; }
    public virtual DbSet<Veterinario> Veterinarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 1. ADOPCION
        modelBuilder.Entity<Adopcion>(entity =>
        {
            entity.HasKey(e => e.IdAdopcion).HasName("adopcion_pkey");
            entity.ToTable("adopcion");
            entity.Property(e => e.IdAdopcion).HasColumnName("id_adopcion");
            entity.Property(e => e.CodAdopcion).HasMaxLength(20).HasColumnName("cod_adopcion");
            entity.Property(e => e.FechaAdopcion).HasDefaultValueSql("CURRENT_DATE").HasColumnName("fecha_adopcion");
            entity.Property(e => e.IdMascota).HasColumnName("id_mascota");
            entity.Property(e => e.IdPostulante).HasColumnName("id_postulante");
            entity.Property(e => e.MontoCompromiso).HasPrecision(10, 2).HasColumnName("monto_compromiso");

            entity.HasOne(d => d.IdMascotaNavigation).WithMany()
                .HasForeignKey(d => d.IdMascota)
                .HasConstraintName("adopcion_id_mascota_fkey");

            entity.HasOne(d => d.IdPostulanteNavigation).WithMany(p => p.Adopcions)
                .HasForeignKey(d => d.IdPostulante)
                .HasConstraintName("adopcion_id_postulante_fkey");
        });

        // 2. APORTE
        modelBuilder.Entity<Aporte>(entity =>
        {
            entity.HasKey(e => e.IdAporte).HasName("aporte_pkey");
            entity.ToTable("aporte");
            entity.Property(e => e.IdAporte).HasColumnName("id_aporte");
            entity.Property(e => e.CodAporte).HasMaxLength(20).HasColumnName("cod_aporte");
            entity.Property(e => e.FechaAporte).HasDefaultValueSql("CURRENT_DATE").HasColumnName("fecha_aporte");
            entity.Property(e => e.IdDonante).HasColumnName("id_donante");
            entity.Property(e => e.MontoDonado).HasPrecision(10, 2).HasColumnName("monto_donado");

            entity.HasOne(d => d.IdDonanteNavigation).WithMany(p => p.Aportes)
                .HasForeignKey(d => d.IdDonante)
                .HasConstraintName("aporte_id_donante_fkey");
        });

        // 3. ATENCION
        modelBuilder.Entity<Atencion>(entity =>
        {
            entity.HasKey(e => e.IdAtencion).HasName("atencion_pkey");
            entity.ToTable("atencion");
            entity.Property(e => e.IdAtencion).HasColumnName("id_atencion");
            entity.Property(e => e.Bonificacion).HasPrecision(10, 2).HasDefaultValueSql("0").HasColumnName("bonificacion");
            entity.Property(e => e.Costo).HasPrecision(10, 2).HasColumnName("costo");
            entity.Property(e => e.DescripcionMotivo).HasColumnName("descripcion_motivo");
            entity.Property(e => e.FechaAtencion).HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnType("timestamp without time zone").HasColumnName("fecha_atencion");
            entity.Property(e => e.IdMascota).HasColumnName("id_mascota");
            entity.Property(e => e.IdVeterinario).HasColumnName("id_veterinario");

            entity.HasOne(d => d.IdMascotaNavigation).WithMany()
                .HasForeignKey(d => d.IdMascota)
                .HasConstraintName("atencion_id_mascota_fkey");
        });

        // 4. CLIENTE
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("cliente_pkey");
            entity.ToTable("cliente");
            entity.HasIndex(e => e.CodCliente, "cliente_cod_cliente_key").IsUnique();

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.CodCliente).HasMaxLength(20).HasColumnName("cod_cliente");
            entity.Property(e => e.CuentaBanco).HasMaxLength(50).HasColumnName("cuenta_banco");
            entity.Property(e => e.FechaAsoc).HasDefaultValueSql("CURRENT_DATE").HasColumnName("fecha_asoc");
            entity.Property(e => e.NombreFamilia).HasMaxLength(100).HasColumnName("nombre_familia");
            entity.Property(e => e.Direccion).HasColumnName("direccion");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
            entity.Property(e => e.Email).HasColumnName("email");
        });

        // 5. CUIDADO GASTO (¡ESTO FALTABA!)
        modelBuilder.Entity<CuidadoGasto>(entity =>
        {
            entity.HasKey(e => e.IdGasto).HasName("cuidado_gastos_pkey");
            entity.ToTable("cuidado_gastos");
            entity.Property(e => e.IdGasto).HasColumnName("id_gasto");
            entity.Property(e => e.CostoCuidado).HasPrecision(10, 2).HasColumnName("costo_cuidado");
            entity.Property(e => e.DescripcionGasto).HasMaxLength(255).HasColumnName("descripcion_gasto");
            entity.Property(e => e.FechaCg).HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnType("timestamp without time zone").HasColumnName("fecha_cg");
            entity.Property(e => e.IdEstadia).HasColumnName("id_estadia");

            entity.HasOne(d => d.IdEstadiaNavigation).WithMany(p => p.CuidadoGastos)
                .HasForeignKey(d => d.IdEstadia)
                .HasConstraintName("cuidado_gastos_id_estadia_fkey");
        });

        // 6. DONANTE (TAMBIÉN FALTABA)
        modelBuilder.Entity<Donante>(entity =>
        {
            entity.HasKey(e => e.IdDonante).HasName("donante_pkey");
            entity.ToTable("donante");
            entity.Property(e => e.IdDonante).HasColumnName("id_donante");
            entity.Property(e => e.CompromisoMontoMensual).HasPrecision(10, 2).HasColumnName("compromiso_monto_mensual");
            entity.Property(e => e.NombreCompleto).HasMaxLength(200).HasColumnName("nombre_completo");
        });

        // 7. ENFERMEDAD (TAMBIÉN FALTABA)
        modelBuilder.Entity<Enfermedad>(entity =>
        {
            entity.HasKey(e => e.IdEnfermedad).HasName("enfermedad_pkey");
            entity.ToTable("enfermedad");
            entity.Property(e => e.IdEnfermedad).HasColumnName("id_enfermedad");
            entity.Property(e => e.CodEnfermedad).HasMaxLength(20).HasColumnName("cod_enfermedad");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Nombre).HasMaxLength(100).HasColumnName("nombre");
        });

        // 8. ESTADIA
        modelBuilder.Entity<Estadium>(entity =>
        {
            entity.HasKey(e => e.IdEstadia).HasName("estadia_pkey");
            entity.ToTable("estadia");
            entity.Property(e => e.IdEstadia).HasColumnName("id_estadia");
            entity.Property(e => e.CostoDiario).HasPrecision(10, 2).HasColumnName("costo_diario");
            entity.Property(e => e.FechaIngreso).HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnType("timestamp without time zone").HasColumnName("fecha_ingreso");
            entity.Property(e => e.FechaSalida).HasColumnType("timestamp without time zone").HasColumnName("fecha_salida");
            entity.Property(e => e.IdMascota).HasColumnName("id_mascota");

            entity.HasOne(d => d.IdMascotaNavigation).WithMany()
                .HasForeignKey(d => d.IdMascota)
                .HasConstraintName("estadia_id_mascota_fkey");
        });

        // 9. HISTORIAL MEDICO (TAMBIÉN FALTABA)
        modelBuilder.Entity<HistorialMedico>(entity =>
        {
            entity.HasKey(e => e.IdHistorial).HasName("historial_medico_pkey");
            entity.ToTable("historial_medico");
            entity.Property(e => e.IdHistorial).HasColumnName("id_historial");
            entity.Property(e => e.CodHistorial).HasMaxLength(20).HasColumnName("cod_historial");
            entity.Property(e => e.DiagnosticoDetalle).HasColumnName("diagnostico_detalle");
            entity.Property(e => e.IdAtencion).HasColumnName("id_atencion");
            entity.Property(e => e.IdEnfermedad).HasColumnName("id_enfermedad");
            entity.Property(e => e.Tratamiento).HasColumnName("tratamiento");

            entity.HasOne(d => d.IdAtencionNavigation).WithMany(p => p.HistorialMedicos)
                .HasForeignKey(d => d.IdAtencion)
                .HasConstraintName("historial_medico_id_atencion_fkey");

            entity.HasOne(d => d.IdEnfermedadNavigation).WithMany(p => p.HistorialMedicos)
                .HasForeignKey(d => d.IdEnfermedad)
                .HasConstraintName("historial_medico_id_enfermedad_fkey");
        });

        // 10. HISTORIAL PESO
        modelBuilder.Entity<HistorialPeso>(entity =>
        {
            entity.HasKey(e => e.IdPeso).HasName("historial_peso_pkey");
            entity.ToTable("historial_peso");
            entity.Property(e => e.IdPeso).HasColumnName("id_peso");
            entity.Property(e => e.FechaPeso).HasDefaultValueSql("CURRENT_DATE").HasColumnName("fecha_peso");
            entity.Property(e => e.IdMascota).HasColumnName("id_mascota");
            entity.Property(e => e.PesoRegistrado).HasPrecision(5, 2).HasColumnName("peso_registrado");

            entity.HasOne(d => d.IdMascotaNavigation).WithMany()
                .HasForeignKey(d => d.IdMascota)
                .HasConstraintName("historial_peso_id_mascota_fkey");
        });

        // 11. MASCOTA
        modelBuilder.Entity<Mascota>(entity =>
        {
            entity.HasKey(e => e.IdMascota).HasName("mascota_pkey");
            entity.ToTable("mascota");
            entity.HasIndex(e => e.CodMascota, "mascota_cod_mascota_key").IsUnique();

            entity.Property(e => e.IdMascota).HasColumnName("id_mascota");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Nombre).HasMaxLength(100).HasColumnName("nombre");
            entity.Property(e => e.Especie).HasMaxLength(50).HasColumnName("especie");
            entity.Property(e => e.Raza).HasMaxLength(50).HasColumnName("raza");
            entity.Property(e => e.ColorPelaje).HasMaxLength(50).HasColumnName("color_pelaje");
            entity.Property(e => e.Sexo).HasMaxLength(10).HasColumnName("sexo");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.PesoActual).HasPrecision(5, 2).HasColumnName("peso_actual");
            entity.Property(e => e.EsRescatado).HasDefaultValue(false).HasColumnName("es_rescatado");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("mascota_id_cliente_fkey");
        });

        // 12. PERSONA
        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("persona_pkey");
            entity.ToTable("persona");
            entity.HasIndex(e => e.Ci, "persona_ci_key").IsUnique();
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.Nombres).HasMaxLength(100).HasColumnName("nombres");
            entity.Property(e => e.Apellidos).HasMaxLength(100).HasColumnName("apellidos");
            entity.Property(e => e.Ci).HasMaxLength(20).HasColumnName("ci");
            entity.Property(e => e.Direccion).HasMaxLength(255).HasColumnName("direccion");
            entity.Property(e => e.Email).HasMaxLength(100).HasColumnName("email");
            entity.Property(e => e.Telefono).HasMaxLength(20).HasColumnName("telefono");
        });

        // 13. POSTULANTE
        modelBuilder.Entity<Postulante>(entity =>
        {
            entity.HasKey(e => e.IdPostulante).HasName("postulante_pkey");
            entity.ToTable("postulante");
            entity.Property(e => e.IdPostulante).HasColumnName("id_postulante");
            entity.Property(e => e.CondicionVivienda).HasColumnName("condicion_vivienda");
            entity.Property(e => e.Telefono).HasMaxLength(50).HasColumnName("telefono");
            entity.Property(e => e.Direccion).HasMaxLength(255).HasColumnName("direccion");
            entity.Property(e => e.NombreCompleto).HasMaxLength(200).HasColumnName("nombre_completo");
            entity.Property(e => e.PreferenciaMascota).HasMaxLength(100).HasColumnName("preferencia_mascota");
        });

        // 14. REGISTRO VACUNA
        modelBuilder.Entity<RegistroVacuna>(entity =>
        {
            entity.HasKey(e => e.IdRegistro).HasName("registro_vacuna_pkey");
            entity.ToTable("registro_vacuna");
            entity.Property(e => e.IdRegistro).HasColumnName("id_registro");
            entity.Property(e => e.FechaAplicacion).HasDefaultValueSql("CURRENT_DATE").HasColumnName("fecha_aplicacion");
            entity.Property(e => e.IdMascota).HasColumnName("id_mascota");
            entity.Property(e => e.IdVacuna).HasColumnName("id_vacuna");

            entity.HasOne(d => d.IdMascotaNavigation).WithMany()
                .HasForeignKey(d => d.IdMascota)
                .HasConstraintName("registro_vacuna_id_mascota_fkey");

            entity.HasOne(d => d.IdVacunaNavigation).WithMany(p => p.RegistroVacunas)
                .HasForeignKey(d => d.IdVacuna)
                .HasConstraintName("registro_vacuna_id_vacuna_fkey");
        });

        // 15. SEGUIMIENTO (TAMBIÉN FALTABA)
        modelBuilder.Entity<Seguimiento>(entity =>
        {
            entity.HasKey(e => e.IdSeguimiento).HasName("seguimiento_pkey");
            entity.ToTable("seguimiento");
            entity.Property(e => e.IdSeguimiento).HasColumnName("id_seguimiento");
            entity.Property(e => e.Estado).HasMaxLength(50).HasColumnName("estado");
            entity.Property(e => e.FechaVisita).HasColumnName("fecha_visita");
            entity.Property(e => e.IdAdopcion).HasColumnName("id_adopcion");
            entity.Property(e => e.Observaciones).HasColumnName("observaciones");
            entity.Property(e => e.TipoVisita).HasMaxLength(50).HasColumnName("tipo_visita");

            entity.HasOne(d => d.IdAdopcionNavigation).WithMany(p => p.Seguimientos)
                .HasForeignKey(d => d.IdAdopcion)
                .HasConstraintName("seguimiento_id_adopcion_fkey");
        });

        // 16. VACUNA (TAMBIÉN FALTABA)
        modelBuilder.Entity<Vacuna>(entity =>
        {
            entity.HasKey(e => e.IdVacuna).HasName("vacuna_pkey");
            entity.ToTable("vacuna");
            entity.Property(e => e.IdVacuna).HasColumnName("id_vacuna");
            entity.Property(e => e.CodVacuna).HasMaxLength(20).HasColumnName("cod_vacuna");
            entity.Property(e => e.EnfermedadObjetivo).HasMaxLength(100).HasColumnName("enfermedad_objetivo");
            entity.Property(e => e.Nombre).HasMaxLength(100).HasColumnName("nombre");
        });

        // 17. VETERINARIO
        // 17. VETERINARIO (CORREGIDO)
        modelBuilder.Entity<Veterinario>(entity =>
        {
            entity.HasKey(e => e.IdVeterinario).HasName("veterinario_pkey");
            entity.ToTable("veterinario");

            entity.Property(e => e.IdVeterinario).ValueGeneratedNever().HasColumnName("id_veterinario");

            // --- ESTA LÍNEA FALTABA Y CAUSABA EL ERROR ---
            entity.Property(e => e.CodVeterinario).HasMaxLength(20).HasColumnName("cod_veterinario");
            // ---------------------------------------------

            entity.Property(e => e.Especialidad).HasMaxLength(100).HasColumnName("especialidad");
            entity.Property(e => e.Sueldo).HasPrecision(10, 2).HasColumnName("sueldo");

            entity.HasOne(d => d.IdVeterinarioNavigation)
                  .WithOne(p => p.Veterinario)
                  .HasForeignKey<Veterinario>(d => d.IdVeterinario)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("veterinario_id_veterinario_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
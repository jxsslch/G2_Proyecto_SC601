using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace G2_Proyecto_SC601.Models;

public partial class SistemaEmpresarialContext : DbContext
{
    public SistemaEmpresarialContext()
    {
    }

    public SistemaEmpresarialContext(DbContextOptions<SistemaEmpresarialContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Canton> Cantons { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Lenguaje> Lenguajes { get; set; }

    public virtual DbSet<MetodoPago> MetodoPagos { get; set; }

    public virtual DbSet<Monedum> Moneda { get; set; }

    public virtual DbSet<Provincium> Provincia { get; set; }

    public virtual DbSet<Transaccione> Transacciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Canton>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Canton__3214EC27217265AE");

            entity.ToTable("Canton");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProvinciaId).HasColumnName("ProvinciaID");

            entity.HasOne(d => d.Provincia).WithMany(p => p.Cantons)
                .HasForeignKey(d => d.ProvinciaId)
                .HasConstraintName("FK_PROVINCIA");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Cedula).HasName("PK__Cliente__B4ADFE3913C56B6A");

            entity.ToTable("Cliente");

            entity.Property(e => e.Cedula).ValueGeneratedNever();
            entity.Property(e => e.CantonId).HasColumnName("CantonID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmpresaId).HasColumnName("EmpresaID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NumTelefono).HasColumnName("numTelefono");
            entity.Property(e => e.ProvinciaId).HasColumnName("ProvinciaID");

            entity.HasOne(d => d.Canton).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.CantonId)
                .HasConstraintName("FK_CANTON");

            entity.HasOne(d => d.Empresa).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK_EMPRESA");

            entity.HasOne(d => d.Provincia).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.ProvinciaId)
                .HasConstraintName("FK_PROVINCIA_CLIENTE");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Empresa__3214EC27057E6D1B");

            entity.ToTable("Empresa");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NumTelefono).HasColumnName("numTelefono");
        });

        modelBuilder.Entity<Lenguaje>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lenguaje__3214EC2722B02704");

            entity.ToTable("Lenguaje");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MetodoPago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MetodoPa__3214EC276504674F");

            entity.ToTable("MetodoPago");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Monedum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Moneda__3214EC27698DEAD3");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Provincium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Provinci__3214EC27B3D70985");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Transaccione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transacc__3214EC27EEAA6BC9");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.LenguajeId).HasColumnName("LenguajeID");
            entity.Property(e => e.MetodoPagoId).HasColumnName("MetodoPagoID");
            entity.Property(e => e.MonedaId).HasColumnName("MonedaID");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK_CLIENTE");

            entity.HasOne(d => d.Lenguaje).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.LenguajeId)
                .HasConstraintName("FK_LENGUAJE");

            entity.HasOne(d => d.MetodoPago).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.MetodoPagoId)
                .HasConstraintName("FK_METODOPAGO");

            entity.HasOne(d => d.Moneda).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.MonedaId)
                .HasConstraintName("FK_MONEDA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

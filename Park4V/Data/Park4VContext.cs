using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Park4VMariaSolucion.Models;

namespace Park4VMariaSolucion.Data;

public partial class Park4VContext : DbContext
{
    public Park4VContext()
    {
    }

    public Park4VContext(DbContextOptions<Park4VContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ciudad> Ciudades { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Estacionamiento> Estacionamientos { get; set; }

    public virtual DbSet<Zona> Zonas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ciudades__3214EC07CB78D620");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__Clientes__A9D10535CF16C448");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Saldo).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<Estacionamiento>(entity =>
        {
            entity.HasKey(e => new { e.Email, e.NumMovimiento }).HasName("PK__Estacion__814EEDD7E2F80E9A");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FechaHoraFin).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraInicio).HasColumnType("datetime");
            entity.Property(e => e.Matricula).HasMaxLength(255);
            entity.Property(e => e.Zona).HasMaxLength(255);

            entity.HasOne(d => d.EmailNavigation).WithMany(p => p.Estacionamientos)
                .HasForeignKey(d => d.Email)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Estacionamientos_Clientes");

            entity.HasOne(d => d.ZonaNavigation).WithMany(p => p.Estacionamientos)
                .HasForeignKey(d => new { d.IdCiudad, d.Zona })
                .HasConstraintName("FK_Estacionamiento_Zonas");
        });

        modelBuilder.Entity<Zona>(entity =>
        {
            entity.HasKey(e => new { e.IdCiudad, e.Zona1 }).HasName("PK__Zonas__293A2AF86DAFD967");

            entity.Property(e => e.Zona1)
                .HasMaxLength(255)
                .HasColumnName("Zona");
            entity.Property(e => e.PrecioMinuto).HasColumnType("money");

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Zonas)
                .HasForeignKey(d => d.IdCiudad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Zonas_Ciudades");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

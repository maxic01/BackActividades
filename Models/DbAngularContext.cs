using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackActividades.Models;

public partial class DbAngularContext : DbContext
{
    public DbAngularContext()
    {
    }

    public DbAngularContext(DbContextOptions<DbAngularContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actividade> Actividades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actividade>(entity =>
        {
            entity.HasKey(e => e.IdActividad).HasName("PK__Activida__327F9BED4408EC12");

            entity.Property(e => e.IdActividad).HasColumnName("idActividad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

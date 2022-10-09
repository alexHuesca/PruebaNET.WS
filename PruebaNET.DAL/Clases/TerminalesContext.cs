using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PruebaNET.Objetos.Clases.Terminales;

namespace PruebaNET.DAL.Clases
{
    public partial class TerminalesContext : DbContext
    {
        public TerminalesContext()
        {
        }

        public TerminalesContext(DbContextOptions<TerminalesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<Fabricante> Fabricantes { get; set; } = null!;
        public virtual DbSet<Terminale> Terminales { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-VBNBBS3;Database=Terminales;User Id=DBPruebasNET;Password=H456789b;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado);

                entity.ToTable("estado");

                entity.Property(e => e.IdEstado)
                    .ValueGeneratedNever()
                    .HasColumnName("id_estado");

                entity.Property(e => e.EstadoDesc)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("estado_desc");

                entity.Property(e => e.EstadoName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("estado_name");
            });

            modelBuilder.Entity<Fabricante>(entity =>
            {
                entity.HasKey(e => e.IdFab);

                entity.ToTable("fabricantes");

                entity.Property(e => e.IdFab)
                    .ValueGeneratedNever()
                    .HasColumnName("id_fab");

                entity.Property(e => e.FabDesc)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("fab_desc");

                entity.Property(e => e.FabName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fab_name");
            });

            modelBuilder.Entity<Terminale>(entity =>
            {
                entity.HasKey(e => e.IdTerminal);

                entity.ToTable("terminales");

                entity.Property(e => e.IdTerminal)
                    .ValueGeneratedNever()
                    .HasColumnName("id_terminal");

                entity.Property(e => e.FechaEstado)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("fecha_estado");

                entity.Property(e => e.FechaFabricacion)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("fecha_fabricacion");

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");

                entity.Property(e => e.IdFab).HasColumnName("id_fab");

                entity.Property(e => e.TerminalDesc)
                    .HasMaxLength(200)
                    .HasColumnName("terminal_desc");

                entity.Property(e => e.TerminalName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("terminal_name");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Terminales)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK_terminales_terminales");

                entity.HasOne(d => d.IdFabNavigation)
                    .WithMany(p => p.Terminales)
                    .HasForeignKey(d => d.IdFab)
                    .HasConstraintName("FK_terminales_fabricantes");
            });

            OnModelCreatingPartial(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

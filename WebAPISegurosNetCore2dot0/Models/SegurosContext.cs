using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebAPISegurosNetCore2dot0.Models
{
    public partial class SegurosContext : DbContext
    {
        public SegurosContext()
        {
        }

        public SegurosContext(DbContextOptions<SegurosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Descripcion> Descripcion { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Modelo> Modelo { get; set; }
        public virtual DbSet<SubMarca> SubMarca { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-PIC2FSAE;Initial Catalog=Seguros;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Descripcion>(entity =>
            {
                entity.Property(e => e.DescripcionId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion1)
                    .IsRequired()
                    .HasColumnName("Descripcion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdModeloNavigation)
                    .WithMany(p => p.Descripcion)
                    .HasForeignKey(d => d.IdModelo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Descripcion_Modelo");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca);

                entity.Property(e => e.Marca1)
                    .IsRequired()
                    .HasColumnName("Marca")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.HasKey(e => e.IdModelo);

                entity.Property(e => e.Modelo1).HasColumnName("Modelo");

                entity.HasOne(d => d.IdSubMarcaNavigation)
                    .WithMany(p => p.Modelo)
                    .HasForeignKey(d => d.IdSubMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Modelo_SubMarca");
            });

            modelBuilder.Entity<SubMarca>(entity =>
            {
                entity.HasKey(e => e.IdSubMarca);

                entity.Property(e => e.SubMarca1)
                    .IsRequired()
                    .HasColumnName("SubMarca")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.SubMarca)
                    .HasForeignKey(d => d.IdMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubMarca_Marca");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

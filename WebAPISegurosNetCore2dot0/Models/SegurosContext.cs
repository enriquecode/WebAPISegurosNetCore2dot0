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

        public virtual DbSet<CodigoPostal> CodigoPostal { get; set; }
        public virtual DbSet<Colonia> Colonia { get; set; }
        public virtual DbSet<Descripcion> Descripcion { get; set; }
        public virtual DbSet<Entidad> Entidad { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Modelo> Modelo { get; set; }
        public virtual DbSet<Municipio> Municipio { get; set; }
        public virtual DbSet<SubMarca> SubMarca { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-PIC2FSAE;Initial Catalog=Seguros;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CodigoPostal>(entity =>
            {
                entity.Property(e => e.CodigoPostalNumero)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.Municipio)
                    .WithMany(p => p.CodigoPostal)
                    .HasForeignKey(d => d.MunicipioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CodigoPostalMunicipio");
            });

            modelBuilder.Entity<Colonia>(entity =>
            {
                entity.Property(e => e.ColoniaNombre)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoPostal)
                    .WithMany(p => p.Colonia)
                    .HasForeignKey(d => d.CodigoPostalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ColoniaCodigoPostal");
            });

            modelBuilder.Entity<Descripcion>(entity =>
            {
                entity.Property(e => e.DescripcionId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionDetallada)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Modelo)
                    .WithMany(p => p.Descripcion)
                    .HasForeignKey(d => d.ModeloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Descripcion_Modelo");
            });

            modelBuilder.Entity<Entidad>(entity =>
            {
                entity.HasIndex(e => e.ClaveEntidad)
                    .HasName("UNIQEntidad")
                    .IsUnique();

                entity.Property(e => e.ClaveEntidad)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.EntidadNombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.Property(e => e.MarcaDescripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.HasOne(d => d.SubMarca)
                    .WithMany(p => p.Modelo)
                    .HasForeignKey(d => d.SubMarcaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Modelo_SubMarca");
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.Property(e => e.MunicipioNombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Entidad)
                    .WithMany(p => p.Municipio)
                    .HasForeignKey(d => d.EntidadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MunicipioEntidad");
            });

            modelBuilder.Entity<SubMarca>(entity =>
            {
                entity.Property(e => e.SubMarcaDescripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.SubMarca)
                    .HasForeignKey(d => d.MarcaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubMarca_Marca");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

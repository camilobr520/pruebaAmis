using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AmisCamiloBautista.Dominio.Models
{
    public partial class PruebaAmisContext : DbContext
    {
        public PruebaAmisContext()
        {
        }

        public PruebaAmisContext(DbContextOptions<PruebaAmisContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Inscripcione> Inscripciones { get; set; }
        public virtual DbSet<Lineacarrera> Lineacarreras { get; set; }
        public virtual DbSet<Modalidade> Modalidades { get; set; }
        public virtual DbSet<Profesore> Profesores { get; set; }
        public virtual DbSet<Tipocurso> Tipocursos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-PCAJPIH\\SQLEXPRESS01;DataBase=PruebaAmis;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("categorias");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.ToTable("cursos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DuracionHoras).HasColumnName("duracion_horas");

                entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");

                entity.Property(e => e.Idlineacarrera).HasColumnName("idlineacarrera");

                entity.Property(e => e.Idmodalidad).HasColumnName("idmodalidad");

                entity.Property(e => e.Idprofesor).HasColumnName("idprofesor");

                entity.Property(e => e.Idtipo).HasColumnName("idtipo");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.Idcategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cursos_categorias");

                entity.HasOne(d => d.IdlineacarreraNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.Idlineacarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cursos_lineacarrera");

                entity.HasOne(d => d.IdmodalidadNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.Idmodalidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cursos_modalidades");

                entity.HasOne(d => d.IdtipoNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.Idtipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cursos_tipocurso");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.ToTable("estudiantes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("apellidos");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.Hobbies)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("hobbies");

                entity.Property(e => e.Idgenero).HasColumnName("idgenero");

                entity.Property(e => e.LugarNacimiento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lugar_nacimiento");

                entity.Property(e => e.LugarResidencia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lugar_residencia");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.ToTable("genero");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Inscripcione>(entity =>
            {
                entity.ToTable("inscripciones");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idcurso).HasColumnName("idcurso");

                entity.Property(e => e.Idestudiante).HasColumnName("idestudiante");
            });

            modelBuilder.Entity<Lineacarrera>(entity =>
            {
                entity.ToTable("lineacarrera");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Modalidade>(entity =>
            {
                entity.ToTable("modalidades");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Profesore>(entity =>
            {
                entity.ToTable("profesores");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("apellidos");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.Hobbies)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("hobbies");

                entity.Property(e => e.Idgenero).HasColumnName("idgenero");

                entity.Property(e => e.LugarNacimiento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lugar_nacimiento");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Tipocurso>(entity =>
            {
                entity.ToTable("tipocurso");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CLCDal.Models.DB
{
    public partial class BBDD_AvanadeContext : DbContext
    {
        public BBDD_AvanadeContext()
        {
        }

        public BBDD_AvanadeContext(DbContextOptions<BBDD_AvanadeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Direcciones> Direcciones { get; set; }
        public virtual DbSet<Emails> Emails { get; set; }
        public virtual DbSet<EmpleadoValoraciones> EmpleadoValoraciones { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<EmpleadosEmails> EmpleadosEmails { get; set; }
        public virtual DbSet<Jornadas> Jornadas { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<PerDir> PerDir { get; set; }
        public virtual DbSet<Personas> Personas { get; set; }
        public virtual DbSet<Provincias> Provincias { get; set; }
        public virtual DbSet<Valoraciones> Valoraciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BBDD_Avanade;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Direcciones>(entity =>
            {
                entity.Property(e => e.Calle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cp).HasColumnName("CP");

                entity.Property(e => e.Localidad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Piso)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPaisNavigation)
                    .WithMany(p => p.Direcciones)
                    .HasForeignKey(d => d.IdPais)
                    .HasConstraintName("FK_Direcciones_Pais");

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Direcciones)
                    .HasForeignKey(d => d.IdProvincia)
                    .HasConstraintName("FK_Direcciones_Provincias");
            });

            modelBuilder.Entity<Emails>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmpleadoValoraciones>(entity =>
            {
                entity.ToTable("Empleado_Valoraciones");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.EmpleadoValoraciones)
                    .HasForeignKey(d => d.EmpleadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLEADOVALORACIONES_EMPLEADOS");

                entity.HasOne(d => d.Valoracion)
                    .WithMany(p => p.EmpleadoValoraciones)
                    .HasForeignKey(d => d.ValoracionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLEADOVALORACIONES_VALORACIONES");
            });

            modelBuilder.Entity<Empleados>(entity =>
            {
                entity.Property(e => e.FechaAlta).HasColumnType("date");

                entity.Property(e => e.FechaBaja).HasColumnType("date");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.CategoriaId)
                    .HasConstraintName("FK_Empleados_Categoria");

                entity.HasOne(d => d.Jornada)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.JornadaId)
                    .HasConstraintName("FK_Empleados_Jornadas");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.PersonaId)
                    .HasConstraintName("FK_Empleados_Persona");
            });

            modelBuilder.Entity<EmpleadosEmails>(entity =>
            {
                entity.ToTable("Empleados_Emails");

                entity.HasOne(d => d.IdEmailNavigation)
                    .WithMany(p => p.EmpleadosEmails)
                    .HasForeignKey(d => d.IdEmail)
                    .HasConstraintName("FK_Empleados_Emails_IdEmail");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.EmpleadosEmails)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("FK_Empleados_Emails_IdEmpleado");
            });

            modelBuilder.Entity<Jornadas>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Paises>(entity =>
            {
                entity.HasIndex(e => e.Nombre)
                    .HasName("UQ__Paises__75E3EFCF62E77B09")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PerDir>(entity =>
            {
                entity.ToTable("Per_Dir");

                entity.Property(e => e.DirId).HasColumnName("Dir_Id");

                entity.Property(e => e.PerId).HasColumnName("Per_Id");

                entity.HasOne(d => d.Dir)
                    .WithMany(p => p.PerDir)
                    .HasForeignKey(d => d.DirId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DIRECCIONES_PER_DIR");

                entity.HasOne(d => d.Per)
                    .WithMany(p => p.PerDir)
                    .HasForeignKey(d => d.PerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERSONAS_PER_dIR");
            });

            modelBuilder.Entity<Personas>(entity =>
            {
                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .HasColumnName("DNI")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Provincias>(entity =>
            {
                entity.HasIndex(e => e.Nombre)
                    .HasName("UQ__Provinci__75E3EFCF02D72F9C")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Valoraciones>(entity =>
            {
                entity.Property(e => e.Comentario)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}

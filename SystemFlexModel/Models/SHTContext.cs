namespace SystemFlexModel.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SHTContext : DbContext
    {
        public SHTContext()
            : base("name=SHTContext")
        {
        }

        public virtual DbSet<CatalogoPersonas> CatalogoPersonas { get; set; }
        public virtual DbSet<DetalleHospedaje> DetalleHospedaje { get; set; }
        public virtual DbSet<Habitacion> Habitacion { get; set; }
        public virtual DbSet<Infantes> Infantes { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<OpcioneMenu> OpcioneMenu { get; set; }
        public virtual DbSet<Perfiles> Perfiles { get; set; }
        public virtual DbSet<PerfilesOpcionMenu> PerfilesOpcionMenu { get; set; }
        public virtual DbSet<PerfilUsuario> PerfilUsuario { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Identificador)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .HasMany(e => e.OpcioneMenu)
                .WithRequired(e => e.Menu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OpcioneMenu>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<OpcioneMenu>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<OpcioneMenu>()
                .Property(e => e.Identificador)
                .IsUnicode(false);

            modelBuilder.Entity<OpcioneMenu>()
                .HasMany(e => e.PerfilesOpcionMenu)
                .WithRequired(e => e.OpcioneMenu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Perfiles>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Perfiles>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Perfiles>()
                .HasMany(e => e.PerfilesOpcionMenu)
                .WithRequired(e => e.Perfiles)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Perfiles>()
                .HasMany(e => e.PerfilUsuario)
                .WithRequired(e => e.Perfiles)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Usuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Clave)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.ImagenUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .HasMany(e => e.PerfilUsuario)
                .WithRequired(e => e.Usuarios)
                .WillCascadeOnDelete(false);
        }
    }
}

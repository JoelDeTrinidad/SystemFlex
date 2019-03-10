namespace SystemFlexModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuarios()
        {
            PerfilUsuario = new HashSet<PerfilUsuario>();
        }

        [Key]
        public int UsuarioId { get; set; }

        [Required]
        [StringLength(64)]
        public string Nombres { get; set; }

        [StringLength(64)]
        public string Apellidos { get; set; }

        [Required]
        [StringLength(128)]
        public string Usuario { get; set; }

        [Required]
        [StringLength(128)]
        public string Clave { get; set; }

        [Required]
        [StringLength(64)]
        public string Correo { get; set; }

        [StringLength(2048)]
        public string Observaciones { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public DateTime? UltimoAcceso { get; set; }

        [StringLength(512)]
        public string ImagenUrl { get; set; }

        public bool Activo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PerfilUsuario> PerfilUsuario { get; set; }
    }
}

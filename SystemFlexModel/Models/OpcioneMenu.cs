namespace SystemFlexModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OpcioneMenu")]
    public partial class OpcioneMenu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OpcioneMenu()
        {
            PerfilesOpcionMenu = new HashSet<PerfilesOpcionMenu>();
        }

        [Key]
        public int OpcionMenuId { get; set; }

        public int MenuId { get; set; }

        [Required]
        [StringLength(64)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(256)]
        public string Descripcion { get; set; }

        public bool Activo { get; set; }

        [Required]
        [StringLength(100)]
        public string Url { get; set; }

        public short? orden { get; set; }

        [StringLength(128)]
        public string Identificador { get; set; }

        public bool? Visible { get; set; }

        public virtual Menu Menu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PerfilesOpcionMenu> PerfilesOpcionMenu { get; set; }
    }
}

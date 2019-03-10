namespace SystemFlexModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Menu()
        {
            OpcioneMenu = new HashSet<OpcioneMenu>();
        }

        public int MenuId { get; set; }

        [Required]
        [StringLength(64)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(256)]
        public string Descripcion { get; set; }

        public bool Activo { get; set; }

        public short? Orden { get; set; }

        [StringLength(128)]
        public string Identificador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OpcioneMenu> OpcioneMenu { get; set; }
    }
}

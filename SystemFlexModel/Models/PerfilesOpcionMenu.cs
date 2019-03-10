namespace SystemFlexModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PerfilesOpcionMenu")]
    public partial class PerfilesOpcionMenu
    {
        [Key]
        public int PerfilOpcionMenuId { get; set; }

        public short PerfilId { get; set; }

        public int OpcionMenuId { get; set; }

        public bool Crear { get; set; }

        public bool Eliminar { get; set; }

        public virtual OpcioneMenu OpcioneMenu { get; set; }

        public virtual Perfiles Perfiles { get; set; }
    }
}

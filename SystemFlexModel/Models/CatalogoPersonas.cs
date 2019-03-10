namespace SystemFlexModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CatalogoPersonas
    {
        [Key]
        public int CatalogoId { get; set; }

        public int CantidadAdultos { get; set; }

        public int CantidadHabitacion { get; set; }
    }
}

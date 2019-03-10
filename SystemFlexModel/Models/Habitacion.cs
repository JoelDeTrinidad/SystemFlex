namespace SystemFlexModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Habitacion")]
    public partial class Habitacion
    {
        public int HabitacionId { get; set; }

        public int DetalleId { get; set; }

        public int CantidadAdultos { get; set; }
    }
}

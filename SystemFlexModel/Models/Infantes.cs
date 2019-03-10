namespace SystemFlexModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Infantes
    {
        [Key]
        public int InfanteId { get; set; }

        public int HabitacionId { get; set; }

        public int Edad { get; set; }
    }
}

namespace SystemFlexModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetalleHospedaje")]
    public partial class DetalleHospedaje
    {
        [Key]
        public int DetalleId { get; set; }

        public int UsuarioId { get; set; }

        public int? CatalogoId { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaInicial { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaFinal { get; set; }

        public int? Dias { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaCreacion { get; set; }
    }
}

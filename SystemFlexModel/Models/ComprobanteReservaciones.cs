namespace SystemFlexModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ComprobanteReservaciones
    {
        [Key]
        public int ComprobanteId { get; set; }

        public int DetalleId { get; set; }

        public int UsuarioId { get; set; }

        public int? CodigoId { get; set; }

        public int? ExtraId { get; set; }

        [Required]
        [StringLength(64)]
        public string Nombre { get; set; }

        [StringLength(64)]
        public string Apellidos { get; set; }

        [StringLength(64)]
        public string Correo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PagoTotal { get; set; }

        public bool? Pagado { get; set; }

        public virtual CatalogoHabitaciones CatalogoHb { get; set; }

        public virtual HabitacionesReservadas Hbreservada { get; set; }

        public virtual TransaccionPago Transaccion { get; set; }

        
    }
}

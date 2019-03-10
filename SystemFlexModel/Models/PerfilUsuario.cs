namespace SystemFlexModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PerfilUsuario")]
    public partial class PerfilUsuario
    {
        public int PerfilUsuarioId { get; set; }

        public int UsuarioId { get; set; }

        public short PerfilId { get; set; }

        public virtual Perfiles Perfiles { get; set; }

        public virtual Usuarios Usuarios { get; set; }
    }
}

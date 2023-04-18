namespace Data.Models.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CatalogoDestino", Schema = "TES")]
    public class CatalogoDestinoEntity
    {
        [Key]
        public int intTipoCatalogoDestinoKey { get; set; }

        public string vchDescripcion { get; set; }

        public DateTime dtmFechaRegistro { get; set; }

        public string vchUsuarioCaptura { get; set; }

        public bool bitActivo { get; set; }

        public DateTime? dtmFechaElimina { get; set; }

        public string? vchUsuarioElimina { get; set; }
    }
}

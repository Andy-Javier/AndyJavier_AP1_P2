using System.ComponentModel.DataAnnotations.Schema;

namespace AndyJavier_AP1_P2.Models
{
    public class CombosDetalle
    {        
        public int DetalleId { get; set; }
        [ForeignKey(nameof(ComboId))]
        public int ComboId { get; set; }
        [ForeignKey(nameof(ArticuloId))]
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public int Costo { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace AndyJavier_AP1_P2.Models
{
    public class Combos
    {
        [Key]
        public int ComboId { get; set; }
        public int Fecha { get; set; }
        public string? Description { get; set; }
        public decimal Precio { get; set; }
        public string? Vendido { get; set; }
    }
}

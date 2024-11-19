using System.ComponentModel.DataAnnotations;

namespace AndyJavier_AP1_P2.Models
{
    public class Productos
    {
        [Key]
        [Required(ErrorMessage = "El identificador del artículo debe ser mayor a 1.")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "La descripción del artículo es obligatoria.")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Debe proporcionar el costo del artículo.")]
        public decimal Costo { get; set; }

        [Required(ErrorMessage = "Debe especificar el precio del artículo.")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "Debe indicar la cantidad en existencia del artículo.")]
        public int Existencia { get; set; }
    }
}

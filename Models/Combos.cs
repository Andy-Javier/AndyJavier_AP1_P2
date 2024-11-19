using AndyJavier_AP1_P2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndyJavier_AP1_P2.Models;

public class Combos
{
    [Key]
    public int ComboId { get; set; }

    [Required(ErrorMessage = "Debe proporcionar una fecha para el combo.")]
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage = "Es necesario especificar una descripción para el combo.")]
    [StringLength(100, ErrorMessage = "La descripción debe contener un máximo de 100 caracteres.")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "El precio del combo es requerido.")]
    [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un número positivo.")]
    public decimal Precio { get; set; }

    [Required(ErrorMessage = "Debe indicar si el combo ha sido vendido o no.")]
    public bool Vendido { get; set; }

    public ICollection<CombosDetalle>? CombosDetalles { get; set; } = new List<CombosDetalle>();
}

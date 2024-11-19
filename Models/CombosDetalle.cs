using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AndyJavier_AP1_P2.Models;

public class CombosDetalle
{
    [Key]
    public int DetalleId { get; set; }

    [Required(ErrorMessage = "Debe especificar el identificador del combo.")]
    public int ComboId { get; set; }

    [ForeignKey("ComboId")]
    public Combos? Combo { get; set; }

    [Required(ErrorMessage = "Debe proporcionar el identificador del artículo.")]
    public int ProductoId { get; set; }

    [ForeignKey("ProductoId")]
    public Productos? Producto { get; set; }

    [Required(ErrorMessage = "Es necesario ingresar la cantidad.")]
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad mínima debe ser 1.")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "Debe especificar el costo.")]
    [Range(0, double.MaxValue, ErrorMessage = "El costo debe ser un número positivo.")]
    public decimal Costo { get; set; }
}

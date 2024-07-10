using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestBackend.Models;

public class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;
    [Required]
    [Column(TypeName = "decimal(6,2)")]
    public decimal ProductPrice { get; set; }
    public string ? ProductBrand { get; set; }
    [Required]
    public string CategoryName { get; set; } = string.Empty!;
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}

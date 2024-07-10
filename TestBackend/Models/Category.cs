using System.ComponentModel.DataAnnotations;

namespace TestBackend.Models;

public class Category
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public ICollection<Product> Products { get; set; } = null!;
}

using System.ComponentModel.DataAnnotations;

namespace TestBackend.Dtos.ProductDtos;

public record CreateProductDto( [Required] [MaxLength(20)] string Name, [Required] decimal Price, string CategoryName, string Brand);

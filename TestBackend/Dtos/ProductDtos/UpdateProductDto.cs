using TestBackend.Models;

namespace TestBackend.Dtos.ProductDtos;

public record UpdateProductDto(string Name, decimal Price, string Category, string Brand, int CategoryId, string CategoryName);

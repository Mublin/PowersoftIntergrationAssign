using System.ComponentModel.DataAnnotations;

namespace TestBackend.Dtos.ProductDtos;

public record ProductDto(int Id, string Name, decimal Price, string CategoryName, string Brand, int CategoryId);

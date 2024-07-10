using Microsoft.EntityFrameworkCore;

using TestBackend.Data;
using TestBackend.Dtos.ProductDtos;
using TestBackend.Models;
using TestBackend.Dtos.CategoryDtos;
namespace TestBackend.Endpoints;


public static class ProductEndpoint
{
    public static RouteGroupBuilder MapProductEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/product");
        
        group.MapGet("/", async (ProductStoreContext productContext) =>
        {
            var products = await productContext.Products.ToListAsync();
            return Results.Ok(products);
        });


        group.MapPost("/", async (CreateProductDto product, ProductStoreContext productContext) =>
        {
            // Find the category by name
            var category = await productContext.Categories.FirstOrDefaultAsync(c => c.Name == product.CategoryName);
            Console.WriteLine(category);
            if (category == null)
            {
                if (product.CategoryName != null && product.CategoryName != "")
                {
                    Category newCategory = new () { Name = product.CategoryName };
                    category = newCategory;
                    productContext.Categories.Add(newCategory);
                    await productContext.SaveChangesAsync();
                }
                else
                {
                    // Handle case where category is not found
                    return Results.BadRequest("Category not found.");
                }
            }

            // Create a new product entity from the DTO
            Product newProduct = new()
            {
                ProductName = product.Name,
                ProductBrand = product.Brand,
                ProductPrice = product.Price,
                CategoryName = product.CategoryName,
                CategoryId = category.Id
            };

            // Add the new product to the context
            productContext.Products.Add(newProduct);

            // Save the changes asynchronously
            await productContext.SaveChangesAsync();

            // Console output for debugging (can be removed in production)
            Console.WriteLine("Product created successfully.");

            // Create a ProductDto to return
            ProductDto productDto = new(
                Id: newProduct.ProductId,
                Name: newProduct.ProductName,
                Brand: newProduct.ProductBrand,
                Price: newProduct.ProductPrice,
                CategoryName: newProduct.CategoryName,
                CategoryId: newProduct.CategoryId
            );

            // Return the created result with the DTO
            return Results.Created($"/api/product/{newProduct.ProductId}", productDto);
        });

        group.MapPut("/{id}", async (int id, UpdateProductDto updateProduct, ProductStoreContext productContext) => {
            var product = await productContext.Products.SingleOrDefaultAsync(p => p.ProductId == id);
            if (product == null)
            {
                return Results.NotFound();
            }
            var category = await productContext.Categories.FirstOrDefaultAsync(c => c.Name == product.CategoryName);
            if (category == null)
            {
                if (product.CategoryName != null && product.CategoryName != "")
                {
                    Category newCategory = new() { Name = product.CategoryName };
                    category = newCategory;
                    productContext.Categories.Add(newCategory);
                    await productContext.SaveChangesAsync();
                }
                else
                {
                    // Handle case where category is not found
                    return Results.BadRequest("Category not found.");
                }
            }

            Product updatedProduct = new()
            {
                ProductId = id,
                ProductBrand = updateProduct.Brand,
                ProductName = updateProduct.Name,
                ProductPrice= updateProduct.Price,
                CategoryName = updateProduct.CategoryName,
                CategoryId = product.CategoryId,
                Category = product.Category

            };
            productContext.Entry(product).CurrentValues.SetValues(updatedProduct);

            await productContext.SaveChangesAsync();
            return Results.Ok(updatedProduct);
        });


        return group;
    }
}

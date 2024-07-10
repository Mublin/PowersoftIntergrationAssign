using ContosaPizza.Data;
using ContosaPizza.Models;


using ContosoPizzaContext context = new ContosoPizzaContext();

var products = context.Products
    .Where(p=> p.Price > 1000)
    .FirstOrDefault();
if (products is Product)
{
    Console.WriteLine(products.Price);
}

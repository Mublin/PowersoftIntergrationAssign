using TestBackend.Data;
using TestBackend.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<ProductStoreContext>(builder.Configuration.GetConnectionString("ProductDB"));
var app = builder.Build();
using var scope = app.Services.CreateScope();
var productStore = scope.ServiceProvider.GetRequiredService<ProductStoreContext>(); 


app.MapGet("/", () => "Hello World!");
app.MapProductEndpoints();

app.Run();

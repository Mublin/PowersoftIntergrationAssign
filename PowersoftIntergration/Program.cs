using PowersoftIntergration.Endpoint;
using PowersoftIntergration.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddHttpClient<CryptoService>();
var app = builder.Build();

app.MapCryptoEndpoint();

app.Run();

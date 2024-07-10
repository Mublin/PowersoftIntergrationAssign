using PowersoftIntergration.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http.HttpResults;

namespace PowersoftIntergration.Endpoint
{
    public static class CryptoEndpoint
    {
        public static RouteGroupBuilder MapCryptoEndpoint(this WebApplication app)
        {
            var group = app.MapGroup("api/crypto");

            group.MapGet("/", async(CryptoService cryptoService, int page =1, string sortby = "default") =>
            {
                var cryptos = await cryptoService.GetAllCryptosAsync();
                if (cryptos is null)
                {
                    Results.BadRequest("Unable to fetch data");
                }
                var orderedCryptos = cryptoService.GetCryptoSorted(cryptos, sortby);
                var paginatedCryptos = cryptoService.Pagination(orderedCryptos, page);
                return Results.Ok(paginatedCryptos);
            });

            group.MapGet("/{id}", async (CryptoService cryptoService, string id) =>
            {
                var crypto = await cryptoService.GetCryptoByIdAsync(id);
                return crypto is not null ? Results.Ok(crypto) : Results.NotFound();
            });

            return group;
        }
    }
}

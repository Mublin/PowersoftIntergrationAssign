using GameStoreAPI.Dtos;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
const string GetGameEndpoint = "GetGame";
List<GameDto> games = [
    new (
        1,
        "Street Fighter II",
        "Fighting",
        19.99M,
        new DateOnly(1992, 7, 15)),
    new (2,
    "Final Fantasy XIV",
    "RolePlaying",
    59.99M,
    new DateOnly(2010, 9, 30)),
    new (3,
    "FIFA 23",
    "Sports",
    69.99M,
    new DateOnly(2022, 9, 27))
    ];

app.MapGet("/games", () => games);
app.MapGet("/games/{id}", (int id) => games.Find(game => game.Id == id)).WithName(GetGameEndpoint);
app.MapPost("games", (CreateGameDto game) =>
{
    GameDto game1 = new(
        games.Count + 1,
        game.Name,
        game.Genre,
        game.Price,
        game.ReleaseDate
        );
    games.Add(game1);
    return Results.CreatedAtRoute(GetGameEndpoint, new { id = game1.Id }, game1);
});




app.Run();

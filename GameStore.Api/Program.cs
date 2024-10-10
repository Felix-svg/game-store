using GameStore.Api.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

List<GamesDto> games = [
    new(1, "Grand Theft Auto", "Action-Adventure", 79.99M, new DateOnly(2013, 09, 17)),
    new(1, "EAFC 24", "Sports", 76.99M, new DateOnly(2023, 09, 22)),
    new(1, "F1 24", "Racing", 79.99M, new DateOnly(2014, 05, 31))
];

var app = builder.Build();

// ENDPOINTS

// GET /games
app.MapGet("/games", () => games);

// GET /games/id
app.MapGet("/games/{id}", Results<Ok<GamesDto>, NotFound> (int id) =>
{
    var game = games.Find(game => game.ID == id);
    return game is null ? TypedResults.NotFound() : TypedResults.Ok(game);
});

// POST /games
app.MapPost("/games", (CreateGameDto newGame) =>
{
    GamesDto game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );

    games.Add(game);
    // Include the location of the newly created game:
    return TypedResults.Created($"/games/{game.ID}", game);
});

// PUT /games/id
app.MapPut("/games/{id}", Results<NoContent, NotFound> (int id, UpdateGameDto updateGame) =>
{
    var index = games.FindIndex(game => game.ID == id);

    if (index == -1)
    {
        return TypedResults.NotFound();
    }

    games[index] = new(
        id,
        updateGame.Name,
        updateGame.Genre,
        updateGame.Price,
        updateGame.ReleaseDate
    );

    return TypedResults.NoContent();
});

// DELETE games/id
app.MapDelete("/games/{id}", Results<NoContent, NotFound> (int id) =>
{
    var removed = games.RemoveAll(game => game.ID == id);

    if (removed == 0)
    {
        return TypedResults.NotFound();
    }

    return TypedResults.NoContent();
});

app.Run();

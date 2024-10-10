namespace GameStore.Api.Dtos;

public record class GamesDto(
    int ID,
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
);
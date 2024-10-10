# Game Store API

A simple API for managing a list of games using ASP.NET Core.

## Endpoints

- `GET /games` - Retrieve all games.
- `GET /games/{id}` - Retrieve a specific game by ID.
- `POST /games` - Add a new game.
- `PUT /games/{id}` - Update an existing game by ID.
- `DELETE /games/{id}` - Delete a game by ID.

## How to Run

1. Clone the repository.
2. Navigate to project diretory
   ```bash
   cd GameStore.Api
3. Restore dependencies:
   ```bash
    dotnet restore

4. ```bash
    dotnet run

## Data Transfer Objects(DTOs)
- GamesDto - Represents a game.
- CreateGameDto - Data used when creating a new game.
- UpdateGameDto - Data used when updating a game.

## Technologies
- ASP.NET Core

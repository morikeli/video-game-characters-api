# Video Game Character API

## Overview

Video Game Character API is a RESTful ASP.NET Core API for creating, viewing, updating, and deleting video game character records. Each character includes a name, the game they belong to, and their role in that game.

The API uses Entity Framework Core with PostgreSQL for data access and includes Swagger/OpenAPI tooling for exploring the available endpoints during development.

### Target users

This project is intended for:

- Developers learning how to build REST APIs with ASP.NET Core.
- Applications that need a simple video game character catalogue.
- Developers exploring Entity Framework Core, PostgreSQL, Docker, and database migrations.

### Key features

- Create, read, update, and delete video game characters.
- PostgreSQL persistence through Entity Framework Core.
- Database schema management with Entity Framework Core migrations.
- Swagger UI and OpenAPI support in the development environment.
- Dependency injection with a service layer for character operations.
- Docker and Docker Compose support for running the API with PostgreSQL.

### API endpoints

| Method | Endpoint | Description |
| --- | --- | --- |
| `GET` | `/api/VideoGameCharacters` | Get all characters |
| `GET` | `/api/VideoGameCharacters/{id}` | Get a character by ID |
| `POST` | `/api/VideoGameCharacters` | Create a character |
| `PUT` | `/api/VideoGameCharacters?id={id}` | Update a character |
| `DELETE` | `/api/VideoGameCharacters/id?id={id}` | Delete a character |

Example request body for creating or updating a character:

```json
{
  "name": "Mario",
  "game": "Super Mario Bros.",
  "role": "Protagonist"
}
```

### Tech Stack

- **Framework**: ASP.NET Core 10
- **Language**: C#
- **Database**: PostgreSQL
- **ORM**: Entity Framework Core 10
- **API documentation**: Swagger and OpenAPI
- **Containerization**: Docker and Docker Compose
- **Architecture**: Controller, service, DTO, and data-access layers

### Project structure

- `Controllers/` - HTTP endpoints for character operations.
- `Services/` - Business logic for character operations.
- `Dtos/` - Request and response data-transfer objects.
- `Models/` - Entity Framework Core domain models.
- `Db/` - Database context configuration.
- `Migrations/` - Entity Framework Core database migrations.
- `Program.cs` - Application and dependency-injection configuration.

## Developer instructions

### Prerequisites

> [!IMPORTANT]
> Install the following tools:

### Required tools installation guide
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [PostgreSQL](https://www.postgresql.org/download/) for running the database locally, or [Docker](https://docs.docker.com/get-docker/) for the containerized setup.
- Optional: an editor such as [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/).

### Installation guide for developers

1. Clone the repository:

```bash
git clone <repository-url>
cd VideoGameCharacterAPI
```

2. Restore dependencies:

```bash
dotnet restore
```

3. Configure the database connection.

For local development, update the `DefaultConnection` value in `appsettings.Development.json`, or provide it through configuration using the `ConnectionStrings__DefaultConnection` environment variable.

4. Apply the database migrations:

```bash
dotnet ef database update
```

5. Run the API:

```bash
dotnet run
```

When running in the development environment, Swagger UI is available at:

```text
https://localhost:<8080>/swagger
```

The exact HTTPS port is shown in the application output and is configured in `Properties/launchSettings.json`.

### Run with Docker Compose

1. Copy the example environment file:

```bash
cp .env.example .env
```

2. Set values for `DB_NAME`, `DB_USER`, `DB_PASSWORD`, `DB_HOST`, and `DB_PORT` in `.env`. The database host should be `postgres` when the API runs through Docker Compose.

3. Start the API and PostgreSQL:

```bash
docker compose up --build
```

The API is available at `http://localhost:8080`. Stop the containers with:

```bash
docker compose down
```

To remove the PostgreSQL data volume as well, run:

```bash
docker compose down -v
```

### Useful commands

```bash
# Build the project
dotnet build

# Create a new migration
dotnet ef migrations add <MigrationName>

# Apply pending migrations
dotnet ef database update

# Run the project
dotnet run
```

## Contributor expectations

If you find a bug or want to contribute, create a new branch:

```bash
git checkout -b <name-of-your-branch>
```

Make the change, verify it locally, and open a pull request for review. You can also open an issue to report a problem or suggest an improvement.

## Request

If this project is useful to you, consider starring the repository.
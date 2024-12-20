# FootballLeague API Demo

This is a demo API application called **FootballLeague**. It provides functionality for managing teams, matches, and generating standings.
## Implemented Patterns and Features

- **Mediator**  
  Utilized for requests and notifications, following the CQRS pattern.

- **FluentValidation**  
  Added to validate Mediator requests with a custom `IPipelineBehavior` (`ValidationBehavior`).

- **Global Exception Handling**  
  Includes a `GlobalExceptionHandler` middleware for centralized error handling.

- **Logging**  
  Integrated **Serilog** for structured logging.

- **Database**  
  Uses **SQL Server** with **Entity Framework Core** for database operations.

- **Unit Testing**  
  Includes several example unit tests to validate key functionality.
## Endpoints Overview

### Matches
- **POST /api/matches**  
  Creates a match and updates the standings for the participating teams.

- **GET /api/matches**  
  Retrieves a list of all matches.

- **PUT /api/matches/{id}**  
  Updates a match and recalculates the standings.

- **GET /api/matches/{id}**  
  Retrieves a match by its ID.

- **DELETE /api/matches/{id}**  
  Deletes a match by its ID and updates the standings.

### Teams
- **POST /api/team**  
  Creates a team and adds it to the standings.

- **GET /api/team**  
  Retrieves a list of all teams.

- **PUT /api/team/{id}**  
  Updates a team by its ID.

- **DELETE /api/team/{id}**  
  Deletes a team by its ID. Teams with played matches cannot be deleted.

- **GET /api/team/{id}**  
  Retrieves a team by its ID.

### Standings
- **GET /api/standings**  
  Displays the current standings of all teams.





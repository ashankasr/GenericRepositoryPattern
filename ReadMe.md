# Generic Repository Pattern

This project demonstrates the implementation of a generic repository pattern in .NET.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) for database operations

## Setup

1. Clone the repository:
   ```sh
   git clone https://github.com/ashankasr/GenericRepositoryPattern.git
   ```
2. Change directory
   ```sh
   cd GenericRepositoryPattern
   ```

## Project Structure

- `Database/Migrations/`: Contains the database migration files.
- `Repositories/`: Contains the generic repository implementation.
- `Models/`: Contains the data models.
- `Requests/`: Contains the request models.
- `Entities/`: Contains the entity models.
- `Interfaces/`: Contains the interface definitions.
- `Endpoints/`: Contains the API endpoints.
- `Services/`: Contains the service implementations.

## How to add migrations

1. Open and termial and make should you are in GenericRepositoryPattern directory

2. Add the migration:

   ```sh
   dotnet ef migrations add <migration-name> --output-dir Database/Migrations/
   ```

3. Update the database:
   ```sh
   dotnet ef database update
   ```

## Usage

Run the application:

```sh
dotnet run

```

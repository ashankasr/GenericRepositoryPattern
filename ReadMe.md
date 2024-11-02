cd TestWebApi

dotnet ef migrations add InitialCreate --output-dir Database/Migrations/

dotnet ef database update
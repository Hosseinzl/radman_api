# Build tables
Add connection string of your sql server to appsetting.json

In package manager console, run `Add-Migration initial` + `Update-Database` to generate tables and update sql server

# Add seed data
In directory of project run `dotnet run seeddata` to add data from Data\seed.cs to database

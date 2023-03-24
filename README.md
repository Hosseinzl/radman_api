# radman_api
add connection string of you sql server to appsetting.json

# Build tables
in package manager console add run `Add-Migration initial` + `Update-Database` to generate tables and update sql server

# Add seed data
in directory of project run `dotnet run seeddata` to add data from Data\seed.cs to database

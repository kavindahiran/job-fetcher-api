{

1. Project title & short description

Title: Job Scheduler - kavinda hiran

2. Technologies used

.NET SDK: net8.0

Microsoft.Data.SqlClient (NuGet)

SQL Server

Docker

3. Prerequisites

.NET SDK

Docker Desktop

SQL Server

Git

4. Configuration

If running locally against local SQL Express

"ConnectionStrings": {
"DefaultConnection": "Server=DESKTOP-L5UTAD3\SQLEXPRESS;Database=JobShedularDb;User Id=--;Password=--;TrustServerCertificate=True;MultipleActiveResultSets=true;"
}

If running with Docker, use the service name mssql in the connection string:

"ConnectionStrings": {
"DefaultConnection": "Server=mssql;Database=JobShedularDb;User Id=sa;Password=Admin@12345;TrustServerCertificate=True;"
},

5. how to Build & run the API
   update the connection string in the appsetting.json to map your sql server.
   If you want to run SQL Server using Docker, follow these steps:
   Start SQL Server in Docker
   docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Admin@12345" \
    -p 1433:1433 --name jobscheduler-mssql \
    -d mcr.microsoft.com/mssql/server:2022-latest

   docker ps

Execute the scripts that is on the root directory Sql Script
dotnet run --project src/JobFetcherAssesment/JobFetcherAssesment.csproj

6. Endpoints

GET /api/jobs

Query params: page, pageSize

Example: curl https://localhost:7205/api/Jobs?page=1&pageSize=50

GET /api/jobs/{id}

Example: curl https://localhost:7205/api/jobs/1

7. Error handling

Error handling with try catch blocks
Database connection failures → return 500 with message
Invalid input → 400
External API failures → return 404 or 502 as appropriate
Null handling for DB columns

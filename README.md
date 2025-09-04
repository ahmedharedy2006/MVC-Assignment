# MVC Assignment

This is an ASP.NET Core MVC project for managing Students and Departments.

## Prerequisites
- .NET 9 SDK (or latest supported version)
- SQL Server (local or remote)
- Visual Studio 2022+ or VS Code

## Installation

1. **Clone the repository**
   ```
   git clone <your-repo-url>
   ```
   Or download the project files to your local machine.

2. **Configure the Database Connection**
   - Open `appsettings.json`.
   - Update the `DefaultConnection` string if needed:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=.;Database=MvcAssignmentDb;Trusted_Connection=True;TrustServerCertificate=True"
     }
     ```
   - By default, it uses a local SQL Server instance.

3. **Restore NuGet Packages**
   - Open a terminal in the project directory and run:
     ```powershell
     dotnet restore
     ```

4. **Create and Apply Migrations**
   - In the terminal, run:
     ```powershell
     dotnet ef migrations add InitialCreate
     dotnet ef database update
     ```
   - This will create the database and tables.

5. **Seed Data (Optional)**
   - If you want to seed initial data for Students and Departments, update the `AppDbContext` with seed logic in `OnModelCreating` or use a custom seeder.

6. **Run the Project**
   - Start the application:
     ```powershell
     dotnet run
     ```
   - Or use Visual Studio's Run/Debug button.

7. **Access the Application**
   - Open your browser and go to:
     ```
     https://localhost:5001
     ```
   - Or the port shown in the terminal output.

## Features
- Manage Students and Departments (CRUD)
- Bootstrap UI
- Navigation between all pages

## Troubleshooting
- Ensure SQL Server is running and accessible.
- If you change the model, re-run migrations:
  ```powershell
  dotnet ef migrations add <MigrationName>
  dotnet ef database update
  ```
- For issues with NuGet packages, run:
  ```powershell
  dotnet restore
  ```

# MaterialApi

## Overview
MaterialApi is an ASP.NET Core Web API project designed to manage materials with a focus on CRUD operations. It utilizes Entity Framework Core with SQL Server for data management.

## Project Structure
```
MaterialApi
├── Controllers
│   └── MaterialsController.cs
├── Data
│   └── MaterialContext.cs
├── Models
│   └── Material.cs
├── Properties
│   └── launchSettings.json
├── appsettings.json
├── appsettings.Development.json
├── MaterialApi.csproj
├── Program.cs
├── Startup.cs
└── README.md
```

## Features
- **MaterialsController**: Handles HTTP requests related to materials, including:
  - GET: List all materials and retrieve a specific material by ID.
  - POST: Create a new material with model validation.
  
- **Material Model**: Represents the material entity with properties such as:
  - MaterialId (int, PK)
  - Name (string, required)
  - Category (string, required)
  - Brand (string)
  - UnitPrice (decimal, required, must be > 0)
  - UnitOfMeasure (string, required: Bag/Kg/Ton)
  - InStockQty (int)
  - ReorderLevel (int)
  - GstPercent (decimal, between 0–28)
  - IsActive (bool, default true)
  - AddedOn (DateTime, default now)

## Configuration
- **appsettings.json**: Contains configuration settings, including the SQL Server connection string.
- **appsettings.Development.json**: Overrides settings for the development environment.
- **launchSettings.json**: Contains settings for launching the application in different environments.

## Entry Point
- **Program.cs**: Configures services and middleware, including Entity Framework Core, CORS, static files, and Swagger support.

## Additional Files
- **HTML Pages**: Located in `wwwroot/pages/` for creating, listing, and displaying material details.
- **CSS Styles**: Located in `wwwroot/css/site.css` for application styling.
- **JavaScript**: Located in `wwwroot/js/app.js` for client-side functionality.

## Getting Started
1. Clone the repository.
2. Update the connection string in `appsettings.json`.
3. Run the application using your preferred method (e.g., `dotnet run`).
4. Access the API endpoints to manage materials.
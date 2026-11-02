# Product Management System (PMS) – Lab 08

## 1. Project Overview

The Product Management System (PMS) is a web-based application developed using ASP.NET Core Razor Pages and C#. It allows users to manage product records through a simple and user-friendly interface.

## 2. Features

- Add new products
- View all products
- View individual product details
- Update product information
- Delete products
- Upload product images
- Manage product prices and quantities
- Manage product availability status

## 3. Technologies Used

- **Programming Language:** C#
- **Framework:** ASP.NET Core Razor Pages
- **Database:** Microsoft SQL Server LocalDB
- **Database Connectivity:** ADO.NET
- **SQL Library:** Microsoft.Data.SqlClient
- **Frontend:** HTML, CSS, Bootstrap
- **IDE:** Visual Studio

## 4. Project Architecture

The project uses the **Repository Pattern** to separate database operations from application logic.

Main project folders:

- `Data/` – Database repository and image upload services.
- `Models/` – Product model.
- `Pages/` – Razor Pages for product CRUD operations.
- `wwwroot/` – CSS, images, and other static files.
- `Database/` – SQL database creation script.

## 5. Database Information

**Database Name:** `PMS_CRUD_Razor_Lab08DB`

**Table Name:** `products`

The products table contains the following fields:

| Field | Description |
|---|---|
| Id | Product ID (Primary Key) |
| Title | Product title |
| description | Product description |
| image | Product image path |
| price | Product price |
| quantity | Available quantity |
| status | Product availability status |

The SQL creation script is available at:

`Database/CreateDatabase.sql`

## 6. How to Run the Project

1. Clone or download this repository.
2. Open `PMS_CRUD_Razor_Lab08.sln` or the project file in Visual Studio, if available.
3. Make sure SQL Server LocalDB is installed.
4. Open SQL Server Management Studio or Visual Studio's SQL Server Object Explorer.
5. Execute `Database/CreateDatabase.sql` to create the database and products table.
6. Check the connection string in `appsettings.json`.
7. Restore NuGet packages.
8. Build and run the application.

## 7. Connection String

The application uses SQL Server LocalDB.

Check the `DefaultConnection` setting in `appsettings.json` and ensure it points to:

`PMS_CRUD_Razor_Lab08DB`

## 8. Developed For

**Subject:** Software Modeling Technologies  
**Lab:** Lab 08  
**Project:** Product Management System (PMS)

# Product Management System (PMS) – Lab 08

## Project Overview
The Product Management System (PMS) is an ASP.NET Core Razor Pages web application developed using C#. It allows users to manage product records through a simple and user-friendly interface.

## Features
- Add new products
- View all products
- View product details
- Update product information
- Delete products
- Upload product images
- Manage product prices, quantities, and availability status

## Technologies Used
- C#
- ASP.NET Core Razor Pages
- ADO.NET
- SQL Server LocalDB
- Microsoft.Data.SqlClient
- HTML, CSS, and Bootstrap
- Visual Studio

## Database
**Database Name:** `PMS_CRUD_Razor_Lab08DB`

**Table Name:** `products`

The database stores product information, including title, description, image, price, quantity, and status.

## Design Pattern
The project uses the **Repository Pattern** to separate database operations from the application logic.

## How to Run
1. Clone or download this repository.
2. Open the project in Visual Studio.
3. Ensure SQL Server LocalDB is installed.
4. Create the database and `products` table using the required SQL schema.
5. Check the connection string in `appsettings.json`.
6. Build and run the project.

## Developed For
Software Modeling Technologies – Lab 08

**Project:** Product Management System (PMS)

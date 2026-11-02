
-- =============================================
-- Product Management System (PMS)
-- Lab 08 - Database Creation Script
-- =============================================

-- Create database if it does not exist
IF DB_ID('PMS_CRUD_Razor_Lab08DB') IS NULL
BEGIN
    CREATE DATABASE PMS_CRUD_Razor_Lab08DB;
END
GO

USE PMS_CRUD_Razor_Lab08DB;
GO

-- Create products table if it does not exist
IF OBJECT_ID('dbo.products', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.products
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Title VARCHAR(50) NOT NULL,
        [description] VARCHAR(50) NOT NULL,
        [image] VARCHAR(255) NOT NULL,
        price INT NOT NULL,
        quantity INT NOT NULL,
        [status] VARCHAR(20) NOT NULL
            CONSTRAINT DF_products_status DEFAULT 'Available'
    );
END
GO

-- Verify table creation
SELECT * FROM dbo.products;
GO

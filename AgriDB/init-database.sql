USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'AgriEnergy')
BEGIN
	CREATE DATABASE AgriEnergy;
END
GO

USE AgriEnergy;
GO

CREATE TABLE Products(
	ProductID INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(50) NOT NULL,
	Category VARCHAR(50) NOT NULL,
	ProductionDate Date NOT NULL

);
GO

CREATE TABLE Farmers(
	FarmerID INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(50) NOT NULL,
	ProductName VARCHAR(50) NOT NULL
);

GO

INSERT INTO Products(Name, Category, ProductionDate)
VALUES
('Eggs', 'Produce', '2025-05-12'),
('Milk', 'Dairy', '2025-05-15')
GO

INSERT INTO Farmers(Name, ProductName)
VALUES
('Pieter Du Preez',  'Cow'),
('Johannes Koekemoer', 'Chicken')
GO

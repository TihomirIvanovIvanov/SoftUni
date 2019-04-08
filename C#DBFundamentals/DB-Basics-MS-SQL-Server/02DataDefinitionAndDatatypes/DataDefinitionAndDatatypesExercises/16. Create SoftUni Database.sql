CREATE TABLE Towns (
Id INT PRIMARY KEY IDENTITY NOT NULL,
Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Addresses  (
Id INT PRIMARY KEY IDENTITY NOT NULL,
AddressText NVARCHAR(100) NOT NULL,
TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments (
Id INT PRIMARY KEY IDENTITY NOT NULL,
Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees (
Id INT PRIMARY KEY IDENTITY NOT NULL,
FirstName NVARCHAR(50) NOT NULL,
MiddleName NVARCHAR(50),
LastName NVARCHAR(50) NOT NULL,
JobTitle NVARCHAR(50) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
HireDate DATE,
Salary DECIMAL(10,2) NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)
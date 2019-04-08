CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY NOT NULL,
CategoryName NVARCHAR(30) NOT NULL,
DailyRate INT NOT NULL,
WeeklyRate INT NOT NULL,
MonthlyRate INT NOT NULL,
WeekendRate INT NOT NULL
)

CREATE TABLE Cars(
Id INT PRIMARY KEY IDENTITY NOT NULL,
PlateNumber NVARCHAR(20) NOT NULL,
Manufacturer NVARCHAR(20) NOT NULL,
Model NVARCHAR(20) NOT NULL,
CarYear DATE NOT NULL,
CategoryId INT,
Doors TINYINT,
Picture BIT,
Condition BIT,
Available NVARCHAR(10)
)

CREATE TABLE Employees (
Id INT PRIMARY KEY IDENTITY NOT NULL,
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
Title NVARCHAR(50),
Notes NVARCHAR(MAX)
)

CREATE TABLE Customers (
Id INT PRIMARY KEY IDENTITY NOT NULL,
DriverLicenceNumber INT NOT NULL,
FullName NVARCHAR(50) NOT NULL,
Adress NVARCHAR(100) NOT NULL,
City NVARCHAR(50) NOT NULL,
ZIPCode INT,
Notes NVARCHAR(MAX)
)

CREATE TABLE RentalOrders (
Id INT PRIMARY KEY IDENTITY NOT NULL,
EmployeeId INT NOT NULL,
CustomerId INT NOT NULL,
CarId INT NOT NULL,
TankLevel INT,
KilometrageStart INT,
KilometrageEnd INT,
TotalKilometrage INT,
StartDate DATE,
EndDate DATE,
TotalDays DATE,
RateApplied INT,
TaxRate INT,
OrderStatus NVARCHAR(50),
Notes NVARCHAR(MAX)
)
 
INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES ('Sport', 1, 2, 3, 4),
('Sport', 1, 2, 3, 4),
('Sport', 1, 2, 3, 4)

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
VALUES ('SA1234SA', 'AUDI', 'S9', '2018-01-01', 1, 4, 1, 1, 'No'),
('SA1234SA', 'SAAUDISA', 'S9', '2018-01-01', 1, 4, 1, 1, 'No'),
('SA1234SA', 'SAAUDISA', 'S9', '2018-01-01', 1, 4, 1, 1, 'No')

INSERT INTO Employees (FirstName, LastName, Title, Notes)
VALUES ('Tihomir', 'Ivanov', 'Student', 'SoftUni'),
('Tihomir', 'Ivanov', 'Student', 'SoftUni'),
('Tihomir', 'Ivanov', 'Student', 'SoftUni')

INSERT INTO Customers (DriverLicenceNumber, FullName, Adress, City, ZIPCode, Notes)
VALUES (1234, 'Tihomir Ivanov Ivanov', 'Tintqva 15', 'Sofia', 1000, 'Student'),
(1234, 'Tihomir Ivanov Ivanov', 'Tintqva 15', 'Sofia', 1000, 'Student'),
(1234, 'Tihomir Ivanov Ivanov', 'Tintqva 15', 'Sofia', 1000, 'Student')

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes) 
VALUES (1, 2, 3, 4, 5, 6, 7, '2017-01-28', '2017-01-29', '2017-01-30', 8, 9, 'Available', 'sdfhgj'), 
(1, 2, 3, 4, 5, 6, 7, '2017-01-28', '2017-01-29', '2017-01-30', 8, 9, 'Available', 'sdfhgj'),
(1, 2, 3, 4, 5, 6, 7, '2017-01-28', '2017-01-29', '2017-01-30', 8, 9, 'Available', 'sdfhgj')       
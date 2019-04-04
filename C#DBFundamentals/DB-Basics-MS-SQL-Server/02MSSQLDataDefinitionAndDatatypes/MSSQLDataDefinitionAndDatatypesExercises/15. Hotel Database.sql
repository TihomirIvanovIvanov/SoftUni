CREATE TABLE Employees (
Id INT PRIMARY KEY IDENTITY NOT NULL,
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
Title NVARCHAR(50),
Notes NVARCHAR(MAX)
)

CREATE TABLE Customers (
AccountNumber INT PRIMARY KEY IDENTITY NOT NULL,
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
PhoneNumber VARCHAR(30) NOT NULL,
EmergencyName NVARCHAR(20) NOT NULL,
EmergencyNumber VARCHAR(30) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE RoomStatus (
RoomStatus NVARCHAR(30) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE RoomTypes (
RoomTypes NVARCHAR(30) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE BedTypes (
BedTypes NVARCHAR(30) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Rooms (
RoomNumber INT PRIMARY KEY IDENTITY NOT NULL,
RoomType NVARCHAR(30) NOT NULL,
BedType NVARCHAR(30) NOT NULL,
Rate INT,
RoomStatus NVARCHAR(30),
Notes NVARCHAR(MAX)
)

CREATE TABLE Payments (
Id INT PRIMARY KEY IDENTITY NOT NULL,
EmployeeId INT NOT NULL,
PaymentDate DATE NOT NULL,
AccountNumber INT NOT NULL,
FirstDateOccupied DATE,
LastDateOccupied DATE,
TotalDays INT NOT NULL,
AmountCharged INT NOT NULL,
TaxRate INT NOT NULL,
TaxAmount INT NOT NULL,
PaymentTotal DECIMAL(10,2) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Occupancies (
Id INT PRIMARY KEY IDENTITY NOT NULL,
EmployeeId INT NOT NULL,
DateOccupied DATE NOT NULL,
AccountNumber INT NOT NULL,
RoomNumber INT NOT NULL,
RateApplied INT,
PhoneCharge NVARCHAR(50),
Notes NVARCHAR(MAX)
)

INSERT INTO Employees(FirstName, LastName, Title, Notes)
VALUES ('Tihomir', 'Ivanov', 'It Developer', 'segdhfg'),
('Tihomir', 'Ivanov', 'It Developer', 'segdhfg'),
('Tihomir', 'Ivanov', 'It Developer', 'segdhfg')

INSERT INTO Customers (FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
VALUES ('Tihomir', 'Ivanov', '+359123456789', 'Ivan', '+359012345678', 'asfdghgf'),
('Tihomir', 'Ivanov', '+359123456789', 'Ivan', '+359012345678', 'asfdghgf'),
('Tihomir', 'Ivanov', '+359123456789', 'Ivan', '+359012345678', 'asfdghgf')

INSERT INTO RoomStatus (RoomStatus, Notes)
VALUES ('Free', 'ergth'),
('Free', 'ergth'),
('Free', 'ergth')

INSERT INTO RoomTypes (RoomTypes, Notes)
VALUES ('Three rooms flat', 'sdfjh'),
('Three rooms flat', 'sdfjh'),
('Three rooms flat', 'sdfjh')

INSERT INTO BedTypes (BedTypes, Notes)
VALUES ('Big bed', 'sdfjh'),
('Big bed', 'sdfjh'),
('Big bed', 'sdfjh')

INSERT INTO Rooms (RoomType, BedType, Rate, RoomStatus, Notes)
VALUES ('Three rooms flat', 'Big bed', 1, 'Free', 'sdhj'),
('Three rooms flat', 'Big bed', 1, 'Free', 'sdhj'),
('Three rooms flat', 'Big bed', 1, 'Free', 'sdhj')

INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
VALUES (1, '1234-12-12', 1234, '1234-11-11', '1234-12-12', 30, 111, 11, 12, 1234, 'hgjmk'),
(2, '1234-12-12', 1234, '1234-11-11', '1234-12-12', 30, 111, 11, 12, 1234, 'hgjmk'),
(3, '1234-12-12', 1234, '1234-11-11', '1234-12-12', 30, 111, 11, 12, 1234, 'hgjmk')

INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
VALUES (1, '1111-11-11', 11, 12, 13, '14', 'aesdhjgm'),
(1, '1111-11-11', 11, 12, 13, '14', 'aesdhjgm'),
(1, '1111-11-11', 11, 12, 13, '14', 'aesdhjgm')
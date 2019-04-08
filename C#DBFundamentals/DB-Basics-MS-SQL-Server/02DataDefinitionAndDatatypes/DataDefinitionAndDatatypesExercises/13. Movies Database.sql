CREATE DATABASE Movies

CREATE TABLE Directors(
Id INT PRIMARY KEY,
DirectorName NVARCHAR(30) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Genres(
Id INT PRIMARY KEY,
GenreName NVARCHAR(30) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Categories(
Id INT PRIMARY KEY,
CategoryName NVARCHAR(30) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Movies(
Id INT PRIMARY KEY,
Title NVARCHAR(50) NOT NULL,
DirectorId INT NOT NULL,
CopyrightYear NVARCHAR(50) NOT NULL,
Lenght INT NOT NULL,
GenreId INT NOT NULL,
CategoryId INT NOT NULL,
Rating INT NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Directors (Id, DirectorName, Notes)
VALUES (1, 'Pesho', 'aaaaaa'),
(2, 'Pesho', 'aaaaaa'),
(3, 'Pesho', 'aaaaaa'),
(4, 'Pesho', 'aaaaaa'),
(5, 'Pesho', 'aaaaaa')

INSERT INTO Genres (Id, GenreName, Notes)
VALUES (1, 'Gosho', 'bbbbbbb'),
(2, 'Gosho', 'bbbbbbb'),
(3, 'Gosho', 'bbbbbbb'),
(4, 'Gosho', 'bbbbbbb'),
(5, 'Gosho', 'bbbbbbb')

INSERT INTO Categories (Id, CategoryName, Notes)
VALUES (1, 'Tosho', 'vvvvvvv'),
(2, 'Tosho', 'vvvvvvv'),
(3, 'Tosho', 'vvvvvvv'),
(4, 'Tosho', 'vvvvvvv'),
(5, 'Tosho', 'vvvvvvv')

INSERT INTO Movies (Id, Title, DirectorId, CopyrightYear, Lenght, GenreId, CategoryId, Rating, Notes)
VALUES (1, 'Breaking bad', 1, '2010-02-02', 2400, 1, 1, 10, 'Greatest serial ever'),
(2, 'Prison break', 1, '2006-02-02', 3120, 2, 1, 9, 'Greatest serial'),
(3, 'Twenty four', 1, '2002-02-02', 6424, 3, 1, 8, 'Greatest serial'),
(4, 'Predestination', 1, '2015-02-02', 130, 4, 1, 9, 'Greatest movie'),
(5, 'Limitless', 1, '2014-02-02', 100, 5, 1, 8, 'Greatest movie')


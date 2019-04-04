CREATE TABLE People(
Id BIGINT PRIMARY KEY IDENTITY NOT NULL,
Name VARCHAR(200) NOT NULL,
Picture VARBINARY(MAX) CHECK (DATALENGTH(Picture) <= 2097152),
Height FLOAT,
Weight FLOAT,
Gender CHAR CHECK (Gender = 'm' OR Gender = 'f') NOT NULL,
Birthday DATE NOT NULL,
Biography VARCHAR(MAX)
)

INSERT INTO People (Name, Picture, Height, Weight, Gender, Birthday, Biography)
VALUES ('Tihomir', 123456, 1.70, 69, 'm', '01/29/1991', 'Learning SQL in SoftUni'),
('Tihomir', 123456, 1.70, 69, 'm', '01-29-1991', 'Learning SQL in SoftUni'),
('Tihomir', 123456, 1.70, 69, 'm', '01-29-1991', 'Learning SQL in SoftUni'),
('Tihomir', 123456, 1.70, 69, 'm', '01-29-1991', 'Learning SQL in SoftUni'),
('Tihomir', 123456, 1.70, 69, 'm', '01-29-1991', 'Learning SQL in SoftUni')
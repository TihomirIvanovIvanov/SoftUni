CREATE TABLE Users(
Id BIGINT PRIMARY KEY IDENTITY NOT NULL,
Username NVARCHAR(30) NOT NULL,
Password NVARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(MAX) CHECK (DATALENGTH(ProfilePicture) <= 900 * 1024),
LastLoginTime DATE,
IsDeleted BIT
)

INSERT INTO Users(Username, Password, ProfilePicture, LastLoginTime, IsDeleted)
VALUES ('villevallo', '123456789', 12456789, '01-29-2017', 0),
('villevallo', '123456789', 12456789, '01-29-2017', 0),
('villevallo', '123456789', 12456789, '01-29-2017', 0),
('villevallo', '123456789', 12456789, '01-29-2017', 0),
('villevallo', '123456789', 12456789, '01-29-2017', 0)

ALTER TABLE Users
DROP CONSTRAINT [PK__Users__3214EC07D88062BE]

ALTER TABLE Users
ADD PRIMARY KEY(Id, Username)

ALTER TABLE Users
ADD CONSTRAINT Password
CHECK (Password >= 5)

ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime

ALTER TABLE Users
ADD CONSTRAINT CH_UsernameLenght CHECK (LEN(Username) >= 3)



CREATE TABLE Logs(
LogId INT IDENTITY PRIMARY KEY,
AccountId INT,
OldSum MONEY,
NewSum Money)

CREATE TRIGGER tr_SumChanges ON Accounts AFTER UPDATE
AS
BEGIN

INSERT INTO Logs (AccountId, OldSum, NewSum)
SELECT i.Id, d.Balance, i.Balance 
FROM inserted AS i
INNER JOIN deleted AS d
ON i.AccountHolderId = d.AccountHolderId

END

UPDATE Accounts
SET Balance += 10
WHERE Id = 1
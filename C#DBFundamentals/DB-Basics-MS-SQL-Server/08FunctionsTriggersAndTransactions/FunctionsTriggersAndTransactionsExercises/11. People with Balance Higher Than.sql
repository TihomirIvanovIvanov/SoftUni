CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan (@suppliedNumber MONEY)
AS
SELECT ah.FirstName, ah.LastName
FROM [dbo].[AccountHolders] AS ah
JOIN [dbo].[Accounts] AS a
ON ah.Id = a.AccountHolderId
GROUP BY ah.FirstName, ah.LastName
HAVING SUM(a.Balance) > @suppliedNumber
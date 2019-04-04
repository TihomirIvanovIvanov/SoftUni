CREATE PROC usp_CalculateFutureValueForAccount (@accountID int, @interestRate float)
AS
BEGIN

	DECLARE @newBalance money

	SELECT TOP(1) ah.Id AS 'Account Id', ah.FirstName, ah.LastName, ac.Balance,
	CASE
	WHEN @newBalance IS NULL THEN dbo.ufn_CalculateFutureValue(Balance, 0.1, 5) END AS 'Balance in 5 years'
	FROM AccountHolders AS ah
	INNER JOIN Accounts AS ac
	ON ac.AccountHolderId = ah.Id
	WHERE @accountID = ac.AccountHolderId

END
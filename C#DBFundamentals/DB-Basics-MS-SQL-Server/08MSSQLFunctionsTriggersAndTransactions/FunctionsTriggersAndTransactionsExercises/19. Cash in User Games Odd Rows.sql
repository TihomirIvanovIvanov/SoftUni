CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(50))
RETURNS @Result TABLE(
SumCash MONEY
)
AS
BEGIN
INSERT INTO @Result
SELECT SUM(sc.Cash) as SumCash
FROM
(SELECT Cash,
ROW_NUMBER() OVER(ORDER BY Cash DESC) AS RowNumber
FROM UsersGames ug
RIGHT JOIN Games g
ON ug.GameId = g.Id
WHERE g.Name = @gameName) sc
WHERE RowNumber % 2 != 0
RETURN
END
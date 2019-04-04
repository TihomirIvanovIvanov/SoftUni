CREATE PROC usp_GetTownsStartingWith (@name VARCHAR(50))
AS
BEGIN

SELECT Name FROM Towns
WHERE Name LIKE @name + '%'

END
EXEC usp_GetTownsStartingWith 'b'
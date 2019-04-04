CREATE FUNCTION ufn_CalculateFutureValue (@sum MONEY, @rate FLOAT, @years INT)
RETURNS MONEY
AS
BEGIN
	DECLARE @result MONEY
	SET @result = @sum * (POWER((1 + @rate), @years))

	RETURN @result
END
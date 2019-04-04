CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS TINYINT
AS
BEGIN

DECLARE @result TINYINT = 1;
DECLARE @length INT = LEN(@word);
DECLARE @index INT = 1;
DECLARE @char CHAR = 1;
WHILE @index <= @length
BEGIN
SET @char = SUBSTRING(@word, @index, 1)
	IF (CHARINDEX(@char, @setOfLetters, 0) < 1)
	BEGIN
		SET @result = 0;
	END
SET @index += 1;
END
RETURN @result;
END

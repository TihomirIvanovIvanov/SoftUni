CREATE FUNCTION ufn_GetSalaryLevel(@salary MONEY)
RETURNS VARCHAR(50)
AS
BEGIN
DECLARE @salaryLevel VARCHAR(50);
IF (@salary < 30000)
BEGIN 
SET @salaryLevel = 'Low'
END
ELSE IF (@salary >= 30000 AND @salary <= 50000)
BEGIN 
SET @salaryLevel = 'Average'
END
ELSE IF (@salary > 50000)
BEGIN 
SET @salaryLevel = 'High'
END
RETURN @salaryLevel;
END
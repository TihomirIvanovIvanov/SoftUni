CREATE PROC usp_GetEmployeesSalaryAboveNumber (@number MONEY)
AS
BEGIN

SELECT FirstName AS 'First Name',
LastName AS 'Last Name'
FROM Employees
WHERE Salary >= @number

END
EXEC usp_GetEmployeesSalaryAboveNumber 48100

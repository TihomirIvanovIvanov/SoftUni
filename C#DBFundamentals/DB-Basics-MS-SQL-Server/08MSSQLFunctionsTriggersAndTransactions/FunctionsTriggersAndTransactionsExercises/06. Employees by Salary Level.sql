CREATE PROCEDURE usp_EmployeesBySalaryLevel(@string VARCHAR(10)) AS
BEGIN
Select FirstName, LastName FROM Employees WHERE dbo.ufn_GetSalaryLevel(Salary) = @string
END
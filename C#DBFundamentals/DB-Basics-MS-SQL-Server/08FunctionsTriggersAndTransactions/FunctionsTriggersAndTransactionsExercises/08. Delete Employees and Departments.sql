ALTER TABLE Departments
ALTER COLUMN ManagerID INT

DELETE FROM EmployeesProjects
WHERE EmployeeID IN (SELECT EmployeeID FROM Employees 
					 WHERE DepartmentID IN (SELECT DepartmentID 
						FROM Departments
						WHERE Name IN ('Production','Production Control'))
					)
ALTER TABLE Employees
DROP CONSTRAINT FK_Employees_Departments
ALTER TABLE Employees
DROP CONSTRAINT FK_Employees_Employees
ALTER TABLE Departments
DROP CONSTRAINT FK_Departments_Employees

DELETE FROM Employees
WHERE DepartmentID IN	(
						SELECT DepartmentID 
						FROM Departments
						WHERE Name IN ('Production','Production Control')
						)

DELETE FROM Departments
WHERE Name IN ('Production','Production Control')
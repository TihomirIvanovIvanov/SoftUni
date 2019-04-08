SELECT * INTO AverageSalary 
FROM Employees
WHERE Salary > 30000

DELETE FROM AverageSalary
WHERE ManagerID = 42

UPDATE AverageSalary
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary)
FROM AverageSalary
GROUP BY DepartmentID
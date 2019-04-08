SELECT TOP 10 em.FirstName, em.LastName, em.DepartmentID
FROM Employees AS em
WHERE (SELECT AVG(Salary) FROM Employees AS e
WHERE em.DepartmentID = e.DepartmentID) < Salary
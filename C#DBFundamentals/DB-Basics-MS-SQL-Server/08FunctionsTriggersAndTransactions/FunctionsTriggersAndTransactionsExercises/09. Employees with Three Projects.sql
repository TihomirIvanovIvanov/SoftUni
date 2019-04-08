CREATE PROCEDURE usp_AssignProject (@EmployeeID INT, @ProjectID INT)
AS
BEGIN
DECLARE @maxEmployeeProjectsCount INT = 3
DECLARE @employeeProjectsCount INT
SET @employeeProjectsCount = (SELECT COUNT(*) 
		        FROM EmployeesProjects AS ep
		       WHERE ep.EmployeeId = @EmployeeID)
BEGIN TRAN
INSERT INTO EmployeesProjects (EmployeeID, ProjectID) VALUES (@EmployeeID, @ProjectID)

IF(@employeeProjectsCount >= @maxEmployeeProjectsCount)
  BEGIN
   RAISERROR('The employee has too many projects!', 16, 1)
   ROLLBACK
  END
ELSE
   COMMIT

END
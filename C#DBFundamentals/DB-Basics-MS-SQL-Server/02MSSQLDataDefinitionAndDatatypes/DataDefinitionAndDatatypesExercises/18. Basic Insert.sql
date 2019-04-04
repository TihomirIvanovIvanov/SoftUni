USE SoftUni

INSERT INTO Towns (Name)
VALUES ('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments (Name)
VALUES ('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 'Software Development', '01/02/2013', '3500.00'),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 'Engineering', '02/03/2004', '4000.00'),
('Maria ', 'Petrova', 'Ivanova', 'Intern', 'Quality Assurance', '28/08/2016', '525.25'),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 'Sales', '09/12/2007', '3000.00'),
('Peter', 'Pan', 'Pan', 'Intern', 'Marketing', '28/08/2016', '599.88')

SELECT ct.FirstName, ct.Age, ct.PhoneNumber
FROM Customers AS ct
 JOIN Countries AS c
ON c.Id = ct.CountryId
WHERE ct.Age >= 21 AND (ct.FirstName LIKE '%an%' OR ct.PhoneNumber LIKE '%38' ) AND c.Name <> ('Greece')
ORDER BY ct.FirstName, ct.Age DESC

UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'
DECLARE @CODE1 char(2) = (SELECT CountryCode FROM Countries
WHERE CountryName = 'Tanzania')
INSERT INTO Monasteries
VALUES('Hanga Abbey', @CODE1)
DECLARE @CODE2 char(2) = (SELECT CountryCode FROM Countries
WHERE CountryName = 'Myanmar')
INSERT INTO Monasteries
VALUES('Myin-Tin-Daik', @CODE2)
SELECT con.ContinentName, c.CountryName, COUNT(m.Id) AS MonasteriesCount FROM Countries AS c
LEFT JOIN [dbo].[Monasteries] AS m ON
m.CountryCode = c.CountryCode
JOIN Continents AS con ON
con.ContinentCode = c.ContinentCode
WHERE c.IsDeleted = 'false'
GROUP BY c.CountryName, con.ContinentName
ORDER BY COUNT(m.id) DESC, c.CountryName
SELECT COUNT(c.CountryCode)
FROM Countries AS c
LEFT OUTER JOIN MountainsCountries AS mc
ON mc.CountryCode = c.CountryCode
LEFT OUTER JOIN Mountains AS m
ON m.Id = mc.MountainId
WHERE m.Id IS NULL
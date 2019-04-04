SELECT p.PeakName, m.MountainRange AS Moutain, c.CountryName, continents.ContinentName FROM Peaks AS p
JOIN Mountains AS m
ON m.Id = p.MountainId
JOIN MountainsCountries AS mc
ON m.Id = mc.MountainId
JOIN Countries AS c
ON mc.CountryCode = c.CountryCode
JOIN Continents AS continents
ON c.ContinentCode = continents.ContinentCode
ORDER BY p.PeakName, c.CountryName
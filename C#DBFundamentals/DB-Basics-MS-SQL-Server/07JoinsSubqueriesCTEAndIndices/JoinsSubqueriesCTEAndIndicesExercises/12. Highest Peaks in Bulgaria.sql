SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM Peaks AS p
JOIN MountainsCountries AS mc
ON p.MountainId = mc.MountainId
JOIN Mountains AS m
ON m.Id = mc.MountainId
WHERE mc.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC
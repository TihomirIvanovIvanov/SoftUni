SELECT m.MountainRange, p.PeakName, p.Elevation 
FROM Peaks AS p
JOIN MountainsCountries AS mc
ON mc.MountainId = p.MountainId
JOIN Mountains AS m
ON m.Id = mc.MountainId
WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC
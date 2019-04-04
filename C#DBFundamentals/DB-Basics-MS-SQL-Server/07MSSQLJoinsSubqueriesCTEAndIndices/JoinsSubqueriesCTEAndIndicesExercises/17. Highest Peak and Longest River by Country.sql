SELECT top 5 c.CountryName, MAX(p.Elevation) as HighestPeakElevation, MAX(r.Length) as LongestRiverLenght FROM Countries c
FULL OUTER JOIN MountainsCountries mc
ON c.CountryCode = mc.CountryCode
FULL OUTER JOIN Mountains m
ON mc.MountainId = m.Id
FULL OUTER JOIN Peaks p
ON p.MountainId = m.Id
FULL OUTER JOIN CountriesRivers cr
ON cr.CountryCode = c.CountryCode
FULL OUTER JOIN Rivers r
ON r.Id = cr.RiverId
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLenght DESC, c.CountryName
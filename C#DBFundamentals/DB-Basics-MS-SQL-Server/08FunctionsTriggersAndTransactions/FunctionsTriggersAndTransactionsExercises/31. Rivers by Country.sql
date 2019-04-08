SELECT c.CountryName, cont.ContinentName, ISNULL(COUNT(r.Id), 0) AS RiversCount, ISNULL(SUM(r.LENGTH), 0) AS TotalLength FROM Countries AS c
LEFT JOIN CountriesRivers AS cr
ON cr.CountryCode = c.CountryCode 
LEFT JOIN Rivers AS r
ON r.Id = cr.RiverId
LEFT JOIN Continents AS cont
ON c.ContinentCode = cont.ContinentCode
GROUP BY c.CountryName, cont.ContinentName
ORDER BY RiversCount DESC, TotalLength DESC, c.CountryName ASC
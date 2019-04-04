SELECT c.ContinentName, SUM(CAST( coun.AreaInSqKm AS BIGINT )) AS CountriesArea, SUM(CAST(coun.Population AS BIGINT)) AS CountriesPopulation
FROM [dbo].[Continents] AS c
JOIN [dbo].[Countries] AS coun
ON c.ContinentCode = coun.ContinentCode
GROUP BY c.ContinentName
ORDER BY SUM(CAST(coun.Population AS BIGINT)) DESC
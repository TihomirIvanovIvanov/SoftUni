SELECT CountryName, IsoCode FROM Countries
WHERE CountryName LIKE ('%a%a%a%')
ORDER BY IsoCode


SELECT c.CountryName , c.IsoCode
FROM Countries AS c
WHERE (LEN(c.CountryName) - LEN(replace(c.CountryName, 'a', '')) )> 2
ORDER BY c.IsoCode ASC
SELECT usages.ContinentCode, usages.CurrencyCode, usages.CurrencyUsage FROM
(SELECT ContinentCode, CurrencyCode, COUNT(*) AS CurrencyUsage FROM Countries AS c
GROUP BY ContinentCode, CurrencyCode
HAVING COUNT(*) > 1
) usages
INNER JOIN
(
SELECT u.ContinentCode, MAX(u.Usage) as CurrencyUsage FROM (SELECT ContinentCode, CurrencyCode, COUNT(*) AS Usage FROM Countries AS c
GROUP BY ContinentCode, CurrencyCode
) as u
GROUP BY u.ContinentCode) maxUsages ON usages.ContinentCode = maxUsages.ContinentCode and maxUsages.CurrencyUsage = usages.CurrencyUsage
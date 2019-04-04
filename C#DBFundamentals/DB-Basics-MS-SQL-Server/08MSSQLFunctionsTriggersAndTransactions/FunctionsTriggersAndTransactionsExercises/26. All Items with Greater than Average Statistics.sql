SELECT i.Name, i.Price, i.MinLevel, AVG(s.Strength), s.Defence, s.Speed, s.Luck, s.Mind
 FROM Items AS i
JOIN [Statistics] AS s
ON i.Id = s.Id
GROUP BY s.Mind, s.Luck, s.Speed
HAVING AVG(s.Strength) > AVG(s.Strength)
ORDER BY i.Name
-- nameri parvo srednata na mind, luck i speed v subquery nov select i ot cqloto tva mind, luck i speed da sa po-golemi ot nego v subquery
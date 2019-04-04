SELECT TOP 1 WITH TIES cc.Name AS CountryName, AVG(f.Rate) AS FeedbackRate
FROM Feedbacks AS f
JOIN Customers AS c
ON c.Id = f.CustomerId
JOIN Countries AS cc
ON cc.Id = c.CountryId
GROUP BY cc.Name
ORDER BY FeedbackRate DESC
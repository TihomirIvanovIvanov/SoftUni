SELECT u.Username AS Username, g.Name AS Game, COUNT(ugi.ItemId) AS 'Item Count', SUM(i.Price) AS 'Item Price'
FROM Users AS u
JOIN UsersGames AS ug
ON ug.UserId = u.Id
JOIN Games AS g
ON ug.GameId = g.Id
JOIN UserGameItems AS ugi
ON ugi.UserGameId = ug.Id
JOIN Items AS i
ON ugi.ItemId = i.Id
GROUP BY u.Username, g.Name
HAVING COUNT(ugi.ItemId) >= 10
ORDER BY 'Item Count' DESC, 'Item Price' DESC, u.Username
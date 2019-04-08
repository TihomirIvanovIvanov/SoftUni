CREATE TRIGGER TR_UserGameItems_Insert_Check ON UserGameItems FOR INSERT
AS
BEGIN
	DECLARE @ItemLevel INT = (SELECT MinLevel FROM Items AS it 
	JOIN inserted AS i ON i.ItemId = it.Id)
	DECLARE @UserLevel INT = (SELECT Level FROM UsersGames AS ug
	JOIN inserted AS i ON ug.Id = i.UserGameId)

	IF (@ItemLevel > @UserLevel)
	ROLLBACK

END

	UPDATE UsersGames SET Cash = Cash + 50000
	WHERE(SELECT Username FROM Users) IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos') 
	AND (SELECT Name FROM Games) = 'Bali'

	DECLARE @ItemsPrice MONEY = (SELECT SUM(Price) FROM Items WHERE Id BETWEEN 251 AND 299) + (SELECT SUM(Price) FROM Items WHERE Id BETWEEN 501 AND 539)

	BEGIN TRAN
	UPDATE UsersGames SET Cash = Cash - @ItemsPrice
	WHERE(SELECT Username FROM Users) IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos') 
	AND (SELECT Name FROM Games) = 'Bali'
	IF @@ROWCOUNT <>1
	BEGIN
	 ROLLBACK
	 RETURN
	 END

	COMMIT

	BEGIN TRAN
	DECLARE @ItemId INT = (SELECT Id FROM Items WHERE (Id BETWEEN 251 AND 299) OR  (Id BETWEEN 501 AND 539))

	INSERT INTO UserGameItems(ItemId, UserGameId)
	VALUES
	(@ItemId)

	SELECT Username,
	g.Name,
	ug.Cash,
	i.Name AS [Item Name]
	FROM Users AS u
	Join UsersGames AS ug ON ug.UserId = u.Id
	JOIN Games AS g ON g.Id = ug.GameId
	JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
	JOIN Items AS i ON i.Id = ugi.ItemId
	WHERE g.Name = 'Bali'
	ORDER BY u.Username, i.Name
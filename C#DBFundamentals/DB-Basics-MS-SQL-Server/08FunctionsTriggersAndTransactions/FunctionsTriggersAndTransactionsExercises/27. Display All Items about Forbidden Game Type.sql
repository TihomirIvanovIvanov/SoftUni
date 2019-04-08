SELECT i.Name AS Item, i.Price, i.MinLevel, gt.Name AS 'Forbidden Game Type' FROM GameTypeForbiddenItems AS gtfi
LEFT JOIN Items AS i
ON i.Id = gtfi.ItemId
RIGHT JOIN GameTypes AS gt
ON gtfi.GameTypeId = gt.Id
ORDER BY [Forbidden Game Type] DESC, i.Name
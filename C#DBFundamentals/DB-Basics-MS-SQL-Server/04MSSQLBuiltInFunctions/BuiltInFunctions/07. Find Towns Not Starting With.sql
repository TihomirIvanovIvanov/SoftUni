SELECT TownID, Name
FROM Towns
WHERE Name LIKE '[^rbd]%'
ORDER BY Name ASC
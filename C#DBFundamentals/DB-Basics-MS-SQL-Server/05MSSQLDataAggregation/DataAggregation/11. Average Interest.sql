SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) AS AverageInterest
 FROM [dbo].[WizzardDeposits]
 WHERE DepositStartDate >= '1985-01-01'
 GROUP BY IsDepositExpired, DepositGroup
 ORDER BY DepositGroup DESC
 
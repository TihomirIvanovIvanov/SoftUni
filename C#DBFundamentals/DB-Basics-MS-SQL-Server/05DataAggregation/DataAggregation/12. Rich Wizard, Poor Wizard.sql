SELECT SUM(wizzardDep.Difference) FROM 
(
SELECT FirstName, DepositAmount,
LEAD (FirstName) OVER (ORDER BY Id) AS GuestWizard,
LEAD (DepositAmount) OVER (ORDER BY Id) AS GuestDeposit,
DepositAmount - LEAD (DepositAmount) OVER (ORDER BY Id) AS Difference
FROM WizzardDeposits
) AS wizzardDep
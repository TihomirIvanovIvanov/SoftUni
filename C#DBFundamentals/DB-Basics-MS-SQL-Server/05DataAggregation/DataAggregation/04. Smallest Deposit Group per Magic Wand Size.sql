SELECT TOP 1 WITH TIES DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup 
ORDER BY AVG(MagicWandSize)
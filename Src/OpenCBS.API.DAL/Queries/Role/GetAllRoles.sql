
SELECT 
	[id] AS Id, 
	[code] AS Code, 
	[deleted] AS Deleted, 
	[description] AS [Description], 
	[role_of_loan] AS IsRoleOfLoan, 
	[role_of_saving] AS IsRoleOfSaving, 
	[role_of_teller] AS IsRoleOfTeller
FROM [dbo].[Roles] WHERE 1 = 1

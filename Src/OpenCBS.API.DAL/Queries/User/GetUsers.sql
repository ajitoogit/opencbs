
SELECT 
	id AS Id, 
	deleted AS Deleted, 
	[user_name] AS Username, 
	first_name AS FirstName,
    last_name AS LastName, 
    user_pass AS [Password],
    mail AS Mail, 
    sex AS Sex,
    phone AS Phone, 
    (SELECT COUNT(*)FROM dbo.Credit WHERE loanofficer_id = [User].id) AS ContractNumber,
	(SELECT role_id FROM [dbo].[UserRole] WHERE [user_id] = [User].Id) AS RoleId
FROM dbo.Users AS [User]
WHERE 1 = 1
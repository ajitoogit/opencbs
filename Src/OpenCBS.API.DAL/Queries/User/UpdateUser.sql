

SET XACT_ABORT ON;
BEGIN TRANSACTION;
--===============================================================================================================

UPDATE [dbo].[Users] 
SET [user_name] = @Username, 
	[user_pass] = @Password, 
    [role_code] = @RoleCode, 
    [first_name] = @FirstName, 
    [last_name] = @LastName, 
    [mail] = @Mail, 
    [sex] = @Sex,
    [phone] = @Phone
WHERE [id] = @Id

----------- Update role ----------------------------
UPDATE [dbo].[UserRole] 
	SET [role_id] = @RoleId
WHERE [user_id] = @Id

--===============================================================================================================
COMMIT TRANSACTION;

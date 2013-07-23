

SET XACT_ABORT ON;
BEGIN TRANSACTION;
--===============================================================================================================

INSERT INTO [dbo].[Users]
(
	 [deleted]
    ,[role_code] 
    ,[user_name] 
    ,[user_pass] 
    ,[first_name]
    ,[last_name] 
    ,[mail] 
    ,[sex]
    ,[phone]
)
VALUES
(
	 @Deleted 
    ,@RoleCode 
    ,@Username 
    ,@Password 
    ,@FirstName
    ,@LastName 
    ,@Mail 
    ,@Sex
    ,@Phone
) 

DECLARE @InsertedUserId INT 
SET @InsertedUserId = (SELECT SCOPE_IDENTITY())

------------------------- Insert role of user -----------------------------------------------------------------
INSERT INTO [dbo].[UserRole]
(
	 [role_id] 
	,[user_id]
) 
VALUES
(
	 @RoleId
	,@InsertedUserId
)

------ in the end ---------
SELECT @InsertedUserId

--===============================================================================================================
COMMIT TRANSACTION;

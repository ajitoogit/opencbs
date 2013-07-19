

SET XACT_ABORT ON;
BEGIN TRANSACTION;
--===============================================================================================================

INSERT INTO [dbo].[Roles]
(
	 [code]
	,[deleted]
	,[description]
	,[role_of_loan]
	,[role_of_saving]
	,[role_of_teller]
)
VALUES
(
	 @Code
	,@Deleted
	,@Description
	,@IsRoleOfLoan
	,@IsRoleOfSaving
	,@IsRoleOfTeller
) 

SELECT SCOPE_IDENTITY()
--===============================================================================================================
COMMIT TRANSACTION;

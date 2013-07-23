

SET XACT_ABORT ON;
BEGIN TRANSACTION;
--===============================================================================================================

UPDATE [Roles] 
	SET [code] = @Code, 
        [deleted] = @Deleted, 
        [description] = @Description,
        [role_of_loan] = @IsRoleOfLoan, 
        [role_of_saving] = @IsRoleOfSaving, 
        [role_of_teller] = @IsRoleOfTeller 
WHERE [id] = @Id

--===============================================================================================================
COMMIT TRANSACTION;


-- Delete User Type
CREATE   PROCEDURE spDeleteUserType
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tUserType
    SET IsDeleted = 1, LastModifiedBy = 'System', LastModifiedDate = GETDATE()
    WHERE Id = @Id;
END;

-- Delete Account
CREATE   PROCEDURE spDeleteAccount
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tAccount
    SET IsDeleted = 1, LastModifiedBy = 'System', LastModifiedDate = GETDATE()
    WHERE Id = @Id;
END;
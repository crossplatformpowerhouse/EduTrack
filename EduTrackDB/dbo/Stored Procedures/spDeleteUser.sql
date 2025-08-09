
-- Delete User
CREATE   PROCEDURE spDeleteUser
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tUser
    SET IsDeleted = 1, LastModifiedBy = 'System', LastModifiedDate = GETDATE()
    WHERE Id = @Id;
END;
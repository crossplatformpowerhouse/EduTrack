
-- Delete Result
CREATE   PROCEDURE spDeleteResult
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tResult
    SET IsDeleted = 1, LastModifiedBy = 'System', LastModifiedDate = GETDATE()
    WHERE Id = @Id;
END;
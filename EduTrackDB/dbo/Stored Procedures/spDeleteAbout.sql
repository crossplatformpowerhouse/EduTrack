-- Delete About
CREATE   PROCEDURE spDeleteAbout
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tAbout
    SET IsDeleted = 1, LastModifiedBy = 'System', LastModifiedDate = GETDATE()
    WHERE Id = @Id;
END;
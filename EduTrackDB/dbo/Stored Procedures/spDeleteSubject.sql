
-- Delete Subject
CREATE   PROCEDURE spDeleteSubject
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tSubject
    SET IsDeleted = 1, LastModifiedBy = 'System', LastModifiedDate = GETDATE()
    WHERE Id = @Id;
END;
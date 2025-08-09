
-- Delete School
CREATE   PROCEDURE spDeleteSchool
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tSchool
    SET IsDeleted = 1, LastModifiedBy = 'System', LastModifiedDate = GETDATE()
    WHERE Id = @Id;
END;

-- Delete School Type
CREATE   PROCEDURE spDeleteSchoolType
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tSchoolType
    SET IsDeleted = 1, LastModifiedBy = 'System', LastModifiedDate = GETDATE()
    WHERE Id = @Id;
END;
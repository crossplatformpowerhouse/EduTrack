
-- Delete Course Type
CREATE   PROCEDURE spDeleteCourseType
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tCourseType
    SET IsDeleted = 1, LastModifiedBy = 'System', LastModifiedDate = GETDATE()
    WHERE Id = @Id;
END;
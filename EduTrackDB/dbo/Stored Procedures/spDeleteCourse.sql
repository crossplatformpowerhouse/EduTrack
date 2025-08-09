
-- Delete Course
CREATE   PROCEDURE spDeleteCourse
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tCourse
    SET IsDeleted = 1, LastModifiedBy = 'System', LastModifiedDate = GETDATE()
    WHERE Id = @Id;
END;
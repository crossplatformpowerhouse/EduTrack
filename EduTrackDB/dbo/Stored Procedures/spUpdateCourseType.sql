
-- Update Course Type
CREATE   PROCEDURE spUpdateCourseType
    @Id INT,
    @Code NVARCHAR(255),
    @Description NVARCHAR(255),
    @LastModifiedBy NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tCourseType
    SET Code = @Code, Description = @Description, LastModifiedBy = @LastModifiedBy, LastModifiedDate = GETDATE()
    WHERE Id = @Id AND IsDeleted = 0;
END;
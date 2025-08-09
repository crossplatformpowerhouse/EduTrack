
-- Update Course
CREATE   PROCEDURE spUpdateCourse
    @Id INT,
    @CourseTypeId INT,
    @Code NVARCHAR(20),
    @Description NVARCHAR(255),
    @Duration INT,
    @LastModifiedBy NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tCourse
    SET CourseTypeId = @CourseTypeId, Code = @Code, Description = @Description, Duration = @Duration, LastModifiedBy = @LastModifiedBy, LastModifiedDate = GETDATE()
    WHERE Id = @Id AND IsDeleted = 0;
END;
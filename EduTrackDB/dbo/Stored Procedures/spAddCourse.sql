
-- Add Course
CREATE   PROCEDURE spAddCourse
    @CourseTypeId INT,
    @Code NVARCHAR(20),
    @Description NVARCHAR(255),
    @Duration INT,
    @LastModifiedBy NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO tCourse (CourseTypeId, Code, Description, Duration, IsDeleted, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate)
    VALUES (@CourseTypeId, @Code, @Description, @Duration, 0, 'System', GETDATE(), @LastModifiedBy, GETDATE());
    SELECT SCOPE_IDENTITY();
END;
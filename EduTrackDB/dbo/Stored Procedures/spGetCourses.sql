
-- Get Courses
CREATE   PROCEDURE spGetCourses
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, CourseTypeId, Code, Description, Duration, LastModifiedBy
    FROM tCourse
    WHERE IsDeleted = 0;
END;
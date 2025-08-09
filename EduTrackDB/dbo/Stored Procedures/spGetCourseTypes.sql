
-- Get Course Types
CREATE   PROCEDURE spGetCourseTypes
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, Code, Description, LastModifiedBy
    FROM tCourseType
    WHERE IsDeleted = 0;
END;
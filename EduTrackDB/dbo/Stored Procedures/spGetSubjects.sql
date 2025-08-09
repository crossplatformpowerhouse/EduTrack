
-- Get Subjects
CREATE   PROCEDURE spGetSubjects
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, CourseId, Code, Description, AcademicYear, PassMark, LastModifiedBy
    FROM tSubject
    WHERE IsDeleted = 0;
END;

-- Get Results
CREATE   PROCEDURE spGetResults
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, UserId, CourseId, SubjectId, AssessmentId, Mark, FinalMark, Predicate, LastModifiedBy
    FROM tResult
    WHERE IsDeleted = 0;
END;
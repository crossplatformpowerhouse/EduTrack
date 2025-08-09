
-- Get Assessments
CREATE   PROCEDURE spGetAssessments
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, SubjectId, Code, Description, LastModifiedBy
    FROM tAssessment
    WHERE IsDeleted = 0;
END;
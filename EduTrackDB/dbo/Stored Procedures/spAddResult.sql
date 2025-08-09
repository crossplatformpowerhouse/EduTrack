
-- Add Result
CREATE   PROCEDURE spAddResult
    @UserId INT,
    @CourseId INT,
    @SubjectId INT,
    @AssessmentId INT,
    @Mark DECIMAL(5,2),
    @FinalMark DECIMAL(5,2),
    @Predicate NVARCHAR(50),
    @LastModifiedBy NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO tResult (UserId, CourseId, SubjectId, AssessmentId, Mark, FinalMark, Predicate, IsDeleted, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate)
    VALUES (@UserId, @CourseId, @SubjectId, @AssessmentId, @Mark, @FinalMark, @Predicate, 0, 'System', GETDATE(), @LastModifiedBy, GETDATE());
    SELECT SCOPE_IDENTITY();
END;

-- Update Result
CREATE   PROCEDURE spUpdateResult
    @Id INT,
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
    UPDATE tResult
    SET UserId = @UserId, CourseId = @CourseId, SubjectId = @SubjectId, AssessmentId = @AssessmentId, Mark = @Mark, FinalMark = @FinalMark, Predicate = @Predicate, LastModifiedBy = @LastModifiedBy, LastModifiedDate = GETDATE()
    WHERE Id = @Id AND IsDeleted = 0;
END;
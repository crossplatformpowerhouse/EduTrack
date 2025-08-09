
-- Update Assessment
CREATE   PROCEDURE spUpdateAssessment
    @Id INT,
    @SubjectId INT,
    @Code NVARCHAR(5),
    @Description NVARCHAR(255),
    @LastModifiedBy NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tAssessment
    SET SubjectId = @SubjectId, Code = @Code, Description = @Description, LastModifiedBy = @LastModifiedBy, LastModifiedDate = GETDATE()
    WHERE Id = @Id AND IsDeleted = 0;
END;
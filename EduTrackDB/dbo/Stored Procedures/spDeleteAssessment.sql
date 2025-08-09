
-- Delete Assessment
CREATE   PROCEDURE spDeleteAssessment
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tAssessment
    SET IsDeleted = 1, LastModifiedBy = 'System', LastModifiedDate = GETDATE()
    WHERE Id = @Id;
END;
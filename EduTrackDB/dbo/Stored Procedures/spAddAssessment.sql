
-- Add Assessment
CREATE   PROCEDURE spAddAssessment
    @SubjectId INT,
    @Code NVARCHAR(5),
    @Description NVARCHAR(255),
    @LastModifiedBy NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO tAssessment (SubjectId, Code, Description, IsDeleted, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate)
    VALUES (@SubjectId, @Code, @Description, 0, 'System', GETDATE(), @LastModifiedBy, GETDATE());
    SELECT SCOPE_IDENTITY();
END;

-- Add Subject
CREATE   PROCEDURE spAddSubject
    @CourseId INT,
    @Code NVARCHAR(5),
    @Description NVARCHAR(255),
    @AcademicYear INT,
    @PassMark DECIMAL(5,2),
    @LastModifiedBy NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO tSubject (CourseId, Code, Description, AcademicYear, PassMark, IsDeleted, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate)
    VALUES (@CourseId, @Code, @Description, @AcademicYear, @PassMark, 0, 'System', GETDATE(), @LastModifiedBy, GETDATE());
    SELECT SCOPE_IDENTITY();
END;
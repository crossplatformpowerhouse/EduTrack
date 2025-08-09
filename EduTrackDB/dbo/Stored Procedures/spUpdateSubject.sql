
-- Update Subject
CREATE   PROCEDURE spUpdateSubject
    @Id INT,
    @CourseId INT,
    @Code NVARCHAR(5),
    @Description NVARCHAR(255),
    @AcademicYear INT,
    @PassMark DECIMAL(5,2),
    @LastModifiedBy NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tSubject
    SET CourseId = @CourseId, Code = @Code, Description = @Description, AcademicYear = @AcademicYear, PassMark = @PassMark, LastModifiedBy = @LastModifiedBy, LastModifiedDate = GETDATE()
    WHERE Id = @Id AND IsDeleted = 0;
END;
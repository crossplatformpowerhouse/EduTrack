
-- Add Course Type
CREATE   PROCEDURE spAddCourseType
    @Code NVARCHAR(255),
    @Description NVARCHAR(255),
    @LastModifiedBy NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO tCourseType (Code, Description, IsDeleted, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate)
    VALUES (@Code, @Description, 0, 'System', GETDATE(), @LastModifiedBy, GETDATE());
    SELECT SCOPE_IDENTITY();
END;
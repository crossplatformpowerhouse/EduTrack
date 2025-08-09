
-- Add User Type
CREATE   PROCEDURE spAddUserType
    @Description NVARCHAR(100),
    @LastModifiedBy NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO tUserType (Description, IsDeleted, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate)
    VALUES (@Description, 0, 'System', GETDATE(), @LastModifiedBy, GETDATE());
    SELECT SCOPE_IDENTITY();
END;
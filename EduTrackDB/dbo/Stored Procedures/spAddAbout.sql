-- Add About
CREATE   PROCEDURE spAddAbout
    @UserId INT,
    @Bio NVARCHAR(MAX),
    @AppVersion NVARCHAR(255),
    @LastUpdated NVARCHAR(50),
    @LastModifiedBy NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO tAbout (UserId, Bio, AppVersion, LastUpdated, IsDeleted, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate)
    VALUES (@UserId, @Bio, @AppVersion, @LastUpdated, 0, 'System', GETDATE(), @LastModifiedBy, GETDATE());
    SELECT SCOPE_IDENTITY();
END;
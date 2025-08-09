-- Update About
CREATE   PROCEDURE spUpdateAbout
    @Id INT,
    @UserId INT,
    @Bio NVARCHAR(MAX),
    @AppVersion NVARCHAR(255),
    @LastUpdated NVARCHAR(50),
    @LastModifiedBy NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tAbout
    SET UserId = @UserId, Bio = @Bio, AppVersion = @AppVersion, LastUpdated = @LastUpdated, LastModifiedBy = @LastModifiedBy, LastModifiedDate = GETDATE()
    WHERE Id = @Id AND IsDeleted = 0;
END;
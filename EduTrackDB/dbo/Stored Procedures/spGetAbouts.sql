-- Get Abouts
CREATE   PROCEDURE spGetAbouts
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, UserId, Bio, AppVersion, LastUpdated, LastModifiedBy
    FROM tAbout
    WHERE IsDeleted = 0;
END;
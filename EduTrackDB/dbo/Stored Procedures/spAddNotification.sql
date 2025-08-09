
-- Add Notification
CREATE   PROCEDURE spAddNotification
    @UserId INT,
    @Message NVARCHAR(500),
    @NotificationType NVARCHAR(50),
    @IsRead BIT,
    @LastModifiedBy NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO tNotification (UserId, Message, NotificationType, IsRead, IsDeleted, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate)
    VALUES (@UserId, @Message, @NotificationType, @IsRead, 0, 'System', GETDATE(), @LastModifiedBy, GETDATE());
    SELECT SCOPE_IDENTITY();
END;
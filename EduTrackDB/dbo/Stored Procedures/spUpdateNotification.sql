
-- Update Notification
CREATE   PROCEDURE spUpdateNotification
    @Id INT,
    @UserId INT,
    @Message NVARCHAR(500),
    @NotificationType NVARCHAR(50),
    @IsRead BIT,
    @LastModifiedBy NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tNotification
    SET UserId = @UserId, Message = @Message, NotificationType = @NotificationType, IsRead = @IsRead, LastModifiedBy = @LastModifiedBy, LastModifiedDate = GETDATE()
    WHERE Id = @Id AND IsDeleted = 0;
END;

-- Get Notifications
CREATE   PROCEDURE spGetNotifications
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, UserId, Message, NotificationType, IsRead, LastModifiedBy
    FROM tNotification
    WHERE UserId = @UserId AND IsDeleted = 0
    ORDER BY Id DESC;
END;
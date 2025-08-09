
-- Update Account
CREATE   PROCEDURE spUpdateAccount
    @Id INT,
    @UserId INT,
    @ReceiveEmailNotifications NVARCHAR(255),
    @ReceivePushNotifications NVARCHAR(255),
    @LastLogin DATETIME,
    @LastModifiedBy NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tAccount
    SET UserId = @UserId, ReceiveEmailNotifications = @ReceiveEmailNotifications, ReceivePushNotifications = @ReceivePushNotifications, LastLogin = @LastLogin, LastModifiedBy = @LastModifiedBy, LastModifiedDate = GETDATE()
    WHERE Id = @Id AND IsDeleted = 0;
END;
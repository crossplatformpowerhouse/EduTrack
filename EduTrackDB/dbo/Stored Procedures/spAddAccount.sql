-- Add Account
CREATE   PROCEDURE spAddAccount
    @UserId INT,
    @ReceiveEmailNotifications NVARCHAR(255),
    @ReceivePushNotifications NVARCHAR(255),
    @LastLogin DATETIME,
    @LastModifiedBy NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO tAccount (UserId, ReceiveEmailNotifications, ReceivePushNotifications, LastLogin, IsDeleted, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate)
    VALUES (@UserId, @ReceiveEmailNotifications, @ReceivePushNotifications, @LastLogin, 0, 'System', GETDATE(), @LastModifiedBy, GETDATE());
    SELECT SCOPE_IDENTITY();
END;
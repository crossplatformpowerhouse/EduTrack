-- Get Accounts
CREATE   PROCEDURE spGetAccounts
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, UserId, ReceiveEmailNotifications, ReceivePushNotifications, LastLogin, LastModifiedBy
    FROM tAccount
    WHERE IsDeleted = 0;
END;
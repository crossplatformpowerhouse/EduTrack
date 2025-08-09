
-- Get Users
CREATE   PROCEDURE spGetUsers
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, UserTypeId, SchoolId, CourseId, Username, FirstName, LastName, Email, Cellphone, ReceiveEmailNotifications, ReceivePushNotifications, ThemePreference, LastLogin, LastModifiedBy
    FROM tUser
    WHERE IsDeleted = 0;
END;
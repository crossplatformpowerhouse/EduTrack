
-- Add User
CREATE   PROCEDURE spAddUser
    @UserTypeId INT,
    @SchoolId INT,
    @CourseId INT,
    @Username NVARCHAR(255),
    @FirstName NVARCHAR(255),
    @LastName NVARCHAR(255),
    @PasswordHash NVARCHAR(255),
    @Email NVARCHAR(255),
    @Cellphone NVARCHAR(255),
    @ReceiveEmailNotifications BIT,
    @ReceivePushNotifications BIT,
    @ThemePreference NVARCHAR(50),
    @LastModifiedBy NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO tUser (UserTypeId, SchoolId, CourseId, Username, FirstName, LastName, PasswordHash, Email, Cellphone, ReceiveEmailNotifications, ReceivePushNotifications, ThemePreference, IsDeleted, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate)
    VALUES (@UserTypeId, @SchoolId, @CourseId, @Username, @FirstName, @LastName, @PasswordHash, @Email, @Cellphone, @ReceiveEmailNotifications, @ReceivePushNotifications, @ThemePreference, 0, 'System', GETDATE(), @LastModifiedBy, GETDATE());
    SELECT SCOPE_IDENTITY();
END;
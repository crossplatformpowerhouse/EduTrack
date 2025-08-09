
-- Update User
CREATE   PROCEDURE spUpdateUser
    @Id INT,
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
    UPDATE tUser
    SET UserTypeId = @UserTypeId, SchoolId = @SchoolId, CourseId = @CourseId, Username = @Username, FirstName = @FirstName, LastName = @LastName, PasswordHash = @PasswordHash, Email = @Email, Cellphone = @Cellphone, ReceiveEmailNotifications = @ReceiveEmailNotifications, ReceivePushNotifications = @ReceivePushNotifications, ThemePreference = @ThemePreference, LastModifiedBy = @LastModifiedBy, LastModifiedDate = GETDATE()
    WHERE Id = @Id AND IsDeleted = 0;
END;
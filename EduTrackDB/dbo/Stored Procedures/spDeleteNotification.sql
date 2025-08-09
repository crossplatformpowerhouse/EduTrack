
-- Delete Notification
CREATE   PROCEDURE spDeleteNotification
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tNotification
    SET IsRead = 1, IsDeleted = 1, LastModifiedBy = 'System', LastModifiedDate = GETDATE()
    WHERE Id = @Id;
END;
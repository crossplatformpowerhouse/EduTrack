
-- Update User Type
CREATE   PROCEDURE spUpdateUserType
    @Id INT,
    @Description NVARCHAR(100),
    @LastModifiedBy NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tUserType
    SET Description = @Description, LastModifiedBy = @LastModifiedBy, LastModifiedDate = GETDATE()
    WHERE Id = @Id AND IsDeleted = 0;
END;
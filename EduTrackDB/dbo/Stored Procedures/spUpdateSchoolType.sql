
-- Update School Type
CREATE   PROCEDURE spUpdateSchoolType
    @Id INT,
    @Description NVARCHAR(255),
    @LastModifiedBy NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tSchoolType
    SET Description = @Description, LastModifiedBy = @LastModifiedBy, LastModifiedDate = GETDATE()
    WHERE Id = @Id AND IsDeleted = 0;
END;
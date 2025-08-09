-- Get User Types
CREATE   PROCEDURE spGetUserTypes
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, Description, LastModifiedBy
    FROM tUserType
    WHERE IsDeleted = 0;
END;
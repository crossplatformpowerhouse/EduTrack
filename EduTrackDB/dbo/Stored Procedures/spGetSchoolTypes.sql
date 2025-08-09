
-- Get School Types
CREATE   PROCEDURE spGetSchoolTypes
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, Description, LastModifiedBy
    FROM tSchoolType
    WHERE IsDeleted = 0;
END;
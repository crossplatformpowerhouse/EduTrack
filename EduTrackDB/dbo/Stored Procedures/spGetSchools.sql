
-- Get Schools
CREATE   PROCEDURE spGetSchools
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, EMISNumber, Description, SchoolTypeId, Phase, Level, Country, Province, District, Circuit, Municipality, UrbanRural, AddressLine1, AddressLine2, TownCity, PostalCode, PhoneNumber, Email, Latitude, Longitude, LastModifiedBy
    FROM tSchool
    WHERE IsDeleted = 0;
END;
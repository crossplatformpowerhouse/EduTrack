
-- Add School
CREATE   PROCEDURE spAddSchool
    @EMISNumber NVARCHAR(50),
    @Description NVARCHAR(255),
    @SchoolTypeId INT,
    @Phase NVARCHAR(100),
    @Level NVARCHAR(50),
    @Country NVARCHAR(255),
    @Province NVARCHAR(255),
    @District NVARCHAR(255),
    @Circuit NVARCHAR(255),
    @Municipality NVARCHAR(255),
    @UrbanRural NVARCHAR(50),
    @AddressLine1 NVARCHAR(255),
    @AddressLine2 NVARCHAR(255),
    @TownCity NVARCHAR(255),
    @PostalCode NVARCHAR(10),
    @PhoneNumber NVARCHAR(50),
    @Email NVARCHAR(100),
    @Latitude DECIMAL(9,6),
    @Longitude DECIMAL(9,6),
    @LastModifiedBy NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO tSchool (EMISNumber, Description, SchoolTypeId, Phase, Level, Country, Province, District, Circuit, Municipality, UrbanRural, AddressLine1, AddressLine2, TownCity, PostalCode, PhoneNumber, Email, Latitude, Longitude, IsDeleted, CreatedBy, CreatedDate, LastModifiedBy, LastModifiedDate)
    VALUES (@EMISNumber, @Description, @SchoolTypeId, @Phase, @Level, @Country, @Province, @District, @Circuit, @Municipality, @UrbanRural, @AddressLine1, @AddressLine2, @TownCity, @PostalCode, @PhoneNumber, @Email, @Latitude, @Longitude, 0, 'System', GETDATE(), @LastModifiedBy, GETDATE());
    SELECT SCOPE_IDENTITY();
END;
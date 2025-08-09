
-- Update School
CREATE   PROCEDURE spUpdateSchool
    @Id INT,
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
    UPDATE tSchool
    SET EMISNumber = @EMISNumber, Description = @Description, SchoolTypeId = @SchoolTypeId, Phase = @Phase, Level = @Level, Country = @Country, Province = @Province, District = @District, Circuit = @Circuit, Municipality = @Municipality, UrbanRural = @UrbanRural, AddressLine1 = @AddressLine1, AddressLine2 = @AddressLine2, TownCity = @TownCity, PostalCode = @PostalCode, PhoneNumber = @PhoneNumber, Email = @Email, Latitude = @Latitude, Longitude = @Longitude, LastModifiedBy = @LastModifiedBy, LastModifiedDate = GETDATE()
    WHERE Id = @Id AND IsDeleted = 0;
END;
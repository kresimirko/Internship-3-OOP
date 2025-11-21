using Internship_3_OOP.Entities.ObjectCollections;

namespace Internship_3_OOP.Entities;

public static class Storage
{
    public static ObjectCollectionAircrewGroup AircrewGroup { get; } = [];
    public static ObjectCollectionAirplanes Airplanes { get; } = [];
    public static ObjectCollectionFlights Flights { get; } = [];
    public static ObjectCollectionUsers Users { get; } = [];
    
    public static void CreateDemoData()
    {
        var adminUser = new EntityUser(
            "admin",
            "korisnik",
            new DateOnly(2000, 01, 01),
            "admin@abc.xyz",
            "abc123!?*",
            Gender.PreferNotToSay,
            Level.Admin
        );
        Users.Add(adminUser);
    }
}
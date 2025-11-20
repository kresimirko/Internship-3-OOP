using Internship_3_OOP.Entities.ObjectCollections;

namespace Internship_3_OOP.Entities;

public class EntityGlobalStorage : Entity
{
    public ObjectCollectionAircrewGroup AircrewGroup { get; } = [];
    public ObjectCollectionAirplanes Airplanes { get; } = [];
    public ObjectCollectionFlights Flights { get; } = [];
    public ObjectCollectionUsers Users { get; } = [];

    public EntityGlobalStorage(bool willDemoDataBeCreated = false)
    {
        if (willDemoDataBeCreated) CreateDemoData();
    }
    
    private void CreateDemoData()
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

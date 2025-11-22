using System.Net.Mail;
using Internship_3_OOP.Entities;
using Internship_3_OOP.Entities.ObjectCollections;

namespace Internship_3_OOP;

public static class Storage
{
    public static ObjectCollectionAircrewGroup AircrewGroup { get; } = new ObjectCollectionAircrewGroup();
    public static ObjectCollectionAirplanes Airplanes { get; } = new ObjectCollectionAirplanes();
    public static ObjectCollectionFlights Flights { get; } = new ObjectCollectionFlights();
    public static ObjectCollectionUsers Users { get; } = new ObjectCollectionUsers();
    
    public static void CreateDemoData()
    {
        const string airport = "Glavna luka";
        
        AircrewGroup.Add(new ObjectCollectionAircrew("Glavna", [
            new EntityCrewMember(
                "asdf",
                "ghjk",
                new DateOnly(2000,1,2),
                Gender.Male,
                AircrewRole.Pilot),
            new EntityCrewMember(
                "qwer",
                "tzui",
                new DateOnly(2001,2,4),
                Gender.Female,
                AircrewRole.Copilot),
            new EntityCrewMember(
                "yxcv",
                "bnml",
                new DateOnly(1999,4,8),
                Gender.Male,
                AircrewRole.FlightAttendant),
            new EntityCrewMember(
                "abcde",
                "fghij",
                new DateOnly(2002,10,8),
                Gender.Female,
                AircrewRole.FlightAttendant)
        ]));
        
        var demoSeats = new Dictionary<FlightCategory, int>()
        {
            { FlightCategory.Business , 40},
            { FlightCategory.Vip, 8 }
        };
        Airplanes.Add(new EntityAirplane("Abc", 2010, demoSeats));
        Airplanes.Add(new EntityAirplane("Def", 2011, demoSeats));
        Airplanes.Add(new EntityAirplane("Ghi", 2012, demoSeats));

        var demoTimespanArrival = new TimeSpan(0, 12, 23);
        var demoTimespanOffset = new TimeSpan(2, 0, 0, 0);
        var flight1 = new EntityFlight("jedan", DateTime.Now, airport, DateTime.Now.Add(demoTimespanArrival), "a", 123);
        var flight2 = new EntityFlight("dva", DateTime.Now, airport, DateTime.Now.Add(demoTimespanArrival), "b",234);
        var flight3 = new EntityFlight("tri", DateTime.Now.Add(demoTimespanOffset), airport, DateTime.Now.Add(demoTimespanOffset).Add(demoTimespanArrival), "c",345);
        var flight4 = new EntityFlight("četiri", DateTime.Now, airport, DateTime.Now.Add(demoTimespanArrival), "a",321);
        var flight5 = new EntityFlight("pet", DateTime.Now, airport, DateTime.Now.Add(demoTimespanArrival), "b",432);
        var flight6 = new EntityFlight("šest", DateTime.Now.Add(demoTimespanOffset), airport, DateTime.Now.Add(demoTimespanOffset).Add(demoTimespanArrival), "c",543);
        var flight7 = new EntityFlight("sedam", DateTime.Now, airport, DateTime.Now.Add(demoTimespanArrival), "a",121);
        var flight8 = new EntityFlight("osam", DateTime.Now, airport, DateTime.Now.Add(demoTimespanArrival), "b",212);
        var flight9 = new EntityFlight("devet", DateTime.Now.Add(demoTimespanOffset), airport, DateTime.Now.Add(demoTimespanOffset).Add(demoTimespanArrival), "c",323);
        Flights.Add(flight1);
        Airplanes.Members[0].Flights.Add(flight1);
        Flights.Add(flight2);
        Airplanes.Members[1].Flights.Add(flight2);
        Flights.Add(flight3);
        Airplanes.Members[2].Flights.Add(flight3);
        Flights.Add(flight4);
        Airplanes.Members[0].Flights.Add(flight4);
        Flights.Add(flight5);
        Airplanes.Members[1].Flights.Add(flight5);
        Flights.Add(flight6);
        Airplanes.Members[2].Flights.Add(flight6);
        Flights.Add(flight7);
        Flights.Add(flight8);
        Flights.Add(flight9);
        
        var adminUser = new EntityUser(
            "admin",
            "korisnik",
            new DateOnly(2000, 01, 01),
            new MailAddress("admin@abc.xyz"),
            "abc123!?*",
            Gender.PreferNotToSay,
            UserLevel.Admin
        );
        Users.Add(adminUser);
        Users.SignIn(adminUser);
        
        var user1 = new EntityUser(
            "Iva",
            "Ivić",
            new DateOnly(2001, 02, 03),
            new MailAddress("iivic@gmail.com"),
            "password1",
            Gender.Female,
            UserLevel.Passenger
        );
        user1.Flights.Add(flight1);
        user1.Flights.Add(flight2);
        user1.Flights.Add(flight3);
        Users.Add(user1);
        
        var user2 = new EntityUser(
            "Mato",
            "Matić",
            new DateOnly(2002, 04, 06),
            new MailAddress("mmatic@gmail.com"),
            "password2",
            Gender.Male,
            UserLevel.Passenger
        );
        user2.Flights.Add(flight4);
        user2.Flights.Add(flight5);
        user2.Flights.Add(flight6);
        Users.Add(user2);
        
        var user3 = new EntityUser(
            "Luka",
            "Lukić",
            new DateOnly(2003, 06, 09),
            new MailAddress("llukic@gmail.com"),
            "password3",
            Gender.Female,
            UserLevel.Passenger
        );
        user3.Flights.Add(flight7);
        user3.Flights.Add(flight8);
        user3.Flights.Add(flight9);
        Users.Add(user3);
    }
}

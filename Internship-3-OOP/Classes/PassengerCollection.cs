namespace Internship_3_OOP.Classes;

public class PassengerCollection(List<Passenger>? passengers = null) : Entity
{
    public List<Passenger> Passengers { get; private set; } = passengers ?? [];

    public void AddPassenger(Passenger passenger)
    {
        Passengers.Add(passenger);
    }

    public void AddPassenger(string firstName, string lastName, DateTime dateOfBirth, string email,
        string password, Gender gender, Role role)
    {
        Passengers.Add(new Passenger(firstName, lastName, dateOfBirth, email, password, gender));
    }

    public void RemovePassanger(Passenger passenger)
    {
        Passengers.Remove(passenger);
    }

    public void RemovePassanger(Guid id)
    {
        Passengers.RemoveAll(x => x.Id == id);
    }
}

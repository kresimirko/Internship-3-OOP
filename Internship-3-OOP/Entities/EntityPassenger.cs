namespace Internship_3_OOP.Entities;

public class EntityPassenger(
    string firstName,
    string lastName,
    DateTime dateOfBirth,
    string email,
    string password,
    Gender gender)
    : EntityPerson(firstName, lastName, dateOfBirth, email, password, gender)
{
    
}

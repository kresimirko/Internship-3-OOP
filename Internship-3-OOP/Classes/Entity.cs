namespace Internship_3_OOP.Classes;

public abstract class Entity
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime DateOfCreation { get; private set; } = DateTime.Now;
}

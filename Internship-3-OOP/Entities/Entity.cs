namespace Internship_3_OOP.Entities;

public abstract class Entity
{
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime DateOfCreation { get; } = DateTime.Now;
}

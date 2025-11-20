namespace Internship_3_OOP.Entities;

public abstract class Entity
{
    public Guid Guid { get; } = Guid.NewGuid();
    public DateTime DateOfCreation { get; } = DateTime.Now;
}

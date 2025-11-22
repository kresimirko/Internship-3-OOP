namespace Internship_3_OOP.Entities;

public abstract class Entity
{
    public Guid Guid { get; } = Guid.NewGuid();
    public DateTime DateOfCreation { get; } = DateTime.Now;
    public DateTime DateOfModification { get; private set; } = DateTime.Now;

    protected void UpdateDateOfModification()
    {
        DateOfModification = DateTime.Now;
    }
}

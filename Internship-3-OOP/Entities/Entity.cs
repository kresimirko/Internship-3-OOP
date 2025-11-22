namespace Internship_3_OOP.Entities;

public abstract class Entity(string? name = null)
{
    public string Name { get; } = name ?? "Ime";
    public Guid Guid { get; } = Guid.NewGuid();
    public DateTime DateOfCreation { get; } = DateTime.Now;
    public DateTime DateOfModification { get; private set; } = DateTime.Now;

    protected void UpdateDateOfModification()
    {
        DateOfModification = DateTime.Now;
    }
}

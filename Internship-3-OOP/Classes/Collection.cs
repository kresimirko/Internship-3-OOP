namespace Internship_3_OOP.Classes;

public abstract class Collection<T>(List<T>? members = null) : Entity where T : Entity
{
    public List<T> Members { get; private set; } = members ?? [];

    public void Add(T member)
    {
        Members.Add(member);
    }

    public void Remove(T member)
    {
        Members.Remove(member);
    }

    public void Remove(Guid id)
    {
        Members.RemoveAll(x => x.Id == id);
    }
}

public interface ICollectionDataTableProvidable<T> where T : ICollectionDataTableProvidable<T>
{
    public static abstract string TurnDataTableIntoString(T instance);
    public static abstract void PrintDataTable(T instance);
    public string TurnDataTableOfSelfIntoString();
    public void PrintDataTableOfSelf();
}

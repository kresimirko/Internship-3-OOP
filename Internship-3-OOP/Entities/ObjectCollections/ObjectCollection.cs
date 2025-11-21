using System.Collections;

namespace Internship_3_OOP.Entities.ObjectCollections;

public abstract class ObjectCollection<T>(List<T>? members = null, string onTableFail = "Nema članova.")
    : Entity, IEnumerable<T> where T : Entity
{
    public List<T> Members { get; } = members ?? [];

    public IEnumerator<T> GetEnumerator()
    {
        return Members.GetEnumerator();
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    public virtual void Add(T member)
    {
        if (Members.Contains(member)) return;
        
        Members.Add(member);
        UpdateDateOfModification();
    }

    public void Remove(T member)
    {
        Members.Remove(member);
    }

    public void Remove(Guid guid)
    {
        Members.RemoveAll(x => x.Guid == guid);
    }

    public abstract string TurnDataTableIntoString();

    public void PrintDataTable(bool shouldHalt = false)
    {
        if (Members.Count == 0)
        {
            Console.WriteLine(onTableFail + "\n");
            UiAssist.Halt();
            return;
        }
        
        Console.WriteLine(TurnDataTableIntoString());

        if (!shouldHalt) return;
        Console.WriteLine();
        UiAssist.Halt();
    }
}

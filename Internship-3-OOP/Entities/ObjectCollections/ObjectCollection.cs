using System.Collections;
using Internship_3_OOP.Static;

namespace Internship_3_OOP.Entities.ObjectCollections;

public abstract class ObjectCollection<T>(List<T>? members = null) : Entity, IEnumerable<T> where T : Entity
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
    
    public void Add(T member)
    {
        Members.Add(member);
    }

    public void Remove(T member)
    {
        Members.Remove(member);
    }

    public void Remove(Guid guid)
    {
        Members.RemoveAll(x => x.Guid == guid);
    }

    public virtual string TurnDataTableIntoString()
    {
        var table = new List<List<string>> {};
        table.Add(["ID", "Vrijeme stvaranja"]);
        table.AddRange(Members.Select(member => (List<string>)
        [
            member.Guid.ToString(),
            member.DateOfCreation.ToString("yyyy-MM-dd")
        ]));
    
        return UiAssist.TurnTableIntoString(table);
    }

    public virtual void PrintDataTable(bool shouldHalt = false)
    {
        Console.WriteLine(TurnDataTableIntoString());
        if (shouldHalt) UiAssist.Halt();
    }
}

using System.Collections;
using System.Collections.Immutable;

namespace Internship_3_OOP.Entities.ObjectCollections;

public abstract class ObjectCollection<T>(
    string? name = null,
    List<T>? members = null,
    string onTableFail = "Nema članova.")
    : Entity(name), IEnumerable<T> where T : Entity
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
    
    public virtual bool Add(T member)
    {
        if (Members.Contains(member)) return false;
        
        Members.Add(member);
        UpdateDateOfModification();
        return true;
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
    
    public static List<T> GetSearchResults(ObjectCollection<T> collection, string subtitle)
    {
        var choice = UiAssist.PromptMenu([
            "Po kratkom ID-u",
            "Po nazivu"
        ], subtitle);

        Console.WriteLine();
        var query = UiAssist.OneLinePrompt<string>("Pretraga: ");

        var searchResults = (from item in collection
            where (choice == 1 ? UiAssist.GetShortGuidString(item.Guid) : item.Name).Contains(query)
            select item).ToList();

        return searchResults;
    }
}

using Internship_3_OOP.Entities;
using Internship_3_OOP.Entities.ObjectCollections;
using Internship_3_OOP.Static;
using Internship_3_OOP.Static.Menus;

namespace Internship_3_OOP;

class Program
{
    private static void Main()
    {
        var globalStorage = new EntityGlobalStorage(true);
        globalStorage.Users.DEBUG_SetFirstUserInUserListToSignedInIfThereAreAny();
        
        MenuMain.Show(globalStorage);
    }
}

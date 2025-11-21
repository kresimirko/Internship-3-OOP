using Internship_3_OOP.Menus;

namespace Internship_3_OOP;

public static class Program
{
    private static void Main()
    {
        Storage.CreateDemoData();
        Storage.Users.DEBUG_SetFirstUserInUserListToSignedInIfThereAreAny();
        
        MenuMain.Show();
    }
}

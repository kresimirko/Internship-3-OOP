using Internship_3_OOP.Classes;

namespace Internship_3_OOP;

class Program
{
    private static void Main()
    {
        while (true)
        {
            UiAssist.PromptMenu([
                new Tuple<string, Action>(
                    "Putnici", () => { UiAssist.ShowFullscreenMessage("PLACEHOLDER - putnici"); }
                ),
                new Tuple<string, Action>(
                    "Letovi", () => { UiAssist.ShowFullscreenMessage("PLACEHOLDER - letovi"); }
                ),
                new Tuple<string, Action>(
                    "Avioni", () => { UiAssist.ShowFullscreenMessage("PLACEHOLDER - avioni"); }
                ),
                new Tuple<string, Action>(
                    "Posada", () => { UiAssist.ShowFullscreenMessage("PLACEHOLDER - posada"); }
                ),
                new Tuple<string, Action>(
                    "Izlaz iz programa", () => { Environment.Exit(0); }
                )
            ]);
        }
    }
}

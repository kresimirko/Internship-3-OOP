using System.Runtime.InteropServices;

namespace Internship_3_OOP.Classes;

public static class UiAssist
{
    private const string Title = "APLIKACIJA ZA UPRAVLJANJE AERODROMOM";
    
    public static void Halt()
    {
        Console.Write("Pritisnite bilo koju tipku za povratak...");
        Console.ReadKey();
    }

    public static void ShowFullscreenMessage(string message)
    {
        Console.Clear();
        Console.Write("{0}\n\n{1}\n\n", Title, message);
        Halt();
    }
    
    public static int PromptMenu(Tuple<string, Action>[] options, string? subtitle = null)
    {
        Console.Clear();

        Console.WriteLine("{0}\n", Title);
        if (subtitle is not null)
            Console.WriteLine("{0}\n", subtitle);

        for (var i = 0; i < options.Length; i++)
        {
            Console.WriteLine(
                $"{(i != options.Length - 1 ? i + 1 : 0)} - {options[i].Item1}"
            );
        }

        Console.WriteLine();
        var choice = OneLinePromptIntInRange("Odabir: ", -1, options.Length);
        options[(choice == 0 ? options.Length : choice) - 1].Item2();
        return choice;
    }

    private static void BringCursorBackToPrompt(int promptLength, int userInputLength)
    {
        for (var i = 0; i < (promptLength + userInputLength) / Console.BufferWidth + 1; i++)
            Console.CursorTop--;
        Console.CursorLeft = promptLength;
        var savedPos = Console.GetCursorPosition();
        Console.Write(new string(' ', userInputLength));
        Console.SetCursorPosition(savedPos.Left, savedPos.Top);

        var invalidInputWarning = "Nevažeći unos!";
        Console.Write("\a\x1b[31mNevažeći unos!\x1b[0m");
        Thread.Sleep(1500);
        Console.Write(new string('\b', invalidInputWarning.Length));
        Console.Write(new string(' ', invalidInputWarning.Length));
        Console.Write(new string('\b', invalidInputWarning.Length));
    }

    public static int OneLinePromptIntInRange(string prompt, int lower, int higher)
    {
        Console.Write(prompt);
        var firstLoop = true;
        var lastEnteredLength = 0;
        while (true)
        {
            if (!firstLoop)
                BringCursorBackToPrompt(prompt.Length, lastEnteredLength);
            else
                firstLoop = false;

            var inputted = Console.ReadLine();
            if (inputted is null)
                continue;
            inputted = inputted.Trim();
            lastEnteredLength = inputted.Length;

            if (!int.TryParse(inputted, out var parsed)) continue;
            if (parsed > lower && parsed < higher) return parsed;
        }
    }
    
    public static string OneLinePromptString(string prompt)
    {
        Console.Write(prompt);
        var isFirstLoop = true;
        while (true)
        {
            if (!isFirstLoop)
                BringCursorBackToPrompt(prompt.Length, 0);
            else
                isFirstLoop = false;

            var inputted = Console.ReadLine();
            if (inputted is null) continue;
            inputted = inputted.Trim();

            return inputted;
        }
    }
    
    public static string TurnTableIntoString(List<List<string>> tableData)
    {
        var maxStringLengthForEachColumn = new int[tableData[0].Count];
        foreach (var row in tableData)
        {
            for (var i = 0; i < row.Count; i++)
            {
                if (row[i].Length > maxStringLengthForEachColumn[i])
                    maxStringLengthForEachColumn[i] = row[i].Length;
            }
        }

        var table = "";
        var tableSeparator = '+' + new string('-',
            maxStringLengthForEachColumn.Sum() + (maxStringLengthForEachColumn.Length + 2) * 2) + '+';

        table += $"\n{tableSeparator}\n";

        for (var j = 0; j < tableData.Count; j++)
        {
            var row = tableData[j];
            for (var i = 0; i < row.Count; i++)
            {
                table += $"| {row[i]} ";
                table += new string(' ', maxStringLengthForEachColumn[i] - row[i].Length);
                if (i == row.Count - 1) table += '|';
            }
            
            if (j == 0 || j == tableData.Count - 1) table += $"\n{tableSeparator}";
            if (j != tableData.Count - 1) table += '\n';
        }

        return table;
    }

    public static void PrintTable(List<List<string>> tableData)
    {
        Console.WriteLine(TurnTableIntoString(tableData));
    }
}

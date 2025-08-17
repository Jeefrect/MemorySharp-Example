namespace T3_Trainer;

static class ConsoleUi
{
    public static int? AskForNewValue(int currentValue)
    {
        Console.WriteLine($"Value now: {currentValue}");
        Console.Write("New value (q for exit): ");
        
        string? input = Console.ReadLine();

        if (input?.Trim().ToLower() == "q") 
            return null;

        return int.TryParse(input, out int val) ? val : -1;
    }
}

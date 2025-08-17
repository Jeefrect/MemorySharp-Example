using System.Diagnostics;

namespace T3_Trainer;

static class Program
{
    static void Main()
    {
        try
        {
            var process = Process.GetProcessesByName("t3")[0];
            if (process.MainModule == null)
                throw new Exception("Failed to get process.");

            var memory = new MemoryHandler(process);
            
            IntPtr baseAddress = process.MainModule.BaseAddress + 0x00B38C0C;
            int[] offsets = [0x80, 0x8];
            
            IntPtr finalAddress = memory.ResolvePointerChain(baseAddress, offsets);

            while (true)
            {
                int currentValue = memory.ReadInt32(finalAddress);
                int? newValue = ConsoleUi.AskForNewValue(currentValue);

                if (newValue == null)
                    break;

                if (newValue == -1)
                    Console.WriteLine("Invalid value.\n");

                else
                {
                    memory.WriteInt32(finalAddress, newValue.Value);
                    Console.WriteLine($"New value: {newValue}\n");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
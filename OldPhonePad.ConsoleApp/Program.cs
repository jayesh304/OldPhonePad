namespace OldPhonePad.ConsoleApp;

public class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection()
            .RegisterServices();

        var provider = services.BuildServiceProvider();
        var phonePadService = provider.GetRequiredService<IOldPhonePadService>();

        var history = new List<(string input, string output)>();

        Console.WriteLine("OldPhonePad Console");
        Console.WriteLine("Type input using digits (0-9), *, # and space. Type 'history' to view past inputs. Type 'exit' to quit.\n");

        while (true)
        {
            Console.Write("> ");
            string? input = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input was empty. Try again.");
                continue;
            }

            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            if (input.Equals("history", StringComparison.OrdinalIgnoreCase))
            {
                if (history.Count == 0)
                {
                    Console.WriteLine("No history yet.");
                }
                else
                {
                    Console.WriteLine("Input History:");
                    foreach (var (inputEntry, outputEntry) in history)
                    {
                        Console.WriteLine($"  Input: {inputEntry} => Output: {outputEntry}");
                    }
                }
                continue;
            }

            if (!IsValidInput(input))
            {
                Console.WriteLine("Invalid input. Only digits (0-9), '*', '#', and space are allowed.");
                continue;
            }

            try
            {
                string output = phonePadService.ParseInput(input);
                Console.WriteLine($"Output: {output}");

                history.Add((input, output));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing input: {ex.Message}");
            }
        }
    }

    private static bool IsValidInput(string input)
    {
        foreach (char c in input)
        {
            if (!(char.IsDigit(c) || c == '*' || c == '#' || c == ' '))
                return false;
        }
        return true;
    }
}

namespace OldPhonePad.ConsoleApp;

public class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection()
            .RegisterServices();

        var provider = services.BuildServiceProvider();

        var phonePadService = provider.GetRequiredService<IOldPhonePadService>();

        Console.WriteLine("Enter OldPhonePad input (end with #):");
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Input was empty or null.");
            return;
        }

        string output = phonePadService.ParseInput(input);
        Console.WriteLine($"Output: {output}");
    }
}
using OldPhonePad.Core.Extensions;

namespace OldPhonePad.Core;

public class OldPhonePadService : IOldPhonePadService
{
    private static readonly Dictionary<char, string> keypad = new()
    {
        {'1', ""}, {'2', "ABC"}, {'3', "DEF"},
        {'4', "GHI"}, {'5', "JKL"}, {'6', "MNO"},
        {'7', "PQRS"}, {'8', "TUV"}, {'9', "WXYZ"},
        {'0', " "}

    };

    public string ParseInput(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return "";
        input = input.FilterValidPhonePadChars();

        var final = new StringBuilder();
        var temp = new StringBuilder();
        bool hashEncountered = false;

        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];

            if (c == '#')
            {
                Process(final, temp);
                hashEncountered = true;
                break;
            }
            else if (c == '*')
            {
                Process(final, temp);
                if (final.Length > 0) final.Length--;
            }
            else if (c == ' ')
            {
                Process(final, temp);
            }
            else if (char.IsDigit(c))
            {
                if (temp.Length == 0 || temp[^1] == c)
                    temp.Append(c);
                else
                {
                    Process(final, temp);
                    temp.Append(c);
                }
            }
        }

        if (!hashEncountered)
        {
            Process(final, temp);
        }

        return final.ToString();
    }

    private static void Process(StringBuilder final, StringBuilder temp)
    {
        if (temp.Length == 0) return;

        char digit = temp[0];
        int count = temp.Length;

        if (keypad.TryGetValue(digit, out string? letters) && letters.Length > 0)
        {
            char letter = letters[(count - 1) % letters.Length];
            final.Append(letter);
        }

        temp.Clear();
    }
}

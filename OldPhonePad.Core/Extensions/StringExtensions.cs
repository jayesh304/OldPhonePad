namespace OldPhonePad.Core.Extensions;

public static class StringExtensions
{
    public static string FilterValidPhonePadChars(this string input)
    {
        return new string(input.Where(IsValidChar).ToArray());
    }

    private static bool IsValidChar(char c)
    {
        return char.IsDigit(c) || c == '*' || c == '#' || c == ' ';
    }
}

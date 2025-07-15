using OldPhonePad.Core.Extensions;

namespace OldPhonePad.Tests;

public class StringExtensionsTests
{
    [Theory]
    [InlineData("123ABC#", "123#")]
    [InlineData("4 5@6*", "4 56*")]
    [InlineData("", "")]
    public void ShouldFilterValidPhonePadCharacters(string input, string expected)
    {
        var result = input.FilterValidPhonePadChars();
        result.ShouldBe(expected);
    }
}

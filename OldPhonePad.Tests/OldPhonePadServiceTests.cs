namespace OldPhonePad.Tests;
using OldPhonePad.Core;
using Shouldly;

public class OldPhonePadServiceTests
{
    private readonly OldPhonePadService _service = new();

    [Theory(DisplayName = "Should correctly parse valid inputs")]
    [InlineData("33#", "E")]
    [InlineData("227*#", "B")]
    [InlineData("4433555 555666#", "HELLO")]
    [InlineData("8 88777444666*664#", "TURING")]
    [InlineData("227**#", "")]
    [InlineData("4433555abc#", "HEL")]
    [InlineData("777733", "SE")]
    [InlineData("777733#", "SE")]
    [InlineData("227#", "BP")]
    public void ShouldReturnExpectedOutput(string input, string expected)
    {
        var result = _service.ParseInput(input);
        result.ShouldBe(expected);
    }

    [Fact(DisplayName = "Empty input should return empty string")]
    public void EmptyInput_ShouldReturnEmpty()
    {
        var result = _service.ParseInput("");
        result.ShouldBeEmpty();
    }

    [Fact(DisplayName = "Null input should return empty string")]
    public void NullInput_ShouldReturnEmpty()
    {
        var result = _service.ParseInput(null);
        result.ShouldBeEmpty();
    }

    [Fact(DisplayName = "Only backspaces should not throw")]
    public void OnlyBackspaces_ShouldNotCrash()
    {
        var result = _service.ParseInput("***#");
        result.ShouldBeEmpty();
    }

    [Fact(DisplayName = "Backspace with empty final should not throw")]
    public void BackspaceWhenFinalIsEmpty_ShouldNotCrash()
    {
        var result = _service.ParseInput("*#");
        result.ShouldBeEmpty();
    }

    [Fact(DisplayName = "Only hash should return empty")]
    public void OnlyHash_ShouldReturnEmpty()
    {
        var result = _service.ParseInput("#");
        result.ShouldBeEmpty();
    }

    [Fact(DisplayName = "Invalid characters are ignored")]
    public void InvalidCharacters_ShouldBeIgnored()
    {
        var result = _service.ParseInput("222!@#");
        result.ShouldBe("C");
    }

    [Fact(DisplayName = "Trailing input without # should still be processed")]
    public void TrailingInputWithoutHash_ShouldBeProcessed()
    {
        var result = _service.ParseInput("2 22");
        result.ShouldBe("AB");
    }

    [Fact(DisplayName = "Can build full alphabet")]
    public void CanBuildFullAlphabet()
    {
        var input = string.Join(" ", new[]
        {
            "2",     // A
            "22",    // B
            "222",   // C
            "3",     // D
            "33",    // E
            "333",   // F
            "4",     // G
            "44",    // H
            "444",   // I
            "5",     // J
            "55",    // K
            "555",   // L
            "6",     // M
            "66",    // N
            "666",   // O
            "7",     // P
            "77",    // Q
            "777",   // R
            "7777",  // S
            "8",     // T
            "88",    // U
            "888",   // V
            "9",     // W
            "99",    // X
            "999",   // Y
            "9999"   // Z
        }) + "#";

        var result = _service.ParseInput(input);
        result.ShouldBe("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
    }
}



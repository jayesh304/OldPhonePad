namespace OldPhonePad.Tests;

public class OldPhonePadServiceTests
{
    private readonly OldPhonePadService _service = new();

    [Theory]
    [InlineData("33#", "E")]
    [InlineData("227*#", "B")]
    [InlineData("4433555 555666#", "HELLO")]
    [InlineData("8 88777444666*664#", "TURING")]
    public void ShouldReturnExpectedOutput(string input, string expected)
    {
        var result = _service.ParseInput(input);
        result.ShouldBe(expected);
    }

    [Fact]
    public void EmptyInput_ShouldReturnEmpty()
    {
        var result = _service.ParseInput("");
        result.ShouldBeEmpty();
    }
}


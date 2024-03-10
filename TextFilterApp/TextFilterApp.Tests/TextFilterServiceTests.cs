using TextFilterApp.Application.Services;

namespace TextFilterApp.Tests;

public class TextFilterServiceTests
{
    [Theory]
    [InlineData("clean what currently the rather", "")]
    [InlineData("at to tree", "")]
    [InlineData("cat bat mat", "")]
    [InlineData("filter out words", "words")]
    public void Apply_ReturnsCorrectlyFilteredText(string input, string expected)
    {
        var service = new TextFilterService();
        var result = service.ApplyAsync(input).Result;
        Assert.Equal(expected, result);
    }
}


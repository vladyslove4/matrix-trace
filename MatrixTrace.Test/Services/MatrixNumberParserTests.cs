using MatrixTrace.Services;

namespace MatrixTrace.Tests.Services;

public class MatrixNumberParserTests
{
    private MatrixNumberParser _parser;

    public MatrixNumberParserTests()
    {
        _parser = new MatrixNumberParser();
    }

    [Theory]
    [InlineData("22", 22)]
    [InlineData("-1", -1)]
    [InlineData("0", 0)]
    public void ParseInput_DataIsPassed_ReturnsValidInteger(string input, int expected)
    {
        var actualResult = _parser.ParseData(input);

        Assert.Equal(expected, actualResult);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("yreyrefdk")]
    [InlineData("2,4")]
    [InlineData("99999999999999999999999")]
    [InlineData(null)]
    public void ParseData_NotValidStringIsPassed_ReturnsException(string input)
    {
        Assert.Throws<ArgumentNullException>(() => _parser.ParseData(input));
    }
}

using MatrixTrace.Services;

namespace MatrixTrace.Tests.Services;

public class MatrixConsoleServiceTests
{
    private MatrixService _matrix;

    public MatrixConsoleServiceTests()
    {
        _matrix = new MatrixConsoleService();
    }

    [Fact]
    public void MatrixTraceSum_DataIsPassed_ReturnsMatrix()
    {
        int[,] testMatrix = new int[,]
        {
                {5,3,3},
                {3,3,3},
                {3,3,1}
        };

        int expected = 9;
        var actualResult = _matrix.MatrixTraceSum(testMatrix);

        Assert.Equal(expected, actualResult);
    }

    [Theory]
    [InlineData(2, -2, "height")]
    [InlineData(-2, 2, "width")]
    [InlineData(999999999, 999999999, "width")]
    [InlineData(null, 2, "width")]
    [InlineData(2, null, "height")]
    public void FillMatrix_NotValidInput_ExceptionCatched(int width, int height, string param)
    {
        var ex = Assert.Throws<ArgumentException>(() => _matrix.FillMatrix(width, height));
        Assert.Equal(ex.ParamName, param);
    }

    [Fact]
    public void FillSnailMatrix_NullIsPassed_ReturnsException()
    {
        int[,]? input = null;

        Assert.Throws<ArgumentNullException>(() => _matrix.PrintSnailMatrix(input));
    }
}

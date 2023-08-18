using MatrixTrace.Interfaces;

namespace MatrixTrace.Services;

internal abstract class MatrixService : IMatrixService
{
    private Random _random = new Random((int)DateTime.Now.Ticks);

    public int[,] FillMatrix(int width, int height)
    {
        const int minValue = 0;
        const int maxValue = 100;

        if (width <= minValue || width > maxValue)
            throw new ArgumentException($"{nameof(width)} must have a value beetween 1 and 100.", nameof(width));

        if (height <= minValue || height > maxValue)
            throw new ArgumentException($"{nameof(height)} must have value beetween 1 and 100.", nameof(height));

        int[,] matrix = new int[width, height];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                matrix[i, j] = _random.Next(0, 101);
            }
        }

        return matrix;
    }

    public int MatrixTraceSum(int[,] matrix)
    {
        ArgumentNullException.ThrowIfNull(matrix);

        int matrixTraceSum = 0;

        int min = Math.Min(matrix.GetLength(0), matrix.GetLength(1));

        for (int i = 0; i < min; i++)
        {
            int tempTrace = matrix[i, i];
            matrixTraceSum = matrixTraceSum + tempTrace;
        }

        return matrixTraceSum;
    }

    public abstract void PrintMatrix(int[,] matrix);

    public abstract void PrintSnailMatrix(int[,] matrix);
}







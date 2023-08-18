namespace MatrixTrace.Interfaces;

public interface IMatrixService
{
    int MatrixTraceSum(int[,] matrix);
    int[,] FillMatrix(int width, int height);
    void PrintMatrix(int[,] testMatrix);
    void PrintSnailMatrix(int[,] matrix);
}

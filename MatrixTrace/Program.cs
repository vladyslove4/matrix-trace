using MatrixTrace.Interfaces;
using MatrixTrace.Services;

namespace MatrixTrace;


class Program
{
    static void Main(string[] args)
    {
        IMatrixNumberParser parser = new MatrixNumberParser();
        IMatrixService service = new MatrixConsoleService();   
        Console.WriteLine("Enter width and height:");

        string? inputWidth = Console.ReadLine();
        string? inputHeight = Console.ReadLine();
        int width = parser.ParseData(inputWidth);
        int height = parser.ParseData(inputHeight);

        var testMatrix = service.FillMatrix(width, height);

        service.PrintMatrix(testMatrix);

        ConsoleLineSeparator();

        service.PrintSnailMatrix(testMatrix);

        ConsoleLineSeparator();

        Console.WriteLine("Matrix Trace Sum = " + service.MatrixTraceSum(testMatrix));
    }
    static void ConsoleLineSeparator()
    {
        Console.WriteLine();
        Console.WriteLine(new string('_',55));
        Console.WriteLine();
    }
}

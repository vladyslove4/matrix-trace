namespace MatrixTrace.Services;

internal class MatrixConsoleService : MatrixService
{
    public override void PrintMatrix(int[,] matrix)
    {
        ArgumentNullException.ThrowIfNull(matrix);

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            Console.WriteLine();

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (j == i)
                {
                    string temp = matrix[i, j].ToString();
                    PrintTraceNumber(temp.PadLeft(4));
                }
                else
                {
                    string temp = matrix[i, j].ToString();
                    Console.Write(temp.PadLeft(4));
                }
            }
        }
    }

    private void PrintTraceNumber(string trace)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(trace);
        Console.ResetColor();
    }

    public override void PrintSnailMatrix(int[,] matrix)
    {
        ArgumentNullException.ThrowIfNull(matrix);

        int top = 0;
        int bottom = matrix.GetLength(0) - 1;
        int left = 0;
        int right = matrix.GetLength(1) - 1;
        int direction = 0;
        const int LeftToRight = 0;
        const int TopToBottom = 1;
        const int RightToLeft = 2;
        const int BottomToTop = 3;

        while (top < bottom && left <= right)
        {
            if (direction is LeftToRight)
            {
                for (int i = left; i <= right; i++)
                {
                    Console.Write(" " + matrix[top, i]);
                }
                direction = 1;
                top++;
            }
            else if (direction is TopToBottom)
            {
                for (int i = top; i <= bottom; i++)
                {
                    Console.Write(" " + matrix[i, right]);
                }
                direction = 2;
                right--;
            }
            else if (direction is RightToLeft)
            {
                for (int i = right; i >= left; i--)
                {
                    Console.Write(" " + matrix[bottom, i]);
                }
                direction = 3;
                bottom--;
            }
            else if (direction is BottomToTop)
            {
                for (int i = bottom; i >= top; i--)
                {
                    Console.Write(" " + matrix[i, left]);
                }
                direction = 0;
                left++;
            }
        }
    }
}

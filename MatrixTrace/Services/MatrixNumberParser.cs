namespace MatrixTrace.Services;

internal class MatrixNumberParser : IMatrixNumberParser
{
    public int ParseData(string data)
    {
        ArgumentNullException.ThrowIfNull(data);

        if (int.TryParse(data, out int number))
        {
            return number;
        }
        else
        {
            throw new ArgumentNullException(nameof(data));
        }
    }
}


namespace FroggerGameConsole;

public struct Matice
{
    public int Width;
    public int Height;
    public char[,] Data;

    public Matice(int width, int height)
    {
        Data = new char[height, width];
        Width = Data.GetLength(1);
        Height = Data.GetLength(0);
    }

    public void Vymazat()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Data[y, x] = '-';
            }
        }
    }

    public void Vykreslit()
    {
        Console.SetCursorPosition(0, 0);

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                Console.Write(Data[y, x]);
            }
            Console.WriteLine();
        }
    }
}

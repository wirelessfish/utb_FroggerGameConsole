namespace FroggerGameConsole;

public class HracEntity : Entita
{
    private int zivoty = 3;

    public HracEntity(char[,] sprite, int x, int y)
        : base(sprite, x, y) { }

    public int GetZivoty()
    {
        return zivoty;
    }

    public void SetZivoty(int n)
    {
        zivoty = n;
    }

    public void PridatZivoty(int n)
    {
        zivoty += n;
    }
}

namespace FroggerGameConsole;

public class Entita
{
    private int x;
    private int y;
    private int width;
    private int height;
    private char[,] sprite;

    public Entita(char[,] sprite, int x, int y)
    {
        this.x = x;
        this.y = y;
        this.sprite = sprite;
        this.height = sprite.GetLength(0);
        this.width = sprite.GetLength(1);
    }

    public void Vykresli(Matice matice)
    {
        int displayHeight = matice.Height;
        int displayWidth = matice.Width;

        for (int spriteX = 0; spriteX < width; spriteX++)
        {
            for (int spriteY = 0; spriteY < height; spriteY++)
            {
                if (y + spriteY < 0 || x + spriteX < 0)
                {
                    continue;
                }
                if (x + spriteX > (displayWidth - 1) || y + spriteY > (displayHeight - 1))
                {
                    continue;
                }

                matice.Data[this.y + spriteY, this.x + spriteX] = sprite[spriteY, spriteX];
            }
        }
    }

    /** Pricte x a y ke sve pozici */
    public void PricistPozici(int x, int y)
    {
        this.x += x;
        this.y += y;
    }

    /** Nastavi svou pozici na x a y */
    public void NastavPozici(int noveX, int noveY)
    {
        this.x = noveX;
        this.y = noveY;
    }

    public int GetX()
    {
        return this.x;
    }

    public int GetY()
    {
        return this.y;
    }

    public int GetWidth()
    {
        return this.width;
    }

    public int GetHeight()
    {
        return this.height;
    }

    public bool Pronika(int cilX, int cilY)
    {
        for (int w = 0; w < width; w++)
        {
            for (int h = 0; h < height; h++)
            {
                if (x + w == cilX && y + h == cilY)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public bool Pronika(Entita druhaEntita)
    {
        for (int w = 0; w < width; w++)
        {
            for (int h = 0; h < height; h++)
            {
                if (druhaEntita.Pronika(x + w, y + h))
                {
                    return true;
                }
            }
        }

        return false;
    }
}

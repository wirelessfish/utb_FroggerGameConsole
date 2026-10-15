namespace FroggerGameConsole;

public class Game
{
    private List<Entita> auta;
    private HracEntity hrac;
    Matice displayMatice;
    private int width;
    private int height;
    private bool gameOver;

    public Game(int width, int height)
    {
        displayMatice = new Matice(width, height);
        char[,] spriteHrac = new char[,]
        {
            { 'z' },
        };
        hrac = new HracEntity(spriteHrac, 0, 0);

        gameOver = false;
        auta = new List<Entita>();
        this.width = 16;
        this.height = 20;

        char[,] spriteAuto = new char[,]
        {
            { '1', '2' },
            { '3', '4' },
        };

        char[,] spriteVelkeAuto = new char[,]
        {
            { 'a', 'b', 'c' },
            { 'e', 'f', 'g' },
        };

        char[,] spriteAutobus = new char[,]
        {
            { 'b', 'b', 'b', 'b', 'b' },
        };

        Entita auto = new Entita(spriteAuto, 0, height / 3);
        Entita auto2 = new Entita(spriteVelkeAuto, 0, height / 3 * 2);
        Entita autobus = new Entita(spriteAutobus, 0, 3);
        auta.Add(auto);
        auta.Add(auto2);
        auta.Add(autobus);
    }

    private void GameOver()
    {
        Console.WriteLine("Game Over");

        while (!Console.KeyAvailable)
        {
            System.Threading.Thread.Sleep(40);
        }

        Environment.Exit(0);
    }

    private void UserInput()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKey klavesa = Console.ReadKey().Key;

            switch (klavesa)
            {
                case ConsoleKey.LeftArrow:
                    if (hrac.GetX() > 0)
                    {
                        hrac.PricistPozici(-1, 0);
                    }

                    break;
                case ConsoleKey.RightArrow:
                    if (hrac.GetX() < (width - 1))
                    {
                        hrac.PricistPozici(1, 0);
                    }

                    break;
                case ConsoleKey.UpArrow:
                    if (hrac.GetY() > 0)
                    {
                        hrac.PricistPozici(0, -1);
                    }

                    break;
                case ConsoleKey.DownArrow:
                    if (hrac.GetY() < (height - 1))
                    {
                        hrac.PricistPozici(0, 1);
                    }

                    break;
                case ConsoleKey.Q:
                    gameOver = true;
                    break;
            }
        }
    }

    private void Process()
    {
        foreach (var a in auta)
        {
            a.PricistPozici(1, 0);
            if (a.GetX() + 1 > (width - 1))
            {
                a.NastavPozici(0 - a.GetWidth(), a.GetY());
            }
        }

        foreach (var a in auta)
        {
            if (a.Pronika(hrac))
            {
                hrac.PridatZivoty(-1);
            }
        }

        if (hrac.GetZivoty() <= 0)
        {
            gameOver = true;
        }
    }

    private void Render()
    {
        displayMatice.Vymazat();

        hrac.Vykresli(displayMatice);

        foreach (var entita in auta)
        {
            entita.Vykresli(displayMatice);
        }

        displayMatice.Vykreslit();
    }

    public void Run()
    {
        Console.CursorVisible = false;

        while (!gameOver)
        {
            UserInput();
            Process();
            Render();
            System.Threading.Thread.Sleep(40);
        }

        GameOver();
    }
}

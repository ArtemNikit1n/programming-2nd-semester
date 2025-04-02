namespace Game;

public class Game
{
    private const int Width = 40;
    private const int Height = 12;
    private const string MapFilePath = "Map.txt";
    private readonly char[][] Map = new char[Height][];

    private (int X, int Y) Position;

    public Game()
    {
        Console.CursorVisible = false;
        Position = (0, 0);

        Console.Clear();
        this.ReadMap();
        this.WriteMap();

        Console.SetCursorPosition(0, Height + 1);
        this.PrintWelcomeMassage();

        Console.SetCursorPosition(0, 0);
        Console.Write("@");
    }

    public void OnLeft(object sender, EventArgs args)
    {
        if (this.Position.X <= 0 || this.Map[this.Position.Y][this.Position.X - 1] == '#')
        {
            return;
        }

        Console.SetCursorPosition(this.Position.X, this.Position.Y);

        Console.Write(' ');
        this.Position.X--;

        Console.SetCursorPosition(this.Position.X, this.Position.Y);
        Console.Write("@");
    }

    public void OnRight(object sender, EventArgs args)
    {
        if (this.Position.X >= Width - 1 || this.Map[this.Position.Y][this.Position.X + 1] == '#')
        {
            return;
        }

        Console.SetCursorPosition(this.Position.X, this.Position.Y);
        Console.Write(' ');
        this.Position.X++;

        Console.SetCursorPosition(this.Position.X, this.Position.Y);
        Console.Write("@");
    }

    public void OnUp(object sender, EventArgs args)
    {
        if (this.Position.Y <= 0 || this.Map[this.Position.Y - 1][this.Position.X] == '#')
        {
            return;
        }

        Console.SetCursorPosition(this.Position.X, this.Position.Y);
        Console.Write(' ');
        this.Position.Y--;

        Console.SetCursorPosition(this.Position.X, this.Position.Y);
        Console.Write("@");
    }

    public void OnDown(object sender, EventArgs args)
    {
        if (this.Position.Y >= Height - 1 || this.Map[this.Position.Y + 1][this.Position.X] == '#')
        {
            return;
        }

        Console.SetCursorPosition(this.Position.X, this.Position.Y);
        Console.Write(' ');
        this.Position.Y++;

        Console.SetCursorPosition(this.Position.X, this.Position.Y);
        Console.Write("@");
    }

    public void End(object sender, EventArgs args)
    {
        Console.SetCursorPosition(Width, Height + 2);
        Console.CursorVisible = true;
        Console.WriteLine();
    }

    private void ReadMap()
    {
        if (!File.Exists(MapFilePath))
        {
            throw new FileNotFoundException($"Map file not found: {MapFilePath}");
        }

        var lines = File.ReadAllLines(MapFilePath);

        for (var i = 0; i < Height; ++i)
        {
            this.Map[i] = new char[Width];

            for (var j = 0; j < Width; ++j)
            {
                this.Map[i][j] = lines[i][j];
            }
        }
    }

    private void WriteMap()
    {
        for (var i = 0; i < Height; i++)
        {
            for (var j = 0; j < Width; j++)
            {
                Console.Write(this.Map[i][j]);
            }

            Console.WriteLine();
        }
    }

    private void PrintWelcomeMassage()
    {
        Console.WriteLine("Welcome to the game! To move - arrows, to exit - Esc");
    }
}
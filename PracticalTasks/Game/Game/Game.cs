namespace Game;

public class Game
{
    public void OnLeft(object sender, EventArgs args)
    {
        Console.CursorLeft--;
        Console.Write("@");
        Console.CursorLeft--;
    }

    public void OnRight(object sender, EventArgs args)
    {
        Console.CursorLeft++;
        Console.Write("@");
    }

    public void OnUp(object sender, EventArgs args)
    {
        Console.CursorTop--;
        Console.Write("@");
        Console.CursorLeft--;
    }

    public void OnDown(object sender, EventArgs args)
    {
        Console.CursorTop++;
        Console.Write("@");
        Console.CursorLeft--;
    }
}
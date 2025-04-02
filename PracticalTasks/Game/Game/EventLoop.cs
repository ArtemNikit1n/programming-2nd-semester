public class EventLoop
{
    public event EventHandler<EventArgs> LeftHandler = (sender, args) => { };

    public event EventHandler<EventArgs> RightHandler = (sender, args) => { };

    public event EventHandler<EventArgs> UpHandler = (sender, args) => { };

    public event EventHandler<EventArgs> DownHandler = (sender, args) => { };

    public event EventHandler<EventArgs> EscapeHandler = (sender, args) => { };

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    this.LeftHandler(this, EventArgs.Empty);
                    break;
                case ConsoleKey.RightArrow:
                    this.RightHandler(this, EventArgs.Empty);
                    break;
                case ConsoleKey.UpArrow:
                    this.UpHandler(this, EventArgs.Empty);
                    break;
                case ConsoleKey.DownArrow:
                    this.DownHandler(this, EventArgs.Empty);
                    break;
                case ConsoleKey.Escape:
                    isRunning = false;
                    this.EscapeHandler(this, EventArgs.Empty);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
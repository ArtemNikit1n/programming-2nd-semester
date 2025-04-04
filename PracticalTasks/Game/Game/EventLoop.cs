// <copyright file="EventLoop.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game;

public class EventLoop
{
    public event EventHandler<EventArgs> LeftHandler = (_, _) => { };

    public event EventHandler<EventArgs> RightHandler = (_, _) => { };

    public event EventHandler<EventArgs> UpHandler = (_, _) => { };

    public event EventHandler<EventArgs> DownHandler = (_, _) => { };

    public event EventHandler<EventArgs> EscapeHandler = (_, _) => { };

    public void Run()
    {
        var isRunning = true;

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
// <copyright file="EventLoop.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game;

/// <summary>
/// Event loop.
/// </summary>
public class EventLoop
{
    /// <summary>
    /// Handler of left arrow.
    /// </summary>
    public event EventHandler<EventArgs> LeftHandler = (_, _) => { };

    /// <summary>
    /// Handler of right arrow.
    /// </summary>
    public event EventHandler<EventArgs> RightHandler = (_, _) => { };

    /// <summary>
    /// Handler of up arrow.
    /// </summary>
    public event EventHandler<EventArgs> UpHandler = (_, _) => { };

    /// <summary>
    /// Handler of down arrow.
    /// </summary>
    public event EventHandler<EventArgs> DownHandler = (_, _) => { };

    /// <summary>
    /// Handler of Esc.
    /// </summary>
    public event EventHandler<EventArgs> EscapeHandler = (_, _) => { };

    /// <summary>
    /// Reading keys for character movement.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">There are exceptions for the case when the player pressed the wrong button.</exception>
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
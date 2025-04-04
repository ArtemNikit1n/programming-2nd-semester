// <copyright file="Game.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game;

/// <summary>
/// Realization of game.
/// </summary>
public class Game
{
    private const int Width = 40;
    private const int Height = 12;
    private const string MapFilePath = "../../../Map.txt";
    private readonly char[][] map = new char[Height][];

    private (int X, int Y) position;

    /// <summary>
    /// Initializes a new instance of the <see cref="Game"/> class.
    /// </summary>
    public Game()
    {
        Console.CursorVisible = false;
        this.position = (0, 0);

        Console.Clear();
        this.ReadMap();
        this.WriteMap();

        Console.SetCursorPosition(0, Height + 1);
        PrintWelcomeMassage();

        Console.SetCursorPosition(0, 0);
        Console.Write("@");
    }

    /// <summary>
    /// Handles the player's movement to the left when the left arrow key is pressed.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="args">Event arguments.</param>
    public void OnLeft(object? sender, EventArgs args)
    {
        if (this.position.X <= 0 || this.map[this.position.Y][this.position.X - 1] == '#')
        {
            return;
        }

        Console.SetCursorPosition(this.position.X, this.position.Y);

        Console.Write(' ');
        this.position.X--;

        Console.SetCursorPosition(this.position.X, this.position.Y);
        Console.Write("@");
    }

    /// <summary>
    /// Handles the player's movement to the right when the right arrow key is pressed.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="args">Event arguments.</param>
    public void OnRight(object? sender, EventArgs args)
    {
        if (this.position.X >= Width - 1 || this.map[this.position.Y][this.position.X + 1] == '#')
        {
            return;
        }

        Console.SetCursorPosition(this.position.X, this.position.Y);
        Console.Write(' ');
        this.position.X++;

        Console.SetCursorPosition(this.position.X, this.position.Y);
        Console.Write("@");
    }

    /// <summary>
    /// Controls the player's movement up when pressing the up arrow key.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="args">Event arguments.</param>
    public void OnUp(object? sender, EventArgs args)
    {
        if (this.position.Y <= 0 || this.map[this.position.Y - 1][this.position.X] == '#')
        {
            return;
        }

        Console.SetCursorPosition(this.position.X, this.position.Y);
        Console.Write(' ');
        this.position.Y--;

        Console.SetCursorPosition(this.position.X, this.position.Y);
        Console.Write("@");
    }

    /// <summary>
    /// Controls the player's movement down when pressing the down arrow key.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="args">Event arguments.</param>
    public void OnDown(object? sender, EventArgs args)
    {
        if (this.position.Y >= Height - 1 || this.map[this.position.Y + 1][this.position.X] == '#')
        {
            return;
        }

        Console.SetCursorPosition(this.position.X, this.position.Y);
        Console.Write(' ');
        this.position.Y++;

        Console.SetCursorPosition(this.position.X, this.position.Y);
        Console.Write("@");
    }

    /// <summary>
    /// Exit from the game.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="args">Event arguments.</param>
    public void End(object? sender, EventArgs args)
    {
        Console.SetCursorPosition(Width, Height + 2);
        Console.CursorVisible = true;
        Console.WriteLine();
    }

    private static void PrintWelcomeMassage()
    {
        Console.WriteLine("Welcome to the game! To move - arrows, to exit - Esc");
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
            this.map[i] = new char[Width];

            for (var j = 0; j < Width; ++j)
            {
                this.map[i][j] = lines[i][j];
            }
        }
    }

    private void WriteMap()
    {
        for (var i = 0; i < Height; i++)
        {
            for (var j = 0; j < Width; j++)
            {
                Console.Write(this.map[i][j]);
            }

            Console.WriteLine();
        }
    }
}
// <copyright file="SuperGame.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WinFormsGame;

/// <summary>
/// The form for the game.
/// </summary>
public sealed partial class SuperGame : Form
{
    private const int MapLength = 28;
    private const int MapWidth = 28;
    private Image? playerImage;
    private int playerX = 1;
    private int playerY = 1;
    private int tileSize = 30;
    private int[,] map = new int[MapLength, MapWidth];
    private string mapPath = Path.Combine(AppContext.BaseDirectory, "Map.txt");

    private Button? buttonUp;
    private Button? buttonDown;
    private Button? buttonLeft;
    private Button? buttonRight;

    /// <summary>
    /// Initializes a new instance of the <see cref="SuperGame"/> class.
    /// </summary>
    public SuperGame()
    {
        this.AutoScaleMode = AutoScaleMode.None;
        this.DoubleBuffered = true;
        this.UploadPlayer();
        this.UploadMap();
        this.InitializeComponent();
        this.RemoveAbilityResizeWindow();

        this.Paint += this.DrawMap;
        this.Paint += this.DrawPlayer;
        this.KeyDown += this.ReadWasdForMovementPlayer;
    }

    private void RemoveAbilityResizeWindow()
    {
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.ClientSize = new Size(MapLength * this.tileSize, MapWidth * this.tileSize);
    }

    private void UploadMap()
    {
        if (!File.Exists(this.mapPath))
        {
            MessageBox.Show($"File {this.mapPath} does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        using StreamReader reader = new(this.mapPath);
        var i = 0;
        while (reader.ReadLine() is { } line)
        {
            for (var j = 0; j < line.Length; j++)
            {
                var currentChar = line[j];
                this.map[i, j] = int.Parse(currentChar.ToString());
            }

            i++;
        }
    }

    private void UploadPlayer()
    {
        try
        {
            this.playerImage = Image.FromFile(Path.Combine(AppContext.BaseDirectory, "KotoPlayer.png"));
        }
        catch
        {
            this.playerImage = new Bitmap(this.tileSize, this.tileSize);
            using var g = Graphics.FromImage(this.playerImage);
            g.FillEllipse(Brushes.IndianRed, 0, 0, this.tileSize, this.tileSize);
        }
    }

    private void DrawMap(object? sender, PaintEventArgs e)
    {
        if (sender == null)
        {
            return;
        }

        for (var y = 0; y < this.map.GetLength(0); y++)
        {
            for (var x = 0; x < this.map.GetLength(1); x++)
            {
                var brush = this.map[y, x] == 1 ? Brushes.MediumSeaGreen : Brushes.White;

                e.Graphics.FillRectangle(brush, x * this.tileSize, y * this.tileSize, this.tileSize, this.tileSize);
            }
        }
    }

    private void DrawPlayer(object? sender, PaintEventArgs e)
    {
        if (sender == null || this.playerImage == null)
        {
            return;
        }

        e.Graphics.DrawImage(
            this.playerImage,
            this.playerX * this.tileSize,
            this.playerY * this.tileSize,
            this.tileSize * 3,
            this.tileSize * 3);
    }

    private void MovePlayer(int x, int y)
    {
        var newX = this.playerX + x;
        var newY = this.playerY + y;

        for (var py = 0; py < 3; py++)
        {
            for (var px = 0; px < 3; px++)
            {
                var checkX = newX + px;
                var checkY = newY + py;

                if (checkX >= this.map.GetLength(1) ||
                    checkY >= this.map.GetLength(0) ||
                    this.map[checkY, checkX] == 1)
                {
                    return;
                }
            }
        }

        this.playerX = newX;
        this.playerY = newY;
        this.Invalidate();
    }

    private void ReadWasdForMovementPlayer(object? sender, KeyEventArgs e)
    {
        if (sender == null || this.playerImage == null)
        {
            return;
        }

        switch (e.KeyCode)
        {
            case Keys.W: this.MovePlayer(0, -1); break;
            case Keys.S: this.MovePlayer(0, 1);  break;
            case Keys.A: this.MovePlayer(-1, 0); break;
            case Keys.D: this.MovePlayer(1, 0);  break;
            default:
                return;
        }
    }
}

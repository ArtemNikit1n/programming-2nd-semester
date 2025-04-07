// <copyright file="SuperGame.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WinFormsGame;

/// <summary>
/// The form for the game.
/// </summary>
public partial class SuperGame : Form
{
    private static readonly int mapLength = 28;
    private static readonly int mapWidth = 28;
    private int[,] map = new int[mapLength, mapWidth];
    private string mapPath = "../../../Map.txt";

    /// <summary>
    /// Initializes a new instance of the <see cref="SuperGame"/> class.
    /// </summary>
    public SuperGame()
    {
        this.UploadMap(this.mapPath);
        this.InitializeComponent();
        this.RemoveAbilityResizeWindow();

        this.Paint += this.DrawMap;
    }

    private void RemoveAbilityResizeWindow()
    {
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.ClientSize = new Size(mapLength * 30, mapWidth * 30);
    }

    private void UploadMap(string filePath)
    {
        if (!File.Exists(filePath))
        {
            MessageBox.Show($"File {filePath} does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        using StreamReader reader = new(filePath);
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

    private void DrawMap(object? sender, PaintEventArgs e)
    {
        if (sender == null)
        {
            return;
        }

        const int tileSize = 30;

        for (var y = 0; y < this.map.GetLength(0); y++)
        {
            for (var x = 0; x < this.map.GetLength(1); x++)
            {
                var brush = this.map[y, x] == 1 ? Brushes.MediumSeaGreen : Brushes.White;

                e.Graphics.FillRectangle(brush, x * tileSize, y * tileSize, tileSize, tileSize);
            }
        }
    }
}

// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
Console.Clear();
Console.Write("@");
const string filePath = "../../../Map.txt";
try
{
    var content = File.ReadAllText(filePath);
    Console.WriteLine(content);
}
catch (FileNotFoundException)
{
    Console.WriteLine("Map not found:(");
}

var eventLoop = new EventLoop();
var game = new Game.Game();

eventLoop.LeftHandler += game.OnLeft;
eventLoop.RightHandler += game.OnRight;
eventLoop.UpHandler += game.OnUp;
eventLoop.DownHandler += game.OnDown;

eventLoop.Run();
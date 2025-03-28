﻿// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>


var eventLoop = new EventLoop();
var game = new Game();

eventLoop.LeftHandler += game.OnLeft;
eventLoop.RightHandler += game.OnRigth;
eventLoop.UpHandler += game.OnUp;
eventLoop.DownHandler += game.OnDown;

eventLoop.Run();
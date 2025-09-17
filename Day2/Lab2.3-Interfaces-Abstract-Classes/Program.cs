using Lab2_3;               // <-- add this
using Lab2_3.Models;
using Lab2_3.Services;

Console.WriteLine("=== Interfaces & Abstract Classes Demo ===\n");

// ----- Drawing Canvas Demo -----
Console.WriteLine(">>> Drawing Canvas Demo");
var canvas = new DrawingCanvas();
canvas.Add(new Circle(0, 0, 5, "Red"));
canvas.Add(new Rectangle(10, 5, 8, 3, "Blue"));
canvas.Add(new Triangle(3, 3, 3, 4, 5, "Green"));

canvas.DrawAll();
canvas.MoveAll(5, 5);
canvas.ResizeAll(1.5);
canvas.RecolorAll("Purple");
canvas.DrawAll();
canvas.PrintStats();

var clone = canvas.CloneFirst();
if (clone is not null) Console.WriteLine($"Clone description: {clone.GetDescription()}");

// ----- Media Library Demo -----
Console.WriteLine("\n>>> Media Library Demo");
var library = new MediaLibrary();
library.Add(new AudioPlayer("Lo-fi Beats", TimeSpan.FromMinutes(3)));
library.Add(new VideoPlayer("Ocean Timelapse", TimeSpan.FromMinutes(10), "4K"));

library.ShowDetails();
library.PlayAll();
library.SpecialOps();
library.SaveLoadRoundtrip();
library.Stats();
library.ShowDetails();

// ----- Advanced Interface Concepts -----
InterfaceConcepts.Run();

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();
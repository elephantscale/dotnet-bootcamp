using Lab2_3.Interfaces;
using Lab2_3.Models;

namespace Lab2_3.Services;

public class DrawingCanvas
{
    private readonly List<Shape> _shapes = new();

    public void Add(Shape shape)
    {
        _shapes.Add(shape);
        Console.WriteLine($"Added shape: {shape.GetDescription()}");
    }

    public void DrawAll()
    {
        Console.WriteLine("\nCanvas draw:");
        foreach (var s in _shapes) s.Draw();
    }

    public void MoveAll(int x, int y)
    {
        Console.WriteLine($"\nMoving all shapes to ({x},{y})");
        foreach (var s in _shapes) s.Move(x, y);
    }

    public void ResizeAll(double factor)
    {
        Console.WriteLine($"\nResizing all by factor {factor}");
        foreach (var s in _shapes) s.Resize(factor);
    }

    public void RecolorAll(string color)
    {
        Console.WriteLine($"\nRecoloring all to {color}");
        // Default interface methods must be invoked through the interface
        foreach (var s in _shapes)
        {
            if (s is IColorable c) c.SetColor(color);
        }
    }

    public void PrintStats()
    {
        Console.WriteLine("\nCanvas stats:");
        Console.WriteLine($"  Count: {_shapes.Count}");
        Console.WriteLine($"  Total Area: {_shapes.Sum(s => s.Area):0.##}");
        Console.WriteLine($"  Total Perimeter: {_shapes.Sum(s => s.Perimeter):0.##}");
    }

    public Shape? CloneFirst()
    {
        if (_shapes.Count == 0) return null;
        var clone = _shapes[0].DeepClone();
        Console.WriteLine($"Cloned: {clone.GetDescription()}");
        return clone;
    }
}
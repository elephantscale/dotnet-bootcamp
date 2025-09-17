using Lab2_3.Interfaces;

namespace Lab2_3.Models;

public abstract class Shape :
    IDrawable, IResizable, IColorable, IGeometric, IDeepCloneable<Shape>
{
    protected Shape(int x, int y, string color = "Black")
    {
        X = x; Y = y; Color = color;
    }

    public int X { get; private set; }
    public int Y { get; private set; }
    public string Color { get; set; }

    public abstract double Area { get; }
    public abstract double Perimeter { get; }

    public virtual void Draw()
        => Console.WriteLine($"Drawing {GetDescription()} at ({X},{Y}) with color {Color}");

    public virtual void Move(int x, int y)
    {
        X = x; Y = y;
        Console.WriteLine($"{GetType().Name} moved to ({X},{Y})");
    }

    public abstract void Resize(double factor);

    public virtual string GetDescription() => GetType().Name;

    public abstract Shape DeepClone();
}

public sealed class Circle : Shape
{
    public Circle(int x, int y, double radius, string color = "Black")
        : base(x, y, color) => Radius = radius;

    public double Radius { get; private set; }

    public override double Area => Math.PI * Radius * Radius;
    public override double Perimeter => 2 * Math.PI * Radius;

    public override void Resize(double factor)
    {
        if (factor <= 0) throw new ArgumentOutOfRangeException(nameof(factor));
        Radius *= factor;
        Console.WriteLine($"Circle resized -> radius {Radius:0.##}");
    }

    public override string GetDescription() => $"Circle (r={Radius:0.##})";

    public override Shape DeepClone() => new Circle(0, 0, Radius, Color);
}

public sealed class Rectangle : Shape
{
    public Rectangle(int x, int y, double width, double height, string color = "Black")
        : base(x, y, color)
    {
        Width = width; Height = height;
    }

    public double Width { get; private set; }
    public double Height { get; private set; }

    public override double Area => Width * Height;
    public override double Perimeter => 2 * (Width + Height);

    public override void Resize(double factor)
    {
        if (factor <= 0) throw new ArgumentOutOfRangeException(nameof(factor));
        Width *= factor; Height *= factor;
        Console.WriteLine($"Rectangle resized -> {Width:0.##} x {Height:0.##}");
    }

    public override string GetDescription() => $"Rectangle ({Width:0.##}x{Height:0.##})";

    public override Shape DeepClone() => new Rectangle(0, 0, Width, Height, Color);
}

public sealed class Triangle : Shape
{
    public Triangle(int x, int y, double a, double b, double c, string color = "Black")
        : base(x, y, color)
    {
        A = a; B = b; C = c;
    }

    public double A { get; private set; }
    public double B { get; private set; }
    public double C { get; private set; }

    public override double Perimeter => A + B + C;

    public override double Area
    {
        get
        {
            var s = Perimeter / 2.0;
            return Math.Sqrt(Math.Max(0, s * (s - A) * (s - B) * (s - C))); // Heron
        }
    }

    public override void Resize(double factor)
    {
        if (factor <= 0) throw new ArgumentOutOfRangeException(nameof(factor));
        A *= factor; B *= factor; C *= factor;
        Console.WriteLine($"Triangle resized -> sides {A:0.##}, {B:0.##}, {C:0.##}");
    }

    public override string GetDescription() => $"Triangle (a={A:0.##}, b={B:0.##}, c={C:0.##})";

    public override Shape DeepClone() => new Triangle(0, 0, A, B, C, Color);
}
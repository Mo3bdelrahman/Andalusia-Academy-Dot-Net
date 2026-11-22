namespace Session05.Polymorphism.Models;

public class Shape
{
    // virtual: derived classes MAY replace this.
    public virtual double Area() => 0;

    public virtual string Describe() => $"{GetType().Name} with area {Area():F2}";
}

public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double r) => Radius = r;

    public override double Area() => Math.PI * Radius * Radius;
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double w, double h)
    {
        Width = w;
        Height = h;
    }

    public override double Area() => Width * Height;
}

// sealed: no class can derive from Square.
public sealed class Square : Rectangle
{
    public Square(double side) : base(side, side)
    {
    }

    // base.Describe() runs the parent's version, then we add to it.
    public override string Describe() => base.Describe() + " (all sides equal)";

    public override string ToString() => $"Square({Width})";
}

// public class TinySquare : Square { }
//   error CS0509: 'TinySquare': cannot derive from sealed type 'Square'

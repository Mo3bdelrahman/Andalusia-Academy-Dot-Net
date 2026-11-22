namespace Session05.Properties.Models;

public class Rectangle
{
    public double Width { get; set; }
    public double Height { get; set; }

    // Computed: worked out every time, so always up to date.
    public double Area => Width * Height;
    public double Perimeter => 2 * (Width + Height);
}

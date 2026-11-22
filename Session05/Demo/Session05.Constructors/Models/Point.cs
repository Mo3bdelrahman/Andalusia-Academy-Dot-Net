namespace Session05.Constructors.Models;

// this.x = the field, x = the parameter (same name).
public class Point
{
    private int x;
    private int y;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public string Show() => $"({x}, {y})";
}

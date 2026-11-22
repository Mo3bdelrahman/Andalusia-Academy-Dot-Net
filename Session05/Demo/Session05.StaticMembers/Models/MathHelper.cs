namespace Session05.StaticMembers.Models;

// static class: only static members, and no objects can be created from it.
public static class MathHelper
{
    public const double Pi = 3.14159;          // const: can never be changed

    public static int Square(int n) => n * n;

    public static double CircleArea(double r) => Pi * r * r;
}

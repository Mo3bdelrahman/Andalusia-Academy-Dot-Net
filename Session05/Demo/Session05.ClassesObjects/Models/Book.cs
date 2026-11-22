namespace Session05.ClassesObjects.Models;

// required (C# 11): callers MUST set Title when they create a Book.
public class Book
{
    public required string Title { get; set; }
    public int Pages { get; set; }
}

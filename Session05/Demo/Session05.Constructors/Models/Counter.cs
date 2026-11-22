namespace Session05.Constructors.Models;

public class Counter
{
    private int _count;

    public int Count => _count;

    public void Increment() => _count++;

    public Counter Reset()
    {
        _count = 0;
        return this;               // the same object → allows chaining
    }
}

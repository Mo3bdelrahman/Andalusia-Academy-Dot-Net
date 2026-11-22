namespace Session05.Inheritance.Models;

public class Cat : Animal
{
    public Cat(string name) : base(name)
    {
    }

    public void Meow() => Console.WriteLine($"{Name} says: Meow!");
}

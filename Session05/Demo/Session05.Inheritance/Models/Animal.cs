namespace Session05.Inheritance.Models;

// The base class: what every animal has.
public class Animal
{
    public string Name { get; set; }

    public Animal(string name)
    {
        Name = name;
        Console.WriteLine($"  1. Animal(\"{name}\") constructor ran");
    }

    public void Breathe()
    {
        Console.WriteLine($"{Name} is breathing.");
    }
}

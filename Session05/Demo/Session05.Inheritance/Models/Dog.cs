namespace Session05.Inheritance.Models;

// Dog IS-A Animal: it gets Name and Breathe(), and adds Breed and Bark().
public class Dog : Animal
{
    public string Breed { get; set; }

    public Dog(string name, string breed)
        : base(name)                   // calls Animal(string name) first
    {
        Breed = breed;
        Console.WriteLine($"  2. Dog(\"{name}\", \"{breed}\") constructor ran");
    }

    public void Bark() => Console.WriteLine($"{Name} says: Woof!");
}

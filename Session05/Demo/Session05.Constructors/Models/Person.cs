namespace Session05.Constructors.Models;

public class Person
{
    public string Name;
    public int Age;
    public string Email;

    // Calls the three-parameter constructor first, then runs its own body.
    public Person(string name, int age) : this(name, age, "")
    {
        Console.WriteLine("  2. Person(name, age) body ran");
    }

    public Person(string name, int age, string email)
    {
        Name = name;
        Age = age;
        Email = email;
        Console.WriteLine("  1. Person(name, age, email) body ran");
    }

    public string Describe() => $"{Name}, {Age}, email: \"{Email}\"";
}

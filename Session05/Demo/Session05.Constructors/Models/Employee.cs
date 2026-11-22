namespace Session05.Constructors.Models;

// Primary constructor (C# 12): the parameters are written after the class name
// and can be used anywhere in the class.
public class Employee(string name, decimal salary)
{
    public string Name { get; } = name;
    public decimal Salary { get; } = salary;
}

namespace Session05.StaticMembers.Models;

public class User
{
    private static int _totalCreated = 0;      // ONE copy, shared by all users

    public string Name { get; set; }           // one copy PER user

    public User(string name)
    {
        Name = name;
        _totalCreated++;
    }

    public static int TotalCreated => _totalCreated;

    // An instance method can use both instance and static members.
    public string Describe() => $"{Name} (one of {_totalCreated} users)";

    // A static method has no 'this', so it can't use Name:
    // public static string Bad() => Name;
    //   error CS0120: An object reference is required for the non-static field, method, or property 'User.Name'
}

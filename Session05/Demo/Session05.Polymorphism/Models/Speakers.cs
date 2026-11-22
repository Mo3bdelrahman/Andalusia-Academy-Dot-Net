namespace Session05.Polymorphism.Models;

public class Speaker
{
    public virtual string Speak() => "Speaker: hello";   // can be overridden
    public string Greet() => "Speaker: hi";              // NOT virtual
}

public class Robot : Speaker
{
    // override: replaces Speak() even through a Speaker variable.
    public override string Speak() => "Robot: beep";

    // new: HIDES Greet(). Only used when the variable is a Robot.
    // Without 'new' it still hides, with warning CS0108.
    public new string Greet() => "Robot: hi";
}

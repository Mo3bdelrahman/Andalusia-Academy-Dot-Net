namespace Session05.Properties.Models;

// One member per access modifier.
public class Vault
{
    public string Label = "Main vault";          // anywhere
    private int _code = 1234;                    // only inside Vault
    protected int Level = 3;                     // Vault and classes derived from it
    internal string Branch = "Cairo";            // anywhere in this project

    public bool CheckCode(int code) => code == _code;   // Vault can use its own private field
}

public class SmallVault : Vault
{
    public int ReadLevel() => Level;             // protected: allowed in a derived class
    // public int ReadCode() => _code;           // error CS0122: '_code' is inaccessible due to its protection level
}

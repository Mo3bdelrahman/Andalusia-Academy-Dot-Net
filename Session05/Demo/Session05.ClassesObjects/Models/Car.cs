namespace Session05.ClassesObjects.Models;

// A class groups data (fields) with behaviour (methods).
// Public fields only for now; §5 replaces them with properties.
public class Car
{
    public string Brand = "";      // = "" avoids warning CS8618 (string can't be null)
    public int Year;

    public void StartEngine()
    {
        Console.WriteLine($"{Brand} engine started.");
    }
}

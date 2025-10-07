namespace Singleton;

public sealed class IDGenerator
{
    private IDGenerator() { } // Private constructor, preventing new()

    private static IDGenerator? _instance; // Ensures single shared instance 

    int _currentId = 0; // Private ID counter

    public static IDGenerator GetInstance() // Public way to access the instance
    {
        if (_instance == null)
        {
            _instance = new IDGenerator();
        }
        return _instance;
    }

    public int GenerateID() // Public method to generate an ID (duh)
    {
        _currentId += 1;
        return _currentId;
    }
}


class Program
{
    static void Main(string[] args)
    {
        // Check if method truly works
        IDGenerator s1 = IDGenerator.GetInstance();
        IDGenerator s2 = IDGenerator.GetInstance();

        if (s1 == s2)
        {
            Console.WriteLine("Singleton works, both variables contain the same instance.");
        }
        else
        {
            Console.WriteLine("Singleton failed, variables contain different instances.");
        }

        var generator = IDGenerator.GetInstance();
        Console.WriteLine("Generated ID: " + generator.GenerateID());
        Console.WriteLine("Generated ID: " + generator.GenerateID());
        Console.WriteLine("Generated ID: " + generator.GenerateID());
            
    }
}

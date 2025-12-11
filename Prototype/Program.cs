namespace Prototype;

public interface IEnemyPrototype
{
    IEnemyPrototype Clone();
    void DisplayInfo();
}

public class Hollow(string location, int damage, int health) : IEnemyPrototype
{
    public string Location { get; set; } = location;
    public int Damage { get; set; } = damage;
    public int Health { get; set; } = health;

    public IEnemyPrototype Clone()
    {
        return new Hollow(Location, Damage, Health);
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Hollow - Location: {Location}, Damage: {Damage}, Health: {Health}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n-----> Prototype Pattern Demo <-----\n");

        Hollow originalHollow = new Hollow("Undead Burg", 15, 100);
        Console.WriteLine("Original Hollow:");
        originalHollow.DisplayInfo();

        Hollow clonedHollow = (Hollow)originalHollow.Clone();

        Console.WriteLine("\nCloned Hollow:");
        clonedHollow.Location = "Darkroot Garden";
        clonedHollow.Damage = 20;
        clonedHollow.Health = 120;
        clonedHollow.DisplayInfo();

        Console.WriteLine("\nVerifying Original Hollow remains unchanged:");
        originalHollow.DisplayInfo();

        Console.WriteLine("\n");
    }
}

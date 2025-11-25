namespace FlyWeight;
class Program
{
    static void Main(string[] args)
    {
        const int particleCount = 1_000_000;

        Console.WriteLine($"Particle count: {particleCount}");

        // === UNOPTIMIZED ===
        GC.Collect();
        long beforeUnopt = GC.GetTotalMemory(true);

        var unopt = new UnoptimizedParticles();
        unopt.Create(particleCount);

        long afterUnopt = GC.GetTotalMemory(true);

        Console.WriteLine($"\nUNOPTIMIZED memory used: {(afterUnopt - beforeUnopt) / 1024.0 / 1024.0:F2} MB");

        // Clear
        unopt = null;
        GC.Collect();

        // === FLYWEIGHT ===
        GC.Collect();
        long beforeOpt = GC.GetTotalMemory(true);

        var opt = new FlyweightParticles();
        opt.Create(particleCount);

        long afterOpt = GC.GetTotalMemory(true);

        Console.WriteLine($"FLYWEIGHT memory used: {(afterOpt - beforeOpt) / 1024.0 / 1024.0:F2} MB");

        Console.WriteLine("\nDone.");
    }
}

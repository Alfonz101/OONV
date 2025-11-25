namespace FlyWeight;

public class ParticleTypeFlyweight
{
    public byte[] SharedTexture;

    public ParticleTypeFlyweight(int size)
    {
        SharedTexture = new byte[size];
    }
}

public class FlyweightParticle
{
    public float X, Y;
    public ParticleTypeFlyweight Type; // shared

    public FlyweightParticle(float x, float y, ParticleTypeFlyweight type)
    {
        X = x;
        Y = y;
        Type = type;
    }
}

public class FlyweightParticles
{
    public List<FlyweightParticle> Particles = new();

    public void Create(int count)
    {
        var rnd = new Random(42);

        var sharedType = new ParticleTypeFlyweight(256); // one shared texture

        for (int i = 0; i < count; i++)
        {
            float x = (float)rnd.NextDouble();
            float y = (float)rnd.NextDouble();

            Particles.Add(new FlyweightParticle(x, y, sharedType));
        }
    }
}

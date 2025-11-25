namespace FlyWeight;

public class UnoptimizedParticle
{
    public float X, Y;
    public byte[] Texture; // heavy intrinsic data

    public UnoptimizedParticle(float x, float y, byte[] texture)
    {
        X = x;
        Y = y;
        Texture = texture;
    }
}

public class UnoptimizedParticles
{
    public List<UnoptimizedParticle> Particles = new();

    public void Create(int count)
    {
        var rnd = new Random(42);

        for (int i = 0; i < count; i++)
        {
            float x = (float)rnd.NextDouble();
            float y = (float)rnd.NextDouble();

            // 256B texture per particle
            var tex = new byte[256];

            Particles.Add(new UnoptimizedParticle(x, y, tex));
        }
    }
}

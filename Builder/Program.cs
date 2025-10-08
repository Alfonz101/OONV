namespace Builder;

// Very dumbed down clone of the Dark Souls character creator
public interface ICharacterBuilder
{
    void SetName(string name);
    void SetClass(ClassType classType);
    void SetGift(GiftType gift);
    void SetAppearance(BodyType bodyType, int height);
    void SetStat(StatType stat, int value);
    void SetEquipment(WeaponType weapon, ShieldType shield, ArmorSetType armor, SpellType? spell);
    void Validate();
    void Build();
}

public class SoulsCharacterBuilder : ICharacterBuilder
{
    private Product _product = new Product();

    public ConcreteBuilder()
    {
        this.Reset();
    }

    public void Reset()
    {
        this._product = new Product();
    }

    public Product GetProduct()
    {
        Product result = this._product;
        this.Reset();
        return result;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

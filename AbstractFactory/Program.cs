namespace AbstractFactory;

public interface IGUIFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

public class WindowsStyleFactory : IGUIFactory
{
    public IButton CreateButton()
    {
        Console.WriteLine("Creating Windows Button");
        return new WinButton();
    }

    public ICheckbox CreateCheckbox()
    {
        Console.WriteLine("Creating Windows Checkbox");
        return new WinCheckbox();
    }
}

public class MacStyleFactory : IGUIFactory
{
    public IButton CreateButton()
    {
        Console.WriteLine("Creating Mac Button");
        return new MacButton();
    }

    public ICheckbox CreateCheckbox()
    {
        Console.WriteLine("Creating Mac Checkbox");
        return new MacCheckbox();
    }
}

public interface IButton
{
    void RenderButton();
}

public class WinButton : IButton
{
    public void RenderButton()
    {
        Console.WriteLine("Rendered Windows Style Button");
    }
}

public class MacButton : IButton
{
    public void RenderButton()
    {
        Console.WriteLine("Rendered Mac Style Button");
    }
}

public interface ICheckbox
{
    void RenderCheckbox();
}

public class WinCheckbox : ICheckbox
{
    public void RenderCheckbox()
    {
        Console.WriteLine("Rendered Windows Style Checkbox");
    }
}

public class MacCheckbox : ICheckbox
{
    public void RenderCheckbox()
    {
        Console.WriteLine("Rendered Mac Style Checkbox");
    }
}



class Program
{
    static void RenderUI(IGUIFactory factory)
    {
    var button = factory.CreateButton();
    button.RenderButton();

    var checkbox = factory.CreateCheckbox();
    checkbox.RenderCheckbox();

    }
    static void Main(string[] args)
    {
    Console.WriteLine("\n----->Abstract Factory Pattern Demo<-----\n");
    IGUIFactory factory;

    factory = new WindowsStyleFactory();
    RenderUI(factory);

    Console.WriteLine("\n");

    factory = new MacStyleFactory();
    RenderUI(factory);

    Console.WriteLine("\n");
    }
    
}

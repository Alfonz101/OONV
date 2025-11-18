namespace Decorator;

// The `IComponent` interface defines the operation that can be
// dynamically extended by decorators. In the UI example this is
// a simple `Execute` method representing rendering or performing
// component-specific work.
public interface IComponent
{
    void Execute();
}

// A concrete component that implements `IComponent`. This class
// represents a basic UI element (a button) that can be decorated
// with additional visual behaviors at runtime.
public class UIButton : IComponent
{
    public void Execute()
    {
        // Simulate the component's core behavior.
        Console.WriteLine("Executing ConcreteComponent: adding a button to the UI.");
    }
}

// The base decorator implements the same interface as components
// and holds a reference to an `IComponent`. It forwards requests
// to the wrapped component. Subclasses add behavior before or
// after delegating to the wrapped component.
public abstract class ComponentDecorator : IComponent
{
    protected IComponent _component;

    public ComponentDecorator(IComponent component)
    {
        _component = component;
    }

    // Default forwarding behavior; decorators can override this
    // method to add extra responsibilities.
    public virtual void Execute()
    {
        _component.Execute();
    }
}

// Adds a border to the wrapped component. This decorator overrides
// `Execute` to perform the original behavior and then the extra step.
public class BorderDecorator : ComponentDecorator
{
    public BorderDecorator(IComponent component) : base(component) { }

    public override void Execute()
    {
        // First do the wrapped component's work
        base.Execute();
        // Then add the decorator-specific behavior
        AddBorder();
    }

    private void AddBorder()
    {
        Console.WriteLine("Exectuting Concrete Decorator: Adding a border to the component.");           
    }
}

// Adds a drop shadow to the wrapped component.
public class ShadowDecorator : ComponentDecorator
{
    public ShadowDecorator(IComponent component) : base(component) { }

    public override void Execute()
    {
        base.Execute();
        AddShadow();
    }

    private void AddShadow()
    {
        Console.WriteLine("Exectuting Concrete Decorator: Adding a shadow to the component.");
    }
}

// Changes the background color of the wrapped component. This
// decorator accepts extra constructor state (`color`) that it uses
// when executing its additional behavior.
public class BackgroundColorDecorator : ComponentDecorator
{
    private string _color;

    public BackgroundColorDecorator(IComponent component, string color) : base(component)
    {
        _color = color;
    }

    public override void Execute()
    {
        base.Execute();
        ChangeBackgroundColor();
    }

    private void ChangeBackgroundColor()
    {
        Console.WriteLine($"Exectuting Concrete Decorator: Changing background color to {_color}.");
    }
}


// Small demonstration program that composes decorators around a
// `UIButton` instance and executes the resulting decorated object.
class Program
{
    static void Main(string[] args)
    {
        // Create the core component
        IComponent button = new UIButton();
        IComponent button2 = new UIButton();

        // Wrap the component with multiple decorators. Order matters:
        // the inner decorator's Execute runs first, then outward.
        IComponent decoratedButton = new BorderDecorator(new ShadowDecorator(new BackgroundColorDecorator(button, "blue")));
        IComponent decoratedButton2 = new BackgroundColorDecorator(new ShadowDecorator(button2), "red");

        // Execute the fully-decorated component. Output shows the
        // core action followed by each decorator's behavior.
        decoratedButton.Execute();
        Console.WriteLine("-------------------2nd button test---------------------");
        decoratedButton2.Execute();
    }
}

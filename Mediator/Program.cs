namespace Mediator;

public interface IMediator
{
    void Send(string message, Colleague colleague);
}

public abstract class Colleague
{
    protected IMediator mediator;

    public Colleague(IMediator mediator)
    {
        this.mediator = mediator;
    }
}

public class TextBox : Colleague
{
    private string text;

    public TextBox(IMediator mediator) : base(mediator) { }

    public string Text
    {
        get { return text; }
        set
        {
            text = value;
            mediator.Send(text, this);
        }
    }
}

public class Checkbox : Colleague
{
    private bool isChecked;

    public Checkbox(IMediator mediator) : base(mediator) { }

    public bool IsChecked
    {
        get { return isChecked; }
        set
        {
            isChecked = value;
            mediator.Send(isChecked.ToString(), this);
        }
    }
}

public class Button : Colleague
{
    public Button(IMediator mediator) : base(mediator) { }

    public void Click()
    {
        mediator.Send("Button clicked", this);
    }
}

public class ConcreteMediator : IMediator
{
    private TextBox textBox;
    private Checkbox checkbox;
    private Button button;

    public void SetColleagues(TextBox textBox, Checkbox checkbox, Button button)
    {
        this.textBox = textBox;
        this.checkbox = checkbox;
        this.button = button;
    }

    public void Send(string message, Colleague colleague)
    {
        if (colleague == textBox)
        {
            Console.WriteLine($"TextBox changed: {message}");
        }
        else if (colleague == checkbox)
        {
            Console.WriteLine($"Checkbox changed: {message}");
        }
        else if (colleague == button)
        {
            Console.WriteLine($"Button action: {message}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ConcreteMediator mediator = new ConcreteMediator();

        TextBox textBox = new TextBox(mediator);
        Checkbox checkbox = new Checkbox(mediator);
        Button button = new Button(mediator);

        mediator.SetColleagues(textBox, checkbox, button);

        textBox.Text = "Hello, World!";
        checkbox.IsChecked = true;
        button.Click();
    }
}

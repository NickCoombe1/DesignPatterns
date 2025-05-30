public interface IMediator
{
    void Notify(object sender, string ev);
}

public class ConcreteMediator : IMediator
{
    private ButtonComponent Button { get; set; }
    private TextBoxComponent TextBox { get; set; }

    public ConcreteMediator(ButtonComponent buttonComponent, TextBoxComponent textBoxComponent)
    {
        Button = buttonComponent;
        Button.SetMediator(this);
        TextBox = textBoxComponent;
        TextBox.SetMediator(this);
    }
    public void Notify(object sender, string ev)
    {

        switch (ev)
        {
            case "Button":
                Console.WriteLine("Mediator reacts on A and triggers following operations:");
                Button.DoA();
                break;
            case "TextBox":
                Console.WriteLine("TextBox reacts on B and triggers following operations:");
                TextBox.DoA();
                break;
        }
    }
}

public class BaseComponent(IMediator? mediator = null)
{
    protected IMediator? Mediator = mediator;

    public void SetMediator(IMediator? mediator)
    {
        Mediator = mediator;
    }
}

public class ButtonComponent : BaseComponent
{
    public void DoA()
    {
        Console.WriteLine("Button does something");
        Mediator?.Notify(this, "TextBox");
    }
}

public class TextBoxComponent : BaseComponent
{
    public void DoA()
    {
        Console.WriteLine("TextBox doing something!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var button = new ButtonComponent();
        var textBox = new TextBoxComponent();
        var mediator = new ConcreteMediator(button, textBox);
        
        button.DoA();
    }
}
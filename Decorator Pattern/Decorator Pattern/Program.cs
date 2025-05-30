class Progam
{
    static void Main(string[] args)
    {
        ISandwich sandwich = new BLT();
        Console.WriteLine($"Bread: {sandwich.Bread}, Filling: {sandwich.Filling}");

        sandwich = new CheeseDecorator(sandwich);
        Console.WriteLine($"Bread: {sandwich.Bread}, Filling: {sandwich.Filling}");
    }
}

//Base interface
public interface ISandwich
{
    public string Bread { get; }
    public string Filling { get; }
}

//Concerete implementation
public class BLT : ISandwich
{
    public string Bread => "White";
    public string Filling => "Bacon, Lettuce, Tomato";
}

//Decorator base class
public class SandwichDecorator : ISandwich
{
    private readonly ISandwich _sandwich;

    public SandwichDecorator(ISandwich sandwich)
    {
        _sandwich = sandwich;
    }

    public virtual string Bread => _sandwich.Bread;
    public virtual string Filling => _sandwich.Filling;
}

//Concrete decorator
public class CheeseDecorator : SandwichDecorator
{
    public CheeseDecorator(ISandwich sandwich) : base(sandwich) { }

    public override string Filling => $"{base.Filling}, Cheese";
}


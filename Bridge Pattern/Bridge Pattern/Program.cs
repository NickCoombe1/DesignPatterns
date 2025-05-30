Shape redCircle = new Circle(new RedColor());
redCircle.Draw();

Shape blueSquare = new Square(new BlueColor());
blueSquare.Draw(); 

public interface IColor
{
    string ApplyColor();
}


public class RedColor : IColor
{
    public string ApplyColor() => "Red";
}

public class BlueColor : IColor
{
    public string ApplyColor() => "Blue";
}


public abstract class Shape
{
    protected IColor color;

    protected Shape(IColor color)
    {
        this.color = color;
    }

    public abstract void Draw();
}

public class Circle : Shape
{
    public Circle(IColor color) : base(color) { }

    public override void Draw()
    {
        Console.WriteLine($"Drawing a {color.ApplyColor()} Circle");
    }
}

public class Square : Shape
{
    public Square(IColor color) : base(color) { }

    public override void Draw()
    {
        Console.WriteLine($"Drawing a {color.ApplyColor()} Square");
    }
}


public interface IButton
{
    void Render();
}

public class LightButton : IButton
{
    public void Render() => Console.WriteLine("Rendering a light-themed button.");
}

public class DarkButton : IButton
{
    public void Render() => Console.WriteLine("Rendering a dark-themed button.");
}

public interface IFactory
{
    IButton CreateButton();
}

public class LightButtonFactory : IFactory
{
    public IButton CreateButton() => new LightButton();
}

public class DarkButtonFactory : IFactory
{
    public IButton CreateButton() => new DarkButton();
}
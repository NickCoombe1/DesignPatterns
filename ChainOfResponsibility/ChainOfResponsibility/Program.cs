public interface IHandler
{
    void SetNextHandler(IHandler handler);
    void Handle();
}

public class FirstHandler : IHandler
{
    private IHandler _nextHandler;

    public void SetNextHandler(IHandler handler)
    {
        _nextHandler = handler;
    }

    public void Handle()
    {
        Console.WriteLine("Handling object successfully");
        _nextHandler?.Handle();
    }
}

public class SecondHandler : IHandler
{
    private IHandler _nextHandler;

    public void SetNextHandler(IHandler handler)
    {
        _nextHandler = handler;
    }

    public void Handle()
    {
        Console.WriteLine("Handling object successfully #2");
        _nextHandler?.Handle();
    }
}

public class ThirdHandler : IHandler
{
    private IHandler _nextHandler;

    public void SetNextHandler(IHandler handler)
    {
        _nextHandler = handler;
    }

    public void Handle()
    {
        Console.WriteLine("Handling object successfully #3");
        _nextHandler?.Handle();
    }
}

class Program
{
    static void Main(string[] args)
    {
        IHandler handler1 = new FirstHandler();
        IHandler handler2 = new SecondHandler();
        IHandler handler3 = new ThirdHandler();

        handler1.SetNextHandler(handler2);
        handler2.SetNextHandler(handler3);

        handler1.Handle();
    }
}
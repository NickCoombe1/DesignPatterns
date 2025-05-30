public interface IStrategy
{
    void Execute();
}

public class CarStrategy : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Getting to the airport by car.");
    }
}

public class BusStrategy : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Getting to the airport by bus.");
    }
}

public class TrainStrategy : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Getting to the airport by train.");
    }
}

public class Context
{
    private IStrategy _strategy;

    public Context(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void ExecuteStrategy()
    {
        _strategy.Execute();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Context context = new Context(new CarStrategy());
        context.ExecuteStrategy();

        context.SetStrategy(new BusStrategy());
        context.ExecuteStrategy();

        context.SetStrategy(new TrainStrategy());
        context.ExecuteStrategy();
    }
}
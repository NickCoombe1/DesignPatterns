class Program
{
    static void Main(string[] args)
    {
        EuropeanPlug euroPlug = new EuropeanPlug();
        IAmericanSocket adapter = new EuropeanToAmericanAdapter(euroPlug);

        adapter.PlugIn();
    }
}

public interface IAmericanSocket
{
    void PlugIn();
}

public class EuropeanPlug
{
    public void ConnectWithRoundPins()
    {
        Console.WriteLine("Connected using European round pins.");
    }
}

public class EuropeanToAmericanAdapter : IAmericanSocket
{
    private readonly EuropeanPlug _europeanPlug;

    public EuropeanToAmericanAdapter(EuropeanPlug europeanPlug)
    {
        _europeanPlug = europeanPlug;
    }

    public void PlugIn()
    {
        Console.WriteLine("Adapting round pins to flat pins...");
        _europeanPlug.ConnectWithRoundPins();
    }
}

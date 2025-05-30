namespace SingletonPattern;

public sealed class SingletonPattern
{
    //static constructor means the instance is initialized only once === thread safe
    static SingletonPattern()
    {
    }

    private SingletonPattern()
    {
    }
    
    //only initialized when first accessed 
    public static SingletonPattern Instance { get; } = new SingletonPattern();
}
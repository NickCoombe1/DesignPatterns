public interface IPayment
{
    void Pay();
}

//This is our service that we want to hide behind a proxy
public class Payment : IPayment
{
    public void Pay()
    {
        Console.WriteLine("Paying");
    }
}

//Proxy with a shared interface to our ProxiedService e.g. Payment
public class ProxyMethod(Payment paymentService) : IPayment
{
    private readonly Payment _paymentService = paymentService;

    public void Pay()
    {
        LogAccess();
        _paymentService.Pay();
    }

    private void LogAccess()
    {
        Console.WriteLine("Accessing Payment Service");
    }
}

class Program
{
    static void Main(string[] args)
    {
        IPayment paymentProxy = new ProxyMethod(new Payment());
        paymentProxy.Pay();
    }
}
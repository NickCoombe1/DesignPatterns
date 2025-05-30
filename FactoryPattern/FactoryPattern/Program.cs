class Program
{
    static void Main()
    {
        Console.Write("Enter notification type (Email or SMS): ");
        string type = Console.ReadLine();

        INotification notification = NotificationFactory.GetNotification(type);
        notification.Send("Hello! This is a factory pattern example.");
    }
}
public class NotificationFactory
{
    public static INotification GetNotification(string type)
    {
        switch (type)
        {
            case "Email":
                return new EmailNotification();
            case "SMS":
                return new SMSNotification();
            default:
                throw new NotSupportedException();
        }
    }
}

public interface INotification
{
    void Send(string message);
}

public class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Email Notification: {message}");
    }
}

public class SMSNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"SMS Notification: {message}");
    }
}

public class TwilioNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"SMS Notification: {message}");
    }
}
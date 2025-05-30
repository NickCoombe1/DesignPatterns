class  Program
{
    static void Main(string[] args)
    {
        var car = new Car();
    
        Console.WriteLine($"State: {car.CurrentState}");
    
        car.TakeAction(Car.Action.Start);
        Console.WriteLine($"State: {car.CurrentState}");
    
        car.TakeAction(Car.Action.Accelerate);
        Console.WriteLine($"State: {car.CurrentState}");
    
        car.TakeAction(Car.Action.Stop);
        Console.WriteLine($"State: {car.CurrentState}");
    }
}


public class Car
{
    public enum State
    {
        Stopped,
        Started,
        Running,
        Reversing
    }

    public enum Action
    {
        Stop,
        Start,
        Accelerate
    }
    
    private State _state = State.Stopped;
    
    //expose state in immutable way
    public State CurrentState
    {
        get { return _state; }
    }

    public void TakeAction(Action action)
    {
        _state = (_state, action) switch
        {
            (State.Stopped, Action.Start) => State.Started,
            (State.Started, Action.Stop) => State.Stopped,
            (State.Started, Action.Accelerate) => State.Running,
            (State.Running, Action.Stop) => State.Stopped,
            _ => _state
        };
    }
}


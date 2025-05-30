public class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public string Engine { get; set; }

    public override string ToString()
    {
        return $"{Make} {Model} with {Engine} engine";
    }
}

public interface ICarBuilder
{
    ICarBuilder SetMake(string make);
    ICarBuilder SetModel(string model);
    ICarBuilder SetEngine(string engine);
    Car Build();
}


public class CarBuilder : ICarBuilder
{
    private Car _car = new Car();

    public ICarBuilder SetMake(string make)
    {
        _car.Make = make;
        return this;
    }

    public ICarBuilder SetModel(string model)
    {
        _car.Model = model;
        return this;
    }

    public ICarBuilder SetEngine(string engine)
    {
        _car.Engine = engine;
        return this;
    }

    public Car Build()
    {
        return _car;
    }
}

//cleaner way of calling the builder
public class CarDirector
{
    public Car BuildSportsCar(ICarBuilder builder)
    {
        return builder
            .SetMake("Ferrari")
            .SetModel("488 GTB")
            .SetEngine("V8 Twin Turbo")
            .Build();
    }
}

class Program
{
    static void Main()
    {
        // Using the builder directly
        var carBuilder = new CarBuilder();
        Car customCar = carBuilder
            .SetMake("Tesla")
            .SetModel("Model S")
            .SetEngine("Electric")
            .Build();
    
        //then we could build more a lot more easily
        
        Car customCar2 = carBuilder
            .SetMake("Tesla")
            .SetModel("Model Y")
            .SetEngine("Electric")
            .Build();
        
        Console.WriteLine(customCar);
        Console.WriteLine(customCar2);
        
        // Using the director
        var director = new CarDirector();
        Car sportsCar = director.BuildSportsCar(new CarBuilder());
        Console.WriteLine(sportsCar);
    }
}

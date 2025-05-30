interface IExpression
{
    int Interpret();
}

class NumberExpression(int number) : IExpression
{
    public int Interpret() => number;
}

class AddExpression(IExpression valueA, IExpression valueB) : IExpression
{
    public int Interpret() => valueA.Interpret() + valueB.Interpret();
}

class SubtractExpression(IExpression valueA, IExpression valueB) : IExpression
{
    public int Interpret() => valueA.Interpret() - valueB.Interpret();
}

class Program
{
    static void Main(string[] args)
    {
        IExpression five = new NumberExpression(5);
        IExpression three = new NumberExpression(3);
        IExpression eight = new NumberExpression(8);
        
        IExpression addition = new AddExpression(five, three);
        
        IExpression subtraction = new SubtractExpression(addition, eight);
        
        Console.WriteLine(addition.Interpret());
        Console.WriteLine(subtraction.Interpret()); 
    }
}
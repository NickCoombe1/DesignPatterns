class Program
{
    static void Main(string[] args)
    {
        var elements = new List<IElement>
        {
            new PlainText("Hey Clive"),
            new Hyperlink("RefactoringGuru", "https://refactoring.guru/design-patterns/visitor")
        };

        var renderVisitor = new WriteVisitor();
        var spellCheckVisitor = new SpellCheckVisitor();

        Console.WriteLine("Rendering:");
        foreach (var element in elements)
        {
            element.Accept(renderVisitor);
        }

        Console.WriteLine("\nSpell-checking:");
        foreach (var element in elements)
        {
            element.Accept(spellCheckVisitor);
        }
    }
}


// Vistors know how to visit all elements
// This interface could get quite large 
public interface IVisitor
{
    void Visit(PlainText text);
    void Visit(Hyperlink link);
}

//All elements just know how to acceppt visitors 
public interface IElement
{
    void Accept(IVisitor visitor);
}

//Elements 
public class PlainText : IElement
{
    public string Text { get; }

    public PlainText(string text)
    {
        Text = text;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class Hyperlink : IElement
{
    public string Text { get; }
    public string Url { get; }

    public Hyperlink(string text, string url)
    {
        Text = text;
        Url = url;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class WriteVisitor : IVisitor
{
    public void Visit(PlainText text)
    {
        Console.WriteLine(text.Text);
    }

    public void Visit(Hyperlink link)
    {
        Console.WriteLine($"<a href='{link.Url}'>{link.Text}</a>");
    }
}

public class SpellCheckVisitor : IVisitor
{
    public void Visit(PlainText text)
    {
        Console.WriteLine($"Spell-checking plain text: {text.Text}");
    }

    public void Visit(Hyperlink link)
    {
        Console.WriteLine($"Spell-checking hyperlink text: {link.Text}");
    }
}


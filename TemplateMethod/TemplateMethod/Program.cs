class Program
{
    static void Main(string[] args)
    {
        var pdfMiner = new PDFMiner();
        pdfMiner.MineFile();
        
        var csvMiner = new CSVMiner();
        csvMiner.MineFile();
    }
}


public abstract class DataMiner
{
    public void MineFile()
    {
        Mine();
        OpenFile();
        AnalyzeFile();
        CloseFile();
    }
    protected abstract void Mine();

    protected abstract void OpenFile();
    
    protected abstract void AnalyzeFile();
    
    protected abstract void CloseFile();
}


public class PDFMiner : DataMiner
{
    protected override void Mine()
    {
        Console.WriteLine("Mining PDF");
    }

    protected override void OpenFile()
    {
        Console.WriteLine("Opening PDF");
    }

    protected override void AnalyzeFile()
    {
        Console.WriteLine("Analyzing PDF content");
    }

    protected override void CloseFile()
    {
        Console.WriteLine("Closing.....");
    }
}

public class CSVMiner : DataMiner
{
    protected override void Mine()
    {
        Console.WriteLine("Mining CSV");
    }

    protected override void OpenFile()
    {
        Console.WriteLine("Opening CSV and parsing lines");
    }

    protected override void AnalyzeFile()
    {
        Console.WriteLine("Analyzing CSV content");
    }

    protected override void CloseFile()
    {
        Console.WriteLine("Closing.....");
    }
}
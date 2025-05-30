class Program
{
    static void Main()
    {
        var position = new Position(1);
        var player = new Player(position);
        
        var snapshot = position.CreateSnapshot();
        
        Console.WriteLine("Player Position: " + position.Cell);
        
        // Move the player
        player.MovePlayer();
        Console.WriteLine("Player Position after move: " + position.Cell);
        
        player.Restore(snapshot);
        Console.WriteLine("Player Position after restore: " + position.Cell);
    }
}



//Originator
public class Position
{
    public int Cell { get; private set; } 
    
    public Position(int cell)
    {
        Cell = cell;
    }

    public void SetCell(int cell)
    {
        Cell = cell;
    }

    // Create a Memento
    public PositionMemento CreateSnapshot()
    {
        return new PositionMemento(Cell);
    }
}


public class PositionMemento
{
    public int Cell { get; }

    public PositionMemento(int cell)
    {
        Cell = cell;
    }
}

// Caretaker & Player
public class Player
{
    private Position Position { get; set; }

    public Player(Position position)
    {
        Position = position;
    }

    public void MovePlayer()
    {
        Position.SetCell(Position.Cell + 1);
    }

    // Restore from Memento
    public void Restore(PositionMemento memento)
    {
        Position.SetCell(memento.Cell);
    }
}
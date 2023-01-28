namespace Gusanita.Console;

using System;
using System.Collections;

public interface Controller
{
    public void Handle(ClassicGame.Player player);
}


public class DummyController : Controller
{
    public void Handle(ClassicGame.Player player)
    {
    }
}

public class KeyboardController : Controller
{
    public void Handle(ClassicGame.Player player)
    {
        // https://stackoverflow.com/questions/5620603/non-blocking-read-from-standard-i-o-in-c-sharp
        if (Console.KeyAvailable)  
        {  
            ConsoleKeyInfo key = Console.ReadKey(true);  
            switch (key.Key)  
            {  
                case ConsoleKey.UpArrow:  
                    player.ToNorth();
                    break;
                case ConsoleKey.LeftArrow:
                    player.ToWest();
                    break;
                case ConsoleKey.RightArrow:
                    player.ToEast();
                    break;
                case ConsoleKey.DownArrow:
                    player.ToSouth();
                    break;
                default:  
                break;  
            }  
        }
    }
}

public class RobotController : Controller
{
    private Queue _movements;

    public RobotController()
    {
        _movements = new Queue();
    }
    
    public void NextToSouth()
    {
        _movements.Enqueue("south");
    }

    public void NextToNorth()
    {
        _movements.Enqueue("north");
    }

    public void NextToWest()
    {
        _movements.Enqueue("West");
    }

    public void NextToEast()
    {
        _movements.Enqueue("East");
    }

    public void Handle(ClassicGame.Player player)
    {
        if(_movements.Count <= 0)
            return;
        
        switch(_movements.Dequeue())
        {
            case "north":
                player.ToNorth();
                break;
            case "south":
                player.ToSouth();
                break;
            case "east":
                player.ToEast();
                break;
            case "west":
                player.ToWest();
                break;
        }
    }
}

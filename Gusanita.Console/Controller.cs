namespace Gusanita.Console;

using System;

public interface Controller
{
    public void Handle(ClassicGame.Player player);
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

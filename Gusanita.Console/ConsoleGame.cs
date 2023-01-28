namespace Gusanita.Console;

using System;

public class ConsoleGame : ClassicGame.GusanitaBehavior
{
    private Screener _screen;
    private int _width;
    private int _height;
    private List<Fruit> _fruits;
    private ClassicGame.Player _player;
    private Gusanita _gusanita;
    private ClassicGame.Game _game;
    
    public ConsoleGame(Screener screen, int width = 0, int height = 0)
    {
        _screen = screen;
        _width = width;
        _height = height;
        _player = new ClassicGame.Player(x: 0, y: 0);
        _gusanita = new Gusanita(_player);
        _game = new ClassicGame.Game(_player, width: width, height: height, behavior: this);
        _fruits = new List<Fruit>();
        
        _player.ToEast();
    }

    public void Iterate()
    {
        HandleKeyboard();
        _game.Process();
    }
    
    public void AddBanana(int x, int y)
    {
        var fruit = new Fruit(x: x, y: y);
        _game.Plant(fruit);
        _fruits.Add(fruit);
    }

    public void GusanitaHasAte(ClassicGame.Player player, ClassicGame.Fruitable fruit)
    {
        _fruits.Remove((Fruit)fruit);
    }
    
    public void Render()
    {
        _screen.RenderBackground(_width, _height);

        foreach(var fruit in _fruits)
            fruit.Render(_screen);
        
        _gusanita.Render(_screen);

        _screen.Refresh();
    }

    private void HandleKeyboard()
    {
        // https://stackoverflow.com/questions/5620603/non-blocking-read-from-standard-i-o-in-c-sharp
        if (Console.KeyAvailable)  
        {  
            ConsoleKeyInfo key = Console.ReadKey(true);  
            switch (key.Key)  
            {  
                case ConsoleKey.UpArrow:  
                    _player.ToNorth();
                    break;
                case ConsoleKey.LeftArrow:
                    _player.ToWest();
                    break;
                case ConsoleKey.RightArrow:
                    _player.ToEast();
                    break;
                case ConsoleKey.DownArrow:
                    _player.ToSouth();
                    break;
                default:  
                break;  
            }  
        }
    }
}

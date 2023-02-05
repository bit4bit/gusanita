namespace Gusanita.Console;

using System;

public class ConsoleGame : ClassicGame.GusanitaBehavior, ClassicGame.FruitFactorier
{
    private Screener _screen;
    private int _width;
    private int _height;
    private List<Fruit> _fruits;
    private ClassicGame.Player _player;
    private Gusanita _gusanita;
    private ClassicGame.Game _game;
    private Controller _controller;
    
    public ConsoleGame(Screener screen, Controller? controller = null, int width = 0, int height = 0, int fruits = 0)
    {
        _screen = screen;
        _width = width;
        _height = height;
        _player = new ClassicGame.Player(x: 0, y: 0);
        _gusanita = new Gusanita(_player);
        _fruits = new List<Fruit>();
        
        _player.ToEast();

        if (controller == null)
            _controller = new DummyController();
        else
            _controller = controller;

        _game = ClassicGame.GameRandomBuilder.initialize()
            .width(width)
            .height(height)
            .fruits(fruits)
            .game(_player, fruitFactory: this, behavior: this);
    }

    public ClassicGame.Fruitable Seed(ClassicGame.Game game, int x, int y)
    {
        var fruit = new Fruit(x: x, y: y);
        
        game.Plant(fruit);
        _fruits.Add(fruit);

        return fruit;
    }

    public void AddBanana(int x, int y)
    {
        Seed(_game, x, y);
    }


    public bool Iterate()
    {
        _controller.Handle(_player);
        _game.Process();
        if (_game.IsFinished)
            return false;
        return true;
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
}

namespace Gusanita.ClassicGame;

public class GameRandomBuilder
{
    int _width = 0;
    int _height = 0;
    int _fruits = 0;
    Random _rnd = new Random();

    public static GameRandomBuilder initialize()
    {
        return new GameRandomBuilder();
    }
    
    public GameRandomBuilder width(int val)
    {
        _width = val;
        return this;
    }

    public GameRandomBuilder height(int val)
    {
        _height = val;
        return this;
    }

    public GameRandomBuilder fruits(int val)
    {
        _fruits = val;
        return this;
    }

    public Game game(Player player, GusanitaBehavior? behavior = null)
    {
        var game = new Game(player, Wall.of(width: _width,
                                            height: _height),
                            behavior: behavior);
        for(int i = 0; i <  _fruits; i++)
        {
            int x = _rnd.Next(1, _width);
            int y = _rnd.Next(1, _height);

            // frutas
            var fruits = new List<Fruitable>{
                new Fruit(x: x, y: y, earn: 1),
                new Fruit(x: x, y: y, earn: 3)
            };
            
            game.Plant(fruits[_rnd.Next(fruits.Count)]);
        }

        return game;
    }
}

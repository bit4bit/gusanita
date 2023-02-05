namespace Gusanita.ClassicGame;

public interface FruitFactorier
{
    public Fruitable Seed(Game game, int x, int y);
}

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

    public Game game(Player player, FruitFactorier fruitFactory, GusanitaBehavior? behavior = null)
    {
        var game = new Game(player, Wall.of(width: _width,
                                            height: _height),
                            behavior: behavior);
        for(int i = 0; i <  _fruits; i++)
        {
            int x = _rnd.Next(1, _width);
            int y = _rnd.Next(1, _height);

            if (fruitFactory != null)
                game.Plant(fruitFactory.Seed(game, x, y));
        }

        return game;
    }
}

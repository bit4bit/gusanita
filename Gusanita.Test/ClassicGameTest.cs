namespace Gusanita.Test;

using Gusanita.ClassicGame;

public class ClassicGameTest
{

    [Test]
    public void player_earn_points_when_eat_a_fruit()
    {
        var player = aPlayer();
        var game = aGameOf5x5(player);
        game.Plant(aFruit(x: 1, y: 0, earn: 1));

        player.ToEast();
        game.Process();
        
        Assert.That(game.Points, Is.EqualTo(1));
    }

    [Test]
    public void player_dead_if_eat_it_self()
    {
        var player = aPlayer();
        var game = new Game(player, Wall.of(10, 10));
        game.Plant(aFruit(x: 1, y: 0));
        game.Plant(aFruit(x: 2, y: 0));
        game.Plant(aFruit(x: 3, y: 0));
        game.Plant(aFruit(x: 4, y: 0));
        game.Plant(aFruit(x: 5, y: 0));

        player.ToEast();
        game.Process();
        game.Process();
        game.Process();
        game.Process();
        game.Process();
        player.ToSouth();
        game.Process();
        player.ToWest();
        game.Process();
        player.ToNorth();
        game.Process();

        Assert.That(game.IsFinished, Is.EqualTo(true));
    }

    [Test]
    public void player_dead_if_move_out_of_game()
    {
        var player = aPlayer();
        var game = aGameOf5x5(player);

        player.ToWest();
        game.Process();
        
        Assert.That(game.IsFinished, Is.EqualTo(true));
    }
    
    class RandomFruitFactory : FruitFactorier
    {
        public Fruitable Seed(Game game, int x, int y)
        {
            return new Fruit(x: x, y: y, earn: 1);
        }
    }
    
    [Test]
    public void build_a_random_game()
    {
        var player = aPlayer();
        var fruitFactory = new RandomFruitFactory();
        var game = GameRandomBuilder.initialize()
            .width(10)
            .height(5)
            .fruits(5)
            .game(player, fruitFactory);

        Assert.That(game.Width, Is.EqualTo(10));
        Assert.That(game.Height, Is.EqualTo(5));
        Assert.That(game.CountFruits, Is.EqualTo(5));
    }
    
    private Game aGameOf5x5(Player player)
    {
        return new Game(player, Wall.of5x5());
    }

    private Player aPlayer(int x = 0, int y = 0)
    {
        return new Player(x: x, y: y);
    }
    
    private Fruitable aFruit(int x, int y, int earn = 3)
    {
        return new Fruit(x: x, y: y, earn: earn);
    }
}

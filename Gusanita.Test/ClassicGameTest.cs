namespace Gusanita.Test;

using Gusanita.ClassicGame;

public class ClassicGameTest
{

    [Test]
    public void player_earn_1_point_when_eat_a_banana()
    {
        var player = aPlayer();
        var game = aGameOf5x5(player);
        game.Plant(new BananaFruit(x: 1, y: 0));

        player.ToEast();
        game.Process();
        
        Assert.That(game.Points, Is.EqualTo(1));
    }

    [Test]
    public void player_earn_3_point_when_eat_a_banana()
    {
        var player = aPlayer();
        var game = aGameOf5x5(player);
        game.Plant(new PapayaFruit(x: 1, y: 0));

        player.ToEast();
        game.Process();
        
        Assert.That(game.Points, Is.EqualTo(3));
    }

    [Test]
    public void player_dead_if_eat_it_self()
    {
        var player = aPlayer();
        var game = new Game(player, Wall.of(10, 10));
        game.Plant(aPapaya(x: 1, y: 0));
        game.Plant(aPapaya(x: 2, y: 0));
        game.Plant(aPapaya(x: 3, y: 0));
        game.Plant(aPapaya(x: 4, y: 0));
        game.Plant(aPapaya(x: 5, y: 0));

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

    private Game aGameOf5x5(Player player)
    {
        return new Game(player, Wall.of5x5());
    }

    private Player aPlayer(int x = 0, int y = 0)
    {
        return new Player(x: x, y: y);
    }
    
    private Fruitable aPapaya(int x, int y)
    {
        return new PapayaFruit(x: x, y: y);
    }
}

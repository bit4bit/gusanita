namespace Gusanita.Test;

using Gusanita.ClassicGame;

public class ClassicGameTest
{

    [Test]
    public void player_earn_1_point_when_eat_a_banana()
    {
        var player = new Player(x: 0, y: 0);
        var game = new Game(player, width: 5, height: 5);
        game.Plant(new BananaFruit(x: 1, y: 0));

        player.ToEast();
        game.Process();
        
        Assert.That(game.Points, Is.EqualTo(1));
    }

    [Test]
    public void player_earn_3_point_when_eat_a_banana()
    {
        var player = new Player(x: 0, y: 0);
        var game = new Game(player, width: 5, height: 5);
        game.Plant(new PapayaFruit(x: 1, y: 0));

        player.ToEast();
        game.Process();
        
        Assert.That(game.Points, Is.EqualTo(3));
    }

    [Test]
    public void player_dead_if_eat_it_self()
    {
        var player = new Player(x: 0, y: 0);
        var game = new Game(player);
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
        player.ToWest();
        player.ToNorth();
        
        Assert.That(game.IsFinished, Is.EqualTo(true));
    }

    [Test]
    public void player_dead_if_move_out_of_game()
    {
        var player = new Player(x: 0, y: 0);
        var game = new Game(player);

        player.ToWest();
        game.Process();
        
        Assert.That(game.IsFinished, Is.EqualTo(true));
    }

    private Fruitable aPapaya(int x, int y)
    {
        return new PapayaFruit(x: x, y: y);
    }
}

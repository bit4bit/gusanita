namespace Gusanita.Test;

using Gusanita.ClassicGame;

public class ClassicGameTest
{

    [Test]
    public void player_earn_1_point_when_eat_a_banana()
    {
        var player = new Player(x: 0, y: 0, to: Core.Direction.EAST);
        var game = new Game(player);
        game.Plant(new BananaFruit(x: 1, y: 0));

        game.Process();
        
        Assert.That(game.Points, Is.EqualTo(1));
    }

    [Test]
    public void player_earn_3_point_when_eat_a_banana()
    {
        var player = new Player(x: 0, y: 0, to: Core.Direction.EAST);
        var game = new Game(player);
        game.Plant(new PapayaFruit(x: 1, y: 0));

        game.Process();
        
        Assert.That(game.Points, Is.EqualTo(3));
    }
}

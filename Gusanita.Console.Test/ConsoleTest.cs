namespace Gusanita.Console.Test;

public class ConsoleTest
{

    [Test]
    public void render_an_empty_game()
    {
        var r = new TextScreen();
        var c = new ConsoleGame(screen: r);

        Assert.That(r.Text, Is.EqualTo(""));
    }


    [Test]
    public void render_a_game_with_gusanita()
    {
        var r = new TextScreen(width: 5, height: 5);
        var c = new ConsoleGame(screen: r,
                                width: 5,
                                height: 5);
        
        c.Render();

        Assert.That(r.Text, Is.EqualTo(
                        "o...."+
                        "....."+
                        "....."+
                        "....."+
                        "....."
                    ));
    }

    [Test]
    public void render_a_game_with_gusanita_move_to_steps()
    {
        var r = new TextScreen(width: 5, height: 5);
        var c = new ConsoleGame(screen: r,
                                width: 5,
                                height: 5);

        c.Iterate();
        c.Iterate();
        c.Render();

        Assert.That(r.Text, Is.EqualTo(
                        "..o.."+
                        "....."+
                        "....."+
                        "....."+
                        "....."
                    ));
    }

    [Test]
    public void render_a_game_with_a_banana()
    {
        var r = new TextScreen(width: 5, height: 5);
        var c = new ConsoleGame(screen: r,
                                width: 5,
                                height: 5);
        c.AddBanana(y: 1, x: 2);
            
        c.Render();

        Assert.That(r.Text, Is.EqualTo(
                        "o...."+
                        "../.."+
                        "....."+
                        "....."+
                        "....."
                    ));
    }

    [Test]
    public void gusanita_grows_when_eat_fruit()
    {
        var r = new TextScreen(width: 5, height: 5);
        var c = new ConsoleGame(screen: r,
                                width: 5,
                                height: 5);
        c.AddBanana(y: 0, x: 1);
        c.AddBanana(y: 0, x: 2);
        
        c.Iterate();
        c.Iterate();
        c.Iterate();
        c.Iterate();
        c.Render();

        Assert.That(r.Text, Is.EqualTo(
                        "..ooo"+
                        "....."+
                        "....."+
                        "....."+
                        "....."
                    ));
    }

    [Test]
    public void bug_gusanita_must_move_complete_when_change_direction()
    {
        var r = new TextScreen(width: 5, height: 5);
        var m = new RobotController();
        var c = new ConsoleGame(screen: r,
                                controller: m,
                                width: 5,
                                height: 5);
        c.AddBanana(y: 0, x: 1);
        c.AddBanana(y: 0, x: 2);
        
        c.Iterate();
        c.Iterate();
        c.Iterate();
        c.Iterate();
        m.NextToSouth();
        c.Iterate();
        c.Iterate();
        c.Render();

        Assert.That(r.Text, Is.EqualTo(
                        "....o"+
                        "....o"+
                        "....o"+
                        "....."+
                        "....."
                    ));
    }
}

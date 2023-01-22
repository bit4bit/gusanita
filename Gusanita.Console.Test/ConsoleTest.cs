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
    public void render_an_fixed_game()
    {
        // TODO: width, height codigo duplicado
        var r = new TextScreen(width: 5, height: 5);
        var c = new ConsoleGame(screen: r,
                                width: 5,
                                height: 5);

        c.Render();
        
        Assert.That(r.Text, Is.EqualTo(
                        "....."+
                        "....."+
                        "....."+
                        "....."+
                        "....."
                    ));
    }

    [Test]
    public void render_a_game_with_gusanita()
    {
        var r = new TextScreen(width: 5, height: 5);
        var c = new ConsoleGame(screen: r,
                                width: 5,
                                height: 5);
        c.AddGusanita(x: 0, y: 0);
        
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
    public void render_a_game_with_a_banana()
    {
        var r = new TextScreen(width: 5, height: 5);
        var c = new ConsoleGame(screen: r,
                                width: 5,
                                height: 5);
        c.AddBanana(y: 1, x: 2);
            
        c.Render();

        Assert.That(r.Text, Is.EqualTo(
                        "....."+
                        "../.."+
                        "....."+
                        "....."+
                        "....."
                    ));
    }
}

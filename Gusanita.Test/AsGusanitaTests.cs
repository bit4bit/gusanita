namespace Gusanita.Test;

using Gusanita;

public class AsGusanitaTests
{

    [Test]
    public void i_can_not_eat_myself()
    {
        var g = new Core.Gusanita();

        Assert.Throws<Core.CouldNotEatItSelf>(() => {
            g.eat(g);
        });
    }

    [Test]
    public void my_body_stretchs_after_eat()
    {
        var g = new Core.Gusanita();

        g.eat(aBanana());
        
        Assert.That(g.Body.Length, Is.EqualTo(1));
    }

    [Test]
    public void i_can_not_eat_my_body()
    {
        var g = new Core.Gusanita();
        
        Assert.Throws<Core.CouldNotEatItSelf>(() => {
            g.eat(g.Body);
        });
    }

    [Test]
    public void i_can_not_eat_a_part_of_my_body()
    {
        var g = new Core.Gusanita();
        
        g.eat(aBanana());
        
        Assert.Throws<Core.CouldNotEatItSelf>(() => {
            var part = g.Body.Parts.Last();
            g.eat(part);
        });
    }

    private Core.Fruit aBanana()
    {
        return new Core.Banana();
    }
}

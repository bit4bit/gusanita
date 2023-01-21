namespace Gusanita.Test;

using Gusanita;

public class AsGusanitaTests
{

    [Test]
    public void i_can_not_eat_myself()
    {
        var g = new Core.Gusanita();

        Assert.Throws<Core.CouldNotEatMySelf>(() =>
        {
            g.Eat(g);
        });
    }

    [Test]
    public void my_body_stretchs_after_eat()
    {
        var g = new Core.Gusanita();

        g.Eat(aBanana());

        Assert.That(g.Body.Length, Is.EqualTo(1));
    }

    [Test]
    public void i_can_not_eat_my_body()
    {
        var g = new Core.Gusanita();

        Assert.Throws<Core.CouldNotEatMySelf>(() =>
        {
            g.Eat(g.Body);
        });
    }

    [Test]
    public void i_can_not_eat_a_part_of_my_body()
    {
        var g = new Core.Gusanita();

        g.Eat(aBanana());

        Assert.Throws<Core.CouldNotEatMySelf>(() =>
        {
            var part = g.Body.Parts.Last();
            g.Eat(part);
        });
    }

    private Core.Fruit aBanana()
    {
        return new Core.Banana();
    }
}

namespace Gusanita.Test;

using Gusanita;

public class AsPlayerTests
{

    [TestCase(Core.Direction.SOUTH)]
    [TestCase(Core.Direction.NORTH)]
    [TestCase(Core.Direction.EAST)]
    [TestCase(Core.Direction.WEST)]
    public void i_want_to_be_able_to_change_direction_of_gusanita(Core.Direction direction)
    {
        Core.Gusanita g = new Core.Gusanita();

        g.To(direction);

        Assert.That(g.LookingTo, Is.EqualTo(direction));
    }

    public void i_want_to_be_able_to_eat_a_fruit_using_gusanita()
    {
        Core.Gusanita g = new Core.Gusanita();
        Core.Fruit f = new Core.Fruit();

        g.Eat(f);

        Assert.That(g.AmountFruitsEaten, Is.EqualTo(1));
    }
}

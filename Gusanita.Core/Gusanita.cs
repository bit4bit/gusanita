namespace Gusanita.Core;

// Larva de mosca
public class Gusanita
{
    public Direction LookingTo
    {
        get
        {
            return _direction;
        }
    }

    public int AmountFruitsEaten
    {
        get
        {
            return _amount_fruits_eaten;
        }
    }

    public GusanitaBody Body;

    public void Eat(GusanitaBodyPart part)
    {
        if (part.Belongs_to(Body))
            throw new CouldNotEatMySelf();
    }

    public void Eat(GusanitaBody body)
    {
        if (Body.Is_same(body))
            throw new CouldNotEatMySelf();
    }

    public void Eat(Gusanita g)
    {
        throw new CouldNotEatMySelf();
    }

    public void Eat(Fruit fruit)
    {
        _amount_fruits_eaten += 1;
        Body.Stretch();
    }

    public void To(Direction direction)
    {
        _direction = direction;
    }


    public Gusanita()
    {
        Body = new GusanitaBody(this);
    }

    private Direction _direction = Direction.EAST;
    private int _amount_fruits_eaten = 0;
}

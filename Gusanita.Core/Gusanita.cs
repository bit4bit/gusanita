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

    public void Move()
    {
        _behavior.GusanitaMovedInDirectionOf(_direction);
    }
    
    public Gusanita(GusanitaBehavior? behavior = null)
    {
        Body = new GusanitaBody(this);
        if (behavior == null)
            _behavior = new GusanitaDumb();
        else
            _behavior = behavior;
    }

    private GusanitaBehavior _behavior;
    private Direction _direction = Direction.EAST;
    private int _amount_fruits_eaten = 0;
}

public interface GusanitaBehavior
{
    public void GusanitaMovedInDirectionOf(Direction direction);
    public void GusanitaAte(Fruit fruit);
}

public class GusanitaDumb : GusanitaBehavior
{
    public void GusanitaMovedInDirectionOf(Direction direction)
    {
    }
    public void GusanitaAte(Fruit fruit)
    {
    }
}

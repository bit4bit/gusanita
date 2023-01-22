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

    public void Eat(Eatable it)
    {
        if (!it.IsEatable())
            throw new CouldNotEatThatThing();
        _behavior.GusanitaAte();
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
        if (behavior == null)
            _behavior = new GusanitaDumb();
        else
            _behavior = behavior;
    }

    private GusanitaBehavior _behavior;
    private Direction _direction = Direction.EAST;
}

public interface GusanitaBehavior
{
    public void GusanitaMovedInDirectionOf(Direction direction);
    public void GusanitaAte();
}

public class GusanitaDumb : GusanitaBehavior
{
    public void GusanitaMovedInDirectionOf(Direction direction)
    {
    }
    public void GusanitaAte()
    {
    }
}

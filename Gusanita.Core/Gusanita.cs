namespace Gusanita.Core;

// Larva de mosca
public class Gusanita
{
    public void Eat(Eatable it)
    {
        if (!it.IsEatable())
            throw new CouldNotEatThatThing();
        _behavior.GusanitaAte();
    }

    public void To(DirectionTo direction)
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
    private DirectionTo _direction = Direction.EAST;
}

public interface GusanitaBehavior
{
    public void GusanitaMovedInDirectionOf(DirectionTo direction);
    public void GusanitaAte();
}

public class GusanitaDumb : GusanitaBehavior
{
    public void GusanitaMovedInDirectionOf(DirectionTo direction)
    {
    }
    public void GusanitaAte()
    {
    }
}

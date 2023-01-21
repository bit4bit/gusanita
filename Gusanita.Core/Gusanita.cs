namespace Gusanita.Core;

// Larva de mosca
public class Gusanita
{
    public Direction LookingTo {
        get {
            return _direction;
        }
    }
    
    public int AmountFruitsEaten {
        get {
            return _amount_fruits_eaten;
        }
    }

    public GusanitaBody Body;

    public void eat(GusanitaBodyPart part)
    {
        if (part.belongs_to(Body))
            throw new CouldNotEatItSelf();
    }
    
    public void eat(GusanitaBody body)
    {
        if (Body.is_same(body))
            throw new CouldNotEatItSelf();
    }
    
    public void eat(Gusanita g)
    {
        throw new CouldNotEatItSelf();
    }

    public void eat(Fruit fruit)
    {
        _amount_fruits_eaten += 1;
        Body.stretch();
    }
    
    public void to(Direction direction)
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

namespace Gusanita.ClassicGame;

public class Player : Core.GusanitaBehavior, Core.Collidable
{
    private Core.Gusanita _gusanita;
    private Core.Position _position;

    public Player(int x, int y)
    {
        _gusanita = new Core.Gusanita(this);
        _position = new Core.Position(x: x, y: y);
    }

    public void ToEast()
    {
        _gusanita.To(Core.Direction.EAST);
    }

    public void ToSouth()
    {
        _gusanita.To(Core.Direction.SOUTH);
    }

    public void ToWest()
    {
        _gusanita.To(Core.Direction.WEST);
    }

    public void ToNorth()
    {
        _gusanita.To(Core.Direction.NORTH);
    }
    
    public void Iterate()
    {
        _gusanita.Move();
    }

    public void Eat(Fruitable fruit)
    {
        _gusanita.Eat(fruit.Fruit());
    }
    
    public bool Collide(Core.Collidable with)
    {
        return with.HasCollided(_position);
    }

    public bool HasCollided(Core.Position obj)
    {
        return false;
    }

    public void GusanitaAte(Core.Fruit fruit)
    {
    }
    
    public void GusanitaMovedInDirectionOf(Core.Direction direction)
    {
        switch(direction)
        {
            case Core.Direction.EAST:
                _position.X += 1;
                break;
            case Core.Direction.WEST:
                _position.X -= 1;
                break;
            case Core.Direction.NORTH:
                _position.Y -= 1;
                break;
            case Core.Direction.SOUTH:
                _position.Y += 1;
                break;
        }
    }
}

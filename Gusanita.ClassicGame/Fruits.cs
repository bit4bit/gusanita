namespace Gusanita.ClassicGame;

public interface Pointable
{
    public int Earn();
}

public interface Fruitable : Pointable, Core.Collidable, Core.Eatable
{
}

public class Fruit : Fruitable
{
    private Core.Position _position;
    private int _earn;
    
    public Fruit(int x, int y, int earn)
    {
        _position = new Core.Position(x: x, y: y);
        _earn = earn;
    }

    public bool HasCollided(Core.Position obj)
    {
        return _position.Intersect(obj);
    }

    public int Earn()
    {
        return _earn;
    }

    public bool IsEatable()
    {
        return true;
    }
}

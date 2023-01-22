namespace Gusanita.ClassicGame;

public interface Pointable
{
    public int Earn();
}

public interface Fruitable : Pointable, Core.Collidable
{
    public Core.Fruit Fruit();
}

public class BananaFruit : Fruitable
{
    private Core.Position _position;
    
    public BananaFruit(int x, int y)
    {
        _position = new Core.Position(x: x, y: y);
    }

    public bool HasCollided(Core.Position obj)
    {
        return _position.Intersect(obj);
    }
    
    public int Earn()
    {
        return 1;
    }

    public Core.Fruit Fruit()
    {
        return new Core.Fruit();
    }
}

public class PapayaFruit : Fruitable
{
    private Core.Position _position;
    
    public PapayaFruit(int x, int y)
    {
        _position = new Core.Position(x: x, y: y);
    }

    public bool HasCollided(Core.Position obj)
    {
        return _position.Intersect(obj);
    }
    
    public int Earn()
    {
        return 3;
    }

    public Core.Fruit Fruit()
    {
        return new Core.Fruit();
    }
}

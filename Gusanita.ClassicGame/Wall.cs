namespace Gusanita.ClassicGame;

public class Wall : Core.Collidable
{
    private int _width;
    private int _height;
    
    public Wall(int width, int height)
    {
        _width = width;
        _height = height;
    }

    public bool HasCollided(Core.Position e)
    {
        if (e.X < 0)
            return true;
        if (e.X > _width)
            return true;
        if (e.Y < 0)
            return true;
        if (e.Y > _height)
            return true;

        return false;
    }
}

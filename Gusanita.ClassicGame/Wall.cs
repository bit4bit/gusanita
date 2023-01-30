namespace Gusanita.ClassicGame;

public class Wall : Core.Collidable
{
    public readonly int Width;
    public readonly int Height;
    public Wall(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public static Wall of5x5()
    {
        return new Wall(width: 5, height: 5);
    }

    public static Wall of(int width, int height)
    {
        return new Wall(width: width, height: height);
    }

    public bool HasCollided(Core.Position e)
    {
        if (e.X < 0)
            return true;
        if (e.X > Width)
            return true;
        if (e.Y < 0)
            return true;
        if (e.Y > Height)
            return true;

        return false;
    }
}

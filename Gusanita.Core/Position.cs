namespace Gusanita.Core;

public class Position
{
    public int X;
    public int Y;

    public Position(Position o)
    {
        X = o.X;
        Y = o.Y;
    }
    
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public bool Intersect(Position with)
    {
        return X == with.X && Y == with.Y;
    }

    public void UpdateFrom(Position pos)
    {
        X = pos.X;
        Y = pos.Y;
    }
}

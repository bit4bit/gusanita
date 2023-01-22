namespace Gusanita.Core;

public class Position
{
    public int X;
    public int Y;

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public bool Intersect(Position with)
    {
        return X == with.X && Y == with.Y;
    }
}

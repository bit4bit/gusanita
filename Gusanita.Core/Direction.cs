namespace Gusanita.Core;

public class Direction
{
    public static DirectionTo EAST {
        get { return new DirectionTo(x: 1, y: 0); }
    }

    public static DirectionTo WEST {
        get { return new DirectionTo(x: -1, y: 0); }
    }

    public static DirectionTo NORTH {
        get { return new DirectionTo(x: 0, y: -1); }
    }

    public static DirectionTo SOUTH {
        get { return new DirectionTo(x: 0, y: 1); }
    }
}

public class DirectionTo
{
    private int X;
    private int Y;

    public DirectionTo(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Apply(Position to)
    {
        to.X += X;
        to.Y += Y;
    }
}

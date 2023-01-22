namespace Gusanita.ClassicGame;

public class Player
{
    private int _x;
    private int _y;
    private Core.Direction _to;
    
    public Player(int x, int y, Core.Direction to)
    {
        _x = x;
        _y = y;
        _to = to;
    }
}

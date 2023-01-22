namespace Gusanita.Console;

class Gusanita : Renderable
{
    public int X { get { return _x; }}
    public int Y { get { return _y; }}

    private int _x;
    private int _y;
    
    public Gusanita(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public void Render(Screener screen)
    {
        screen.RenderCharacter(_x, _y, "o");
    }
}

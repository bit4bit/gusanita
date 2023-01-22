namespace Gusanita.Console;

class Fruit
{
}

class BananaFruit : Fruit, Renderable
{
    private int _x;
    private int _y;
    
    public BananaFruit(int x, int y)
    {
        _x = x;
        _y = y;
    }
    
    public void Render(Screener screen)
    {
        screen.RenderCharacter(_x, _y, "/");
    }
}

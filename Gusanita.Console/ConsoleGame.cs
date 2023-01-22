namespace Gusanita.Console;

public class ConsoleGame
{
    private Screener _screen;
    private int _width;
    private int _height;

    private List<Gusanita> _gusanitas;
    private List<BananaFruit> _fruits;
    
    public ConsoleGame(Screener screen, int width = 0, int height = 0)
    {
        _screen = screen;
        _width = width;
        _height = height;
        _gusanitas = new List<Gusanita>();
        _fruits = new List<BananaFruit>();
    }

    public void AddGusanita(int x, int y)
    {
        _gusanitas.Add(new Gusanita(x: x, y: y));
    }

    public void AddBanana(int x, int y)
    {
        _fruits.Add(new BananaFruit(x: x, y: y));
    }
    
    public void Render()
    {
        _screen.RenderBackground(_width, _height);

        foreach(var fruit in _fruits)
            fruit.Render(_screen);
        
        foreach(var gusanita in _gusanitas)
            gusanita.Render(_screen);
    }
}

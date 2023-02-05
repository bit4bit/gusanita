namespace Gusanita.Console;

class Fruit : ClassicGame.Fruit, Renderable
{
    private string _repr;
    
    public Fruit(int x, int y, string repr = "/", int earn = 1) : base(x: x, y: y, earn: earn)
    {
        _repr = repr;
    }
    
    public void Render(Screener screen)
    {
        screen.RenderCharacter(_position.X, _position.Y, _repr);
    }
}

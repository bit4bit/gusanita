namespace Gusanita.Console;

class Fruit : ClassicGame.Fruitable, Renderable
{
    private Core.Position _position;
    private ClassicGame.Fruitable _fruit;
    
    public Fruit(int x, int y)
    {
        _position = new Core.Position(x: x, y: y);
        _fruit = new ClassicGame.BananaFruit(x: x, y: y);
    }
    
    public void Render(Screener screen)
    {
        screen.RenderCharacter(_position.X, _position.Y, "/");
    }

    public bool HasCollided(Core.Position obj)
    {
        return _fruit.HasCollided(obj);
    }

    public int Earn()
    {
        return _fruit.Earn();
    }

    public bool IsEatable()
    {
        return _fruit.IsEatable();
    }
}

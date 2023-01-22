namespace Gusanita.Console;

class Gusanita : Renderable
{
    private ClassicGame.Player _player;
    
    public Gusanita(ClassicGame.Player player)
    {
        _player = player;
    }

    public void Render(Screener screen)
    {
        foreach(var s in _player.Segments()) {
            screen.RenderCharacter(s.X, s.Y, "o");
        }
    }
}

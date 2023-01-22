namespace Gusanita.ClassicGame;


public class Game
{
    public int Points = 0;
    
    public Game(Player player)
    {
    }

    public void Plant(Pointable fruit)
    {
        Points = fruit.Earn();
    }
    
    public void Process()
    {
    }
}

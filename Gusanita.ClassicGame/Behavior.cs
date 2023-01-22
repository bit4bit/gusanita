namespace Gusanita.ClassicGame;


public interface GusanitaBehavior
{
    public void GusanitaHasAte(Player player, Fruitable fruit);
}

public class GusanitaBehaviorDumb : GusanitaBehavior
{
    public void GusanitaHasAte(Player player, Fruitable fruit)
    {
    }
}

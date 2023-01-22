namespace Gusanita.ClassicGame;

public interface Pointable
{
    public int Earn();
}

public class BananaFruit : Pointable
{
    public BananaFruit(int x, int y)
    {
    }

    public int Earn()
    {
        return 1;
    }
}

public class PapayaFruit : Pointable
{
    public PapayaFruit(int x, int y)
    {
    }

    public int Earn()
    {
        return 3;
    }
}

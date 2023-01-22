namespace Gusanita.ClassicGame;


public class Game
{
    private bool _isFinished;
    public bool IsFinished {
        get { return _isFinished; }
    }

    public int Points = 0;
    private Player _player;
    private List<Fruitable> _fruits;
    private Wall _wall;
    
    public Game(Player player, int width = 0, int height = 0)
    {
        _fruits = new List<Fruitable>();
        _wall = new Wall(width: width, height: height);
        _player = player;
        _isFinished = false;
        Points = 0;
    }

    public void Plant(Fruitable fruit)
    {
        _fruits.Add(fruit);
    }
    
    public void Process()
    {
        _player.Iterate();

        if(_player.Collide(_player)) {
            _isFinished = true;
        } else if(_player.Collide(_wall)) {
            _isFinished = true;
        } else {
            foreach(var fruit in _fruits) {
                if (_player.Collide(fruit)) {
                    _player.Eat(fruit);
                    Points += fruit.Earn();
                }
            }
        }
    }
}

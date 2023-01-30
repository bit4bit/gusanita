namespace Gusanita.ClassicGame;


public class Game
{
    public bool IsFinished {
        get { return _isFinished; }
    }
    private bool _isFinished;
    
    public int Points = 0;
    
    private Player _player;
    private List<Fruitable> _fruits;
    private Wall _wall;
    private GusanitaBehavior _behavior;
    
    public Game(Player player, Wall wall, GusanitaBehavior? behavior = null)
    {
        _fruits = new List<Fruitable>();
        _wall = wall;
        _player = player;
        _isFinished = false;
        Points = 0;

        if (behavior == null)
            _behavior = new GusanitaBehaviorDumb();
        else
            _behavior = behavior;
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
            Fruitable? fruit_ate = null;
            
            foreach(var fruit in _fruits) {
                if (_player.Collide(fruit)) {
                    _player.Eat(fruit);
                    fruit_ate = fruit;
                    Points += fruit.Earn();
                    
                    _behavior.GusanitaHasAte(_player, fruit_ate);
                    break;
                }
            }

            if (fruit_ate != null) {
                _fruits.Remove(fruit_ate);
            }
        }
    }
}

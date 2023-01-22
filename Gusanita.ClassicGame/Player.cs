namespace Gusanita.ClassicGame;

using System.Collections.Generic;

public class Player : Core.GusanitaBehavior, Core.Collidable
{
    private Core.Gusanita _gusanita;
    private Core.Position _head;
    private Body _body;

    public class Segment
    {
        public int X;
        public int Y;
        
        public Segment(Core.Position pos)
        {
            X = pos.X;
            Y = pos.Y;
        }
    }
    
    public Player(int x, int y)
    {
        _gusanita = new Core.Gusanita(this);
        _head = new Core.Position(x: x, y: y);
        _body = new Body(head: _head);
    }

    public void ToEast()
    {
        _gusanita.To(Core.Direction.EAST);
    }

    public void ToSouth()
    {
        _gusanita.To(Core.Direction.SOUTH);
    }

    public void ToWest()
    {
        _gusanita.To(Core.Direction.WEST);
    }

    public void ToNorth()
    {
        _gusanita.To(Core.Direction.NORTH);
    }
    
    public void Iterate()
    {
        _gusanita.Move();
    }

    public IEnumerable<Segment> Segments()
    {
        List<Segment> segments = new List<Segment>();
        
        segments.Add(new Segment(_head));
        foreach(var pos in _body.Segments) {
            segments.Add(new Segment(pos));
        }

        return segments;
    }
    
    public void Eat(Core.Eatable thing)
    {
        _gusanita.Eat(thing);
    }
    
    public bool Collide(Core.Collidable with)
    {
        return with.HasCollided(_head);
    }

    public bool HasCollided(Core.Position obj)
    {
        if(_body.Collide(obj))
            return true;
        
        return false;
    }

    public void GusanitaAte()
    {
        _body.GrowUp();
    }
    
    public void GusanitaMovedInDirectionOf(Core.Direction direction)
    {
        _body.Move();
        
        switch(direction)
        {
            case Core.Direction.EAST:
                _head.X += 1;
                break;
            case Core.Direction.WEST:
                _head.X -= 1;
                break;
            case Core.Direction.NORTH:
                _head.Y -= 1;
                break;
            case Core.Direction.SOUTH:
                _head.Y += 1;
                break;
        }
    }


    private class Body
    {
        private Core.Position _head;
        private List<Core.Position> _segments;
        public List<Core.Position> Segments {
            get { return cloneSegments(); }
        }
        
        public Body(Core.Position head)
        {
            _head = head;
            _segments = new List<Core.Position>();
        }

        public void GrowUp()
        {
            var segment = new Core.Position(_head);
            _segments.Add(segment);
        }

        public void Move()
        {
            Core.Position previous = _head;
            List<Core.Position> segments = cloneSegments();
            segments.Add(_head);
            
            using(var it = segments.GetEnumerator())
            {
                if (it.MoveNext())
                    previous = it.Current;
                
                while(it.MoveNext()) {
                    previous.UpdateFrom(it.Current);
                }
            }
        }

        public bool Collide(Core.Position with)
        {
            foreach(var segment in _segments)
                if(segment.Intersect(with))
                    return true;
            return false;
        }

        private List<Core.Position> cloneSegments()
        {
            return new List<Core.Position>(_segments);
        }
    }
}

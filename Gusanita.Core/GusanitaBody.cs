namespace Gusanita.Core;

public class GusanitaBody
{
    public List<GusanitaBodyPart> Parts
    {
        get
        {
            return _parts;
        }
    }

    public int Length
    {
        get
        {
            return _length;
        }
    }

    private List<GusanitaBodyPart> _parts;
    private int _length;
    private Gusanita _gusanita;

    public GusanitaBody(Gusanita g)
    {
        _gusanita = g;
        _parts = new List<GusanitaBodyPart>();
        _length = 0;
    }

    public void Stretch()
    {
        _length += 1;
        _parts.Add(new GusanitaBodyPart(this));
    }

    public bool Is_same(GusanitaBody other)
    {
        return _gusanita.Equals(other._gusanita);
    }
}

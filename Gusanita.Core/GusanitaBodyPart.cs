namespace Gusanita.Core;

public class GusanitaBodyPart
{
    private GusanitaBody _body;

    public GusanitaBodyPart(GusanitaBody body)
    {
        _body = body;
    }

    public bool Belongs_to(GusanitaBody body)
    {
        return _body.Is_same(body);
    }
}

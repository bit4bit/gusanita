namespace Gusanita.Core;

public class GusanitaBodyPart
{
    private GusanitaBody _body;

    public GusanitaBodyPart(GusanitaBody body)
    {
        _body = body;
    }

    public bool belongs_to(GusanitaBody body)
    {
        return _body.is_same(body);
    }
}

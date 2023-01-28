namespace Gusanita.Console;

public interface Screener
{
    public void RenderBackground(int width, int height);
    public void RenderCharacter(int x, int y, string ch);
    public void Refresh();
}

public class TextScreen : Screener
{
    private string[,] _screen;
    private int _screen_width;
    private int _screen_height;
    
    public string Text {
        get {
            return screenToText("");
        }
    }
    
    public string TextLine {
        get {
            return screenToText("\n");
        }
    }

    public TextScreen(int width = 10, int height = 10)
    {
        _screen = new string[height, width];
        _screen_width = width;
        _screen_height = height;
    }
    
    public void RenderBackground(int width, int height)
    {
        int max_width = Math.Min(width, _screen_width);
        int max_height = Math.Min(height, _screen_height);
        
        for(int x = 0; x < max_width; x++)
            for(int y = 0; y < max_height; y++)
                _screen[x, y] = "."; 
    }

    public void RenderCharacter(int x, int y, string ch)
    {
        _screen[x, y] = ch;
    }

    public void Refresh()
    {
    }
    
    private string screenToText(string eol)
    {
        var output = "";
        
        for(int y = 0; y < _screen_height; y++) {
            for(int x = 0; x < _screen_width; x++)
                output += _screen[x, y];
            output += eol;
        }

        return output;
    }
}

public class ConsoleScreen : Screener
{
    private TextScreen _textScreen;
    
    public ConsoleScreen(int width, int height)
    {
        _textScreen = new TextScreen(width, height);
    }

    public void RenderBackground(int width, int height)
    {
        _textScreen.RenderBackground(width, height);
    }

    public void RenderCharacter(int x, int y, string ch)
    {
        _textScreen.RenderCharacter(x, y, ch);
    }

    public void Refresh()
    {
        System.Console.Write(_textScreen.TextLine);
    }
}

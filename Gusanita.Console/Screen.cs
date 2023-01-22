namespace Gusanita.Console;

public interface Screener
{
    
    public void RenderBackground(int width, int height);
    public void RenderCharacter(int x, int y, string ch);
}

public class TextScreen : Screener
{
    private string[,] _screen;
    private int _screen_width;
    private int _screen_height;
    
    public string Text {
        get {
            var output = "";
            
            for(int y = 0; y < _screen_height; y++)
                for(int x = 0; x < _screen_width; x++)
                    output += _screen[x, y];

            return output;
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
}

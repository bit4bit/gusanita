using Gusanita.Console;

int WIDTH = 10;
int HEIGHT = 10;
int FRUITS = 5;

var k = new KeyboardController();
var c = new ConsoleScreen(width: WIDTH, height: HEIGHT);
var g = new ConsoleGame(screen: c, controller: k,
                        width: WIDTH, height: HEIGHT, fruits: FRUITS);

Console.WriteLine("Gusanita !!");

// un panorama inicial del juego
g.Render();

while(g.Iterate()) {
    g.Render();
    Console.WriteLine("---");
    Thread.Sleep(500);
}

    

using Gusanita.Console;

var k = new KeyboardController();
var c = new ConsoleScreen(5, 5);
var g = new ConsoleGame(screen: c, controller: k,
                        width: 5, height: 5);

Console.WriteLine("Gusanita !!");

g.AddBanana(y: 3, x: 2);
g.AddBanana(y: 2, x: 2);

// un panorama del juego
g.Render();

while(true) {
    g.Iterate();
    g.Render();
    Console.WriteLine("---");
    Thread.Sleep(500);
}

    

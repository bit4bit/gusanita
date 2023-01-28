using Gusanita.Console;

var c = new ConsoleScreen(5, 5);
var g = new ConsoleGame(c, 5, 5);

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

    

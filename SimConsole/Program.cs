using Simulator.Maps;
using Simulator;
using System.Text;

namespace SimConsole;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;  

        var map = new SmallTorusMap(8,6);

        var orc = new Orc("Shrek");
        var elf = new Elf("Legolas");

        var rabbits1 = new Animals { Description = "Rabbit1", Symbol = 'A' };
        var rabbits2 = new Animals { Description = "Rabbit2", Symbol = 'A' };
        var rabbits3 = new Animals { Description = "Rabbit3", Symbol = 'A' };

        var ostrich1 = new Birds("Ostrich1", 5, false);
        var ostrich2 = new Birds("Ostrich2", 5, false);

        var eagle1 = new Birds("Eagle1", 3, true);
        var eagle2 = new Birds("Eagle2", 3, true);  

        var objects = new List<IMappable> {
        orc, elf,
        rabbits1, rabbits2, rabbits3,
        ostrich1, ostrich2,
        eagle1, eagle2
    };

        var points = new List<Point> {
        new(4, 2), new(3, 5),
        new(1, 1), new(2, 1), new(3, 1),
        new(1, 3), new(2, 3),
        new(5, 5), new(6, 5)
    };

        string moves = "URDL";  

        var simulation = new Simulation(map, objects, points, moves);
        var mapVisualizer = new MapVisualizer(simulation.Map);

        Console.WriteLine("Naciśnij dowolny klawisz, aby rozpocząć symulację...");
        Console.ReadKey(true);

        while (!simulation.Finished)
        {
            mapVisualizer.Draw();
            Console.WriteLine($"\nRuch: {simulation.CurrentObject.Name} idzie {simulation.CurrentMoveName}");
            simulation.Turn();
            Thread.Sleep(1000);  
        }

        mapVisualizer.Draw();
        Console.WriteLine("\nSymulacja zakończona!");
    }
}

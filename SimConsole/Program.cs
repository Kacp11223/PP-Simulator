using Simulator.Maps;
using Simulator;
using System.Text;

namespace SimConsole;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        var map = new SmallSquareMap(10);  
        var creatures = new List<Creature> { new Orc("Shrek"), new Elf("Legolas") };
        var points = new List<Point> { new(2, 2), new(3, 1) };
        string moves = "drluuuddlrurlddulr";

        var simulation = new Simulation(map, creatures, points, moves);
        var mapVisualizer = new MapVisualizer(simulation.Map);

        Console.WriteLine("Naciśnij dowolny klawisz, aby rozpocząć symulację...");
        Console.ReadKey(true);

        while (!simulation.Finished)
        {
            mapVisualizer.Draw();
            Console.WriteLine($"\nRuch: {simulation.CurrentCreature.Name} idzie {simulation.CurrentMoveName}");
            simulation.Turn();
            Thread.Sleep(1000);
        }


        mapVisualizer.Draw();
        Console.WriteLine("\nSymulacja zakończona!");
    }
}

using Simulator.Maps;
using Simulator;

namespace Runner;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Point p = new(10, 25);
        Console.WriteLine(p.Next(Direction.Right));
        Console.WriteLine(p.NextDiagonal(Direction.Right));
        Lab5b();
    }

    static void Lab5b()
    {
        try
        {
            // Map creation test
            SmallSquareMap map = new SmallSquareMap(10);
            Console.WriteLine($"Map of size: {map.Size}");

            // Test Exist()
            Point inside = new Point(5, 5);
            Point outside = new Point(-1, 10);
            Console.WriteLine($"Point {inside} exist: {map.Exist(inside)}");  // True
            Console.WriteLine($"Point {outside} exist: {map.Exist(outside)}"); // False

            // Test Next()
            Point start = new Point(9, 9);
            Point next = map.Next(start, Direction.Right);
            Console.WriteLine($"Next point {start} to the right: {next}");  // should be (9, 9), out of bounds

            // Test NextDiagonal()
            Point diagonalStart = new Point(5, 8);
            Point diagonalNext = map.NextDiagonal(diagonalStart, Direction.Up);
            Console.WriteLine($"Next point diagonally {diagonalStart} up: {diagonalNext}");

            // Invalid size check, should throw it
            SmallSquareMap invalidMap = new SmallSquareMap(25);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
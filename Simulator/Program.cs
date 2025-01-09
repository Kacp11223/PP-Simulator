namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Point p = new(10, 25);
        Console.WriteLine(p.Next(Direction.Right));          
        Console.WriteLine(p.NextDiagonal(Direction.Right));
        Lab5a();
    }

    static void Lab5a()
    {
        try
        {
            // Correct rectangles
            Rectangle r1 = new Rectangle(4, 2, 6, 6);
            Console.WriteLine($"Rectangle {r1}");

            // Rectangle with invalid coordinates
            Rectangle r2 = new Rectangle(6, 6, 4, 2);
            Console.WriteLine($"Rectangle {r2} with switched sides");

            // Rectangle with given point
            Point p1 = new Point(4, 3);
            Console.WriteLine($"Rectangle {r1} contains point {p1}: {r1.Contains(p1)}");

            // Rectangle without given point
            Point p2 = new Point(10, 10);
            Console.WriteLine($"Rectangle {r1} contains point {p2}: {r1.Contains(p2)}");

            // Invalid rectangle (collinear)
            Rectangle invalid = new Rectangle(4, 3, 4, 7);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

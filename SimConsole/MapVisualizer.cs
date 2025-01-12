using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;
using Simulator;
namespace SimConsole;

public class MapVisualizer
{
    private readonly Map _map;

    public MapVisualizer(Map map)
    {
        _map = map;
    }

    public void Draw()
    {
        Console.Clear();
        DrawBorder();
        DrawContent();
    }

    private void DrawBorder()
    {
        // Top border
        Console.Write(Box.TopLeft);
        for (int x = 0; x < _map.SizeX; x++)
        {
            Console.Write(Box.Horizontal);
            if (x < _map.SizeX - 1)
                Console.Write(Box.TopMid);
        }
        Console.WriteLine(Box.TopRight);

        // Map content with borders
        for (int y = _map.SizeY - 1; y >= 0; y--)
        {
            // Left border
            Console.Write(Box.Vertical);

            // Map content
            for (int x = 0; x < _map.SizeX; x++)
            {
                var point = new Point(x, y);
                var creaturesAtPoint = _map.At(point);

                if (creaturesAtPoint.Count > 0)
                {
                    if (creaturesAtPoint.Count > 1)
                        Console.Write('X');
                    else
                        Console.Write(creaturesAtPoint[0].GetType().Name[0]);
                }
                else if (_map.Exist(point))
                    Console.Write(' ');
                else
                    Console.Write('E');

                // Vertical borders between cells
                if (x < _map.SizeX - 1)
                    Console.Write(Box.Vertical);
            }

            // Right border
            Console.WriteLine(Box.Vertical);

            // Horizontal borders between rows
            if (y > 0)
            {
                Console.Write(Box.MidLeft);
                for (int x = 0; x < _map.SizeX; x++)
                {
                    Console.Write(Box.Horizontal);
                    if (x < _map.SizeX - 1)
                        Console.Write(Box.Cross);
                }
                Console.WriteLine(Box.MidRight);
            }
        }

        // Bottom border
        Console.Write(Box.BottomLeft);
        for (int x = 0; x < _map.SizeX; x++)
        {
            Console.Write(Box.Horizontal);
            if (x < _map.SizeX - 1)
                Console.Write(Box.BottomMid);
        }
        Console.WriteLine(Box.BottomRight);
    }

    private void DrawContent()
    {
        Console.WriteLine("\nLegenda:");
        Console.WriteLine("  - puste pole");
        Console.WriteLine("N - pole niedostępne");
        Console.WriteLine("X - pole zajęte przez więcej niż 1 stwora");
        Console.WriteLine("Pierwsza litera typu stwora (np. E dla Elf) - pole z 1 stworem");
    }
}

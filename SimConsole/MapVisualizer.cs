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
        Console.Write(Box.TopLeft);
        for (int x = 0; x < _map.SizeX; x++)
        {
            Console.Write(Box.Horizontal);
            if (x < _map.SizeX - 1)
                Console.Write(Box.TopMid);
        }
        Console.WriteLine(Box.TopRight);

        for (int y = _map.SizeY - 1; y >= 0; y--)
        {
            Console.Write(Box.Vertical);

            for (int x = 0; x < _map.SizeX; x++)
            {
                var point = new Point(x, y);
                var objectsAtPoint = _map.At(point);

                if (objectsAtPoint.Count > 0)
                {
                    if (objectsAtPoint.Count > 1)
                        Console.Write('X');
                    else
                    {
                        var obj = objectsAtPoint[0];
                        if (obj is Animals animal)
                            Console.Write(animal.Symbol);
                        else
                            Console.Write(obj.GetType().Name[0]);
                    }
                }
                else if (_map.Exist(point))
                    Console.Write(' ');
                else
                    Console.Write('N');

                if (x < _map.SizeX - 1)
                    Console.Write(Box.Vertical);
            }

            Console.WriteLine(Box.Vertical);

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
        Console.WriteLine("X - pole zajęte przez więcej niż 1 obiekt");
        Console.WriteLine("A - zwykłe zwierzę");
        Console.WriteLine("B - ptak latający");
        Console.WriteLine("b - ptak nielot");
    }
}

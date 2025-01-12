using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    protected readonly Dictionary<Point, List<IMappable>> mappableObjects = new();
    public readonly int SizeX;
    public readonly int SizeY;

    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5 || sizeY < 5)
            throw new ArgumentOutOfRangeException("Map dimensions must be at least 5");

        SizeX = sizeX;
        SizeY = sizeY;
    }

    public abstract bool Exist(Point p);
    public abstract Point Next(Point p, Direction d);
    public abstract Point NextDiagonal(Point p, Direction d);

    protected bool IsInBounds(Point p) =>
        p.X >= 0 && p.X < SizeX && p.Y >= 0 && p.Y < SizeY;

    public void Add(IMappable obj, Point position)
    {
        if (!Exist(position))
            throw new ArgumentException("Position does not exist on this map");

        if (!mappableObjects.ContainsKey(position))
            mappableObjects[position] = new List<IMappable>();

        mappableObjects[position].Add(obj);
        obj.SetMap(this, position);
    }

    public void Remove(Point position, IMappable obj)
    {
        if (mappableObjects.ContainsKey(position))
        {
            mappableObjects[position].Remove(obj);
            if (mappableObjects[position].Count == 0)
                mappableObjects.Remove(position);
        }
    }

    public void Move(Point from, Point to, IMappable obj)
    {
        if (!Exist(to))
            throw new ArgumentException("Destination position does not exist");

        Remove(from, obj);
        Add(obj, to);
    }

    public List<IMappable> At(Point position)
    {
        return mappableObjects.ContainsKey(position)
            ? new List<IMappable>(mappableObjects[position])
            : new List<IMappable>();
    }

    public List<IMappable> At(int x, int y) => At(new Point(x, y));
}




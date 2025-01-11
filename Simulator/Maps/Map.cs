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

    protected readonly Dictionary<Point, List<Creature>> creatures = new();
    public readonly int SizeX;
    public readonly int SizeY;

    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5 || sizeY < 5)
            throw new ArgumentOutOfRangeException("Map dimensions must be at least 5");

        SizeX = sizeX;
        SizeY = sizeY;
    }

    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public abstract bool Exist(Point p);

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);

    protected bool IsInBounds(Point p) =>
        p.X >= 0 && p.X < SizeX && p.Y >= 0 && p.Y < SizeY;

    public void Add(Creature creature, Point position)
    {
        if (!Exist(position))
            throw new ArgumentException("Position does not exist on this map");

        if (!creatures.ContainsKey(position))
            creatures[position] = new List<Creature>();

        creatures[position].Add(creature);
        creature.SetMap(this, position);
    }

    public void Remove(Point position, Creature creature)
    {
        if (creatures.ContainsKey(position))
        {
            creatures[position].Remove(creature);
            if (creatures[position].Count == 0)
                creatures.Remove(position);
        }
    }

    public void Move(Point from, Point to, Creature creature)
    {
        if (!Exist(to))
            throw new ArgumentException("Destination position does not exist");

        Remove(from, creature);
        Add(creature, to);
    }

    public List<Creature> At(Point position)
    {
        return creatures.ContainsKey(position)
            ? new List<Creature>(creatures[position])
            : new List<Creature>();
    }

    public List<Creature> At(int x, int y) => At(new Point(x, y));
}




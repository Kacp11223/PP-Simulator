using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public readonly int Size;

    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20)
        {
            throw new NotImplementedException("Map size must be in range of 5 to 20");
        }
        Size = size;
    }

    public override bool Exist(Point p)
    {
        // On torroidal plane all points are in range of 0..Size-1
        return true;
    }

    private int NormalizeCoordinate(int coord)
    {
        // Checks if coordinates are in rrange of 0..Size-1
        coord = coord % Size;
        if (coord < 0)
        {
            coord += Size;
        }
        return coord;
    }

    private Point NormalizePoint(Point p)
    {
        // Normalize both points coordinates to the scope of toroidal plane
        return new Point(
            NormalizeCoordinate(p.X),
            NormalizeCoordinate(p.Y)
        );
    }

    public override Point Next(Point p, Direction d)
    {
        p = NormalizePoint(p);
        return NormalizePoint(p.Next(d));
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        p = NormalizePoint(p);
        return NormalizePoint(p.NextDiagonal(d));
    }
}

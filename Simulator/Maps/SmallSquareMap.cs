using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{
    public SmallSquareMap(int size) : base(size, size) { }

    public override bool Exist(Point p) => IsInBounds(p);

    public override Point Next(Point p, Direction d)
    {
        var nextPoint = p.Next(d);
        return IsInBounds(nextPoint) ? nextPoint : p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var nextPoint = p.NextDiagonal(d);
        return IsInBounds(nextPoint) ? nextPoint : p;
    }
}

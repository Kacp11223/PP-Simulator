using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallTorusMap : SmallMap
{
    public SmallTorusMap(int size) : base(size, size) { }
    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    public override bool Exist(Point p) => true;

    private int NormalizeCoordinate(int coord, int size)
    {
        coord = coord % size;
        return coord < 0 ? coord + size : coord;
    }

    private Point NormalizePoint(Point p) => new(
        NormalizeCoordinate(p.X, SizeX),
        NormalizeCoordinate(p.Y, SizeY)
    );

    public override Point Next(Point p, Direction d) =>
        NormalizePoint(p.Next(d));

    public override Point NextDiagonal(Point p, Direction d) =>
        NormalizePoint(p.NextDiagonal(d));
}

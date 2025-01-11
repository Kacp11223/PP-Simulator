using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

/// <summary>
/// Base class for maps with maximum size of 20x20
/// </summary>
public abstract class SmallMap : Map
{
    protected const int MaxSize = 20;

    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > MaxSize || sizeY > MaxSize)
            throw new ArgumentOutOfRangeException($"Small map dimensions cannot exceed {MaxSize}");
    }
}

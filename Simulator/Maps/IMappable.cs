using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public interface IMappable
{
    string Name { get; }
    void SetMap(Map map, Point position);
    string Go(Direction direction);
}

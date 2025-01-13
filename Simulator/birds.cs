using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;

namespace Simulator;

public class Birds : Animals
{
    public Birds() : base()
    {
        Symbol = 'B';
    }

    public bool CanFly { get; set; } = true;
    public override string Info => $"{Description} (fly{(CanFly ? "+" : "-")}) <{Size}>";

    public Birds(string _description, uint size, bool canFly = true) : base()
    {
        Description = _description;
        Size = size;
        CanFly = canFly;
        Symbol = canFly ? 'B' : 'b';
    }

    public override string Go(Direction direction)
    {
        if (_currentMap == null || _position == null)
            return "Can't move - not on any map";

        Point nextPosition;
        if (CanFly)
        {
            var firstStep = _position.Value.Next(direction);
            nextPosition = firstStep.Next(direction);
        }
        else
        {
            nextPosition = _currentMap.NextDiagonal(_position.Value, direction);
        }

        if (!nextPosition.Equals(_position))
        {
            _currentMap.Move(_position.Value, nextPosition, this);
            _position = nextPosition;
        }

        return $"{direction.ToString().ToLower()}";
    }
}

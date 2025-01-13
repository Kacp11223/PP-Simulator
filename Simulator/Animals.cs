using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;

namespace Simulator;

public class Animals : IMappable
{
    private string _description = "Unknown";
    protected Map? _currentMap;
    protected Point? _position;
    public char Symbol { get; init; } = 'A'; 

    public string Name => Description;

    public string Description
    {
        get => _description;
        init => _description = Validator.Shortener(value, 3, 15, '#');
    }
    public uint Size { get; init; } = 3;
    public virtual string Info => $"{Description} <{Size}>";

    public void SetMap(Map map, Point position)
    {
        _currentMap = map;
        _position = position;
    }

    public virtual string Go(Direction direction)
    {
        if (_currentMap == null || _position == null)
            return "Can't move - not on any map";

        var nextPosition = _currentMap.Next(_position.Value, direction);
        if (!nextPosition.Equals(_position))
        {
            _currentMap.Move(_position.Value, nextPosition, this);
            _position = nextPosition;
        }
        return $"{direction.ToString().ToLower()}";
    }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}



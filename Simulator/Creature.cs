    using System;
    using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
    using System.Reflection.Emit;
    using System.Reflection.Metadata.Ecma335;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
using Simulator.Maps;

namespace Simulator;
public abstract class Creature : IMappable
{
    private string _name = "Unknown";
    private int _level = 1;
    private Map? _currentMap;
    private Point? _position;

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature()
    {
    }

    public string Name
    {
        get => _name;
        init => _name = Validator.Shortener(value, 3, 25, '#');
    }

    public int Level
    {
        get => _level;
        init => _level = Validator.Limiter(value, 1, 10);
    }

    public Point? Position => _position;
    public Map? CurrentMap => _currentMap;

    public void Upgrade()
    {
        if (_level < 10)
            _level++;
    }

    public abstract string Greeting();
    public abstract string Info { get; }
    public abstract int Power { get; }

  
    void IMappable.SetMap(Map map, Point position)
    {
        _currentMap = map;
        _position = position;
    }

    string IMappable.Go(Direction direction)
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
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

namespace Simulator;
public abstract class Creature
{
    private string _name = "Unknown";
    private int _level = 1;
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
    public void Upgrade()
    {
        if (_level < 10)
            _level++;
    }

    public abstract string Greeting();
    public abstract string Info { get; }

    public string[] Go(List<Direction> directions)
    {
        var results = new string[directions.Count];
        for (int i = 0; i < directions.Count; i++)
        {
            results[i] = Go(directions[i]);
        }
        return results;
    }

    public string Go(Direction direction) => $"{direction.ToString().ToLower()}";

    public string[] Go(string input)
    {
        var parseDirections = DirectionParser.Parse(input);
        return Go(parseDirections);
    }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

    public abstract int Power { get; }
}
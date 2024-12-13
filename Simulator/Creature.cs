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
    public Creature(string _name, int _level = 1)
    {
        Name = _name;
        Level = _level;
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
    
    public virtual void SayHi() =>
        Console.WriteLine($"Hi! I'm {Name}, level {Level}.");
    public abstract string Info { get; }

    public void Go(Direction[] directions)
    {
        foreach (var direction in directions)
        {
            Go(direction);
        }
    }

    public void Go(Direction direction)
    {
        string directionText = direction.ToString().ToLower();
        
        Console.WriteLine($"{Name} goes {directionText}.");
    }

    public void Go(string directions)
    {
        Direction[] parsedDirections = DirectionParser.Parse(directions);

        Go(parsedDirections);
    }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
    public abstract int Power { get; }
}
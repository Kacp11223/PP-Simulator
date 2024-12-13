using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Creature
{
    public string Name { get; set; }
    public int Level { get; set; }

    public Creature(string name, int level)
    {
        Name = name;
        Level = level;
    }

    public string Info => $"{Name} [{Level}]";
    public void SayHi() =>
    Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
}

public class Animals
{
    public required string Description { get; init; }
    public uint Size { get; set; } = 3;

    public string Info => $"Dogs: <3>.";
}

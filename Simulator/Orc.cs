using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

internal class Orc : Creature
{
    private int huntSum = 0;
    private int rage = 1;
    public Orc() : base() { }

    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }

    public int Rage
    {
        get => rage;

        init => rage = Validator.Limiter(value, 0, 10);
    }
    public override int Power => 7 * Level + 3 * Rage;

    public void Hunt()
    {
        huntSum++;

        Console.WriteLine($"{Name} is hunting.");

        if (huntSum % 2 == 0 && rage < 10)
        {
            rage++;
        }
    }

    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");

    public override string Info => $"{Name} [{Level}][{Rage}]";
}

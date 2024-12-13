using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Elf : Creature
{
    private int singSum = 0;
    private int agility = 1;

    public Elf() : base() { }

    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }

    public int Agility
    {
        get => agility;

        init
        {
            if (value < 0) agility = 0;

            else if (value > 10) agility = 10;

            else agility = value;
        }
    }
    public override int Power => 8 * Level + 2 * Agility;

    public void Sing()
    {
        singSum++;

        Console.WriteLine($"{Name} is singing.");

        if (singSum % 3 == 0 && agility < 10)
        {
            agility++;
        }
    }

    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");
}

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

        init => agility = Validator.Limiter(value, 0, 10);
    }
    public override int Power => 8 * Level + 2 * Agility;

    public void Sing()
    {
        singSum++;

        if (singSum % 3 == 0 && agility < 10)
        {
            agility++;
        }
    }

    public override string Greeting() => ($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");

    public override string Info => $"{Name} [{Level}][{Agility}]";
}

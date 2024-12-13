    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection.Emit;
    using System.Reflection.Metadata.Ecma335;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

namespace Simulator;
public class Creature
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
        init
        {
            string shortForm = value.Trim();

            if (shortForm.Length < 3)
                shortForm = shortForm.PadRight(3, '#');

            if (shortForm.Length > 25)
            {
                shortForm = shortForm.Substring(0, 25).TrimEnd();

                if (shortForm.Length < 3)
                    shortForm = shortForm.PadRight(3, '#');
            }
            if (char.IsLower(shortForm[0]))

                shortForm = char.ToUpper(shortForm[0]) + shortForm.Substring(1);
            _name = shortForm;
        }
    }
    public int Level
    {
        get => _level;

        init
        {
            if (value < 1) _level = 1;
            else if (value > 10) _level = 10;
            else _level = value;
        }
    }
    public void Upgrade()
    {
        if (_level < 10)
            _level++;
    }
    
    public void SayHi() =>
        Console.WriteLine($"Hi! I'm {Name}, level {Level}.");
    public string Info => $"Name: {Name}, Level: {Level}";
}
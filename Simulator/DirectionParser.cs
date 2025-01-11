using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public static class DirectionParser
{
    public static List<Direction> Parse(string directions)
    {
        var steps = new List<Direction>();
        foreach (var change in directions.ToUpper())
        {
            switch (change)
            {
                case 'R':
                    steps.Add(Direction.Right);
                    break;
                case 'L':
                    steps.Add(Direction.Left);
                    break;
                case 'U':
                    steps.Add(Direction.Up);
                    break;
                case 'D':
                    steps.Add(Direction.Down);
                    break;
            }
        }
        return steps;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Birds : Animals
{
    public Birds() : base() { }

    public bool CanFly { get; set; } = true;
    public override string Info => $"{Description} (fly{(CanFly ? "+" : "-")}) <{Size}>";

    public Birds(string _description, uint size, bool canFly = true) : base()
    {
        Description = _description;
        Size = size;
        CanFly = canFly;
    }
}

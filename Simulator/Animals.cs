using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

internal class Animals
{
    private string _description = "Unknown";
    public string Description
    {
        get => _description;
        init
        {
            string shortForm = value.Trim();

            if (shortForm.Length < 3)
                shortForm = shortForm.PadRight(3, '#');

            if (shortForm.Length > 15)
            {
                shortForm = shortForm.Substring(0, 15).TrimEnd();

                if (shortForm.Length < 3)
                    shortForm = shortForm.PadRight(3, '#');
            }
            if (char.IsLower(shortForm[0]))
                shortForm = char.ToUpper(shortForm[0]) + shortForm.Substring(1);

            _description = shortForm;
        }
    }
    public string Info => $"{Description} <{Size}>";

    public uint Size { get; set; } = 3;
    
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace European_Calculator
{
    struct Country
    {
        public string CountrieName;
        public float Population;
        public CountryPosition Position;
    }
    enum CountryPosition
    {
        Yes,
        No,
        Abstain,
        Notparticpating
    };
}

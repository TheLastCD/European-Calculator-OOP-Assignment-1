using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace European_Calculator
{
    //Structure Name: Country
    //Elements: String CountrieName, Float Population, Countryposition Position
    struct Country
    {
        public string CountrieName;
        public float Population;
        public CountryPosition Position;
    }
    //Enumerated List: CountryPosition
    //Elements: Yes,No, Abstain, Notparticpating
    enum CountryPosition
    {
        Yes,
        No,
        Abstain,
        Notparticpating
    };
}

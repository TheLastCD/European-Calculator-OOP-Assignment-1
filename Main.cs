using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace European_Calculator
{
    class Main
    {
        Country[] EuCountries = new Country[27];
        public void Create()
        {
            int count = 0;
            foreach (string line in File.ReadLines(@"ListOfCountries"))
            {
                string[] countryAndPerc = line.Split();
                float population;
                try
                {
                    population = float.Parse(countryAndPerc[1]);
                }
                catch
                {
                    population = 0; 
                }
                EuCountries[count].CountrieName = countryAndPerc[0];
                EuCountries[count].Population = population;
                EuCountries[count].Position = CountryPosition.Yes;
                count++;
            }

        }
        public void VoteChange(int loc, bool pos)
        {
            CountryPosition VoteChoice = CountryPosition.No;
            if (pos)
            {
                VoteChoice = CountryPosition.Yes;
            }
            EuCountries[loc].Position = VoteChoice;
        }
        public void PartispantChange(int loc)
        {
            EuCountries[loc].Position = CountryPosition.Notparticpating;
        }
        public void AbstainChange(int loc)
        {
            EuCountries[loc].Position = CountryPosition.Abstain; 
        }
    }
}

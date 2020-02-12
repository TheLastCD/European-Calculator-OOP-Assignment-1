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
        //Creating the list that contains the countries and structures
        Country[] EuCountries = new Country[File.ReadLines(@"ListOfCountries").Count()+1];
        
        //Method Name: Create
        //Return: Void
        //Accepts: null
        //Purpose: Designed to bring in the country data from the file and populate the EuCountries list
        //         Triggered when the program launches
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

        //Method Name: VoteChange
        //Accepts: Integer loc, Boolean pos
        //Return: void
        //Purpose: this method is triggered when the numbers are updated
        //         it has to accept an extra arguement as it must modify depending on voting no or yes
        public void VoteChange(int loc, bool pos)
        {
            CountryPosition VoteChoice = CountryPosition.No;
            if (pos)
            {
                VoteChoice = CountryPosition.Yes;
            }
            EuCountries[loc].Position = VoteChoice;
        }
        
        //Method Name: ParticipantsChange
        //Accepts: Integer Loc
        //Return: void
        //Purpose: this method logs a change to the countries participating
        public void PartispantChange(int loc)
        {
            EuCountries[loc].Position = CountryPosition.Notparticpating;
        }

        //Method Name: Abstain Change
        //Accepts: integer Loc
        //Return: void
        //Purpose: to log changes to the abstaining from a vote
        public void AbstainChange(int loc)
        {
            EuCountries[loc].Position = CountryPosition.Abstain; 
        }
    }
}

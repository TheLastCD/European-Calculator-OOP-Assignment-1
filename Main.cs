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
        public Country[] EuCountries = new Country[File.ReadLines(@"ListOfCountries").Count()+1];
        public enum Majority_System
        {
            qual,
            rein,
            sim,
            unam,
        }
        public Majority_System vote_system = Majority_System.qual;
        (double, double)[] majsystem = new (double, double)[]
        {
            (0.55,0.65),(0.72,0.65),(0.5,0),(1,0)
        };
        
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

        public bool Member_States_Check(Majority_System Majority)
        {
            int votelocation = majoritychoose(Majority);
            var abstainer = from state in EuCountries
                            where state.Position.ToString() == "Abstain"
                            select state;
            var _for = from state in EuCountries
                            where state.Position.ToString() == "Yes"
                            select state;
            var against = from state in EuCountries
                            where state.Position.ToString() == "No"
                            select state;
            var NotParticpating = from state in EuCountries
                          where state.Position.ToString() == "Notparticpating"
                          select state;
            
            




        }
        public int majoritychoose(Majority_System Majority)
        {
            switch (Majority.ToString())
            {
                case "qual":
                    return 0;
                    break;
                case "rein":
                    return 1;
                    break;
                case "sim":
                    return 2;
                    break;
                case "unam":
                    return 3;
                    break;
                default:
                    return 0;
                    break;
            }
        }

    }
}

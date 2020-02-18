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
        public Majority_System vote_system;
        public int PopulationTotal = 0;

        
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
                int population;
                try
                {
                    population = Convert.ToInt32(countryAndPerc[1]);
                    PopulationTotal += population;
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

        public bool Member_States_Check(Majority_System Majority, int NotParticpating,int _for )
        {
            double votelocation = majoritychoose(Majority, true);
            int Pass_Mark = Convert.ToInt32(Math.Ceiling((EuCountries.Count() - NotParticpating* votelocation)));
            if (_for  >= Pass_Mark)
            {
                return true;
            }
            if (_for == EuCountries.Count()&& Majority.ToString() == "unam")
            {
                return true;
            }
            else
            {
                return false;
            }





        }
        public double majoritychoose(Majority_System Majority, bool iscountry)
        {
            switch (Majority.ToString())
            {
                case "qual":
                    if (iscountry)
                    {
                        return 0.55;
                    }
                    else
                    {
                        return 0.65;
                    }    
                case "rein":
                    if (iscountry)
                    {
                        return 0.72;
                    }
                    else
                    {
                        return 0.65;
                    }

                case "sim":
                    if (iscountry)
                    {
                        return 0.5;
                    }
                    else
                    {
                        return 0;
                    }

                case "unam":
                    if (iscountry)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }

                default:
                    return 0;
                    //[[0.55,0.65],[0.72,0.65],[0.5,0],[1,0]]
            }
        }
        public bool Population_Check(Majority_System Majority,double  _for )
        {
            double votelocation = majoritychoose(Majority, false);
            if (_for >= votelocation)
            {
                return true;
            }
            if (Majority.ToString() == "unam")
            {
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}

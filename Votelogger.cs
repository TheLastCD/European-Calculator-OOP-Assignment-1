using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace European_Calculator
{
    class Votelogger
    {
        //Instantiates the Country Structure into a list that is one longer than the total number of countries
        public Country[] EuCountries = new Country[File.ReadLines(@"ListOfCountries").Count() + 1];
        
        //establishes the enumerated list that is used to decide which voting majority is being
        public enum Majority_System
        {
            qual,
            rein,
            sim,
            unam,
        }
        public Majority_System vote_system;
        
        //the total population of the countries being accounted for written so that it adds to its existing value when the value is set
        private int _PopulationTotal = 0;
        public int PopulationTotal
        {
            get { return _PopulationTotal; }
            set
            {
                if (value >= 0)
                {
                    _PopulationTotal += value;
                }
                else
                {
                    _PopulationTotal = PopulationTotal;
                }
            }

        }


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
                    PopulationTotal = population;
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
            if (pos) VoteChoice = CountryPosition.Yes;
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



        // Method Name: Member_States_Check
        // Return: Bool
        // Purpose: To check if the number of member states voting yes surpasses the amount required to pass
        //          if so it returns True if not it returns False
        public bool Member_States_Check(Majority_System Majority, int NotParticipating,int _for )
        {
            double votelocation = Majority_Choose(Majority, true);
            int Pass_Mark = Convert.ToInt32(Math.Ceiling((double)(((EuCountries.Count()-1) - NotParticipating)* votelocation)));
            if (_for  >= Pass_Mark)
                return true;

            if (_for == EuCountries.Count() - 1 && Majority.ToString() == "unam") return true;
            else return false;
        }

      
        // Method Name: Population_Check
        // Return: Bool
        // Purpose: If the population surpasses the amount needed for the bill to pass
        //          the method returns true if not it returns false.
        internal bool Population_Check(Majority_System Majority,double  _for )
        {
            double votelocation = Majority_Choose(Majority, false);
            if (_for >= votelocation) return true;

            if (Majority.ToString() == "unam") return true;

            else return false;


        }

        // Method Name: Majority_Choose
        // Return: double
        // Purpose: To inform the Member_States_Check and the Population_Check method
        //          What percentage is required for them to pass
        public double Majority_Choose(Majority_System Majority, bool iscountry)
        {
            switch (Majority.ToString())
            {
                case "qual":
                    if (iscountry) return 0.55;
                    else return 0.65;
                case "rein":
                    if (iscountry) return 0.72;
                    else return 0.65;

                case "sim":
                    if (iscountry) return 0.5;
                    else return 0;

                case "unam":
                    if (iscountry) return 1;
                    else return 0;

                default:
                    return 0;
            }
        }



    }
}

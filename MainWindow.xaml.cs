using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace European_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //Methods containing lists for all the different clickboxes
        //These lists are used to find which checkbox was checked allowing me to
        //greatly decrease the number of methods required from around 81 to 10
        // while maintaining a BigO of O(n)
        Votelogger Initiate = new Votelogger();
        private CheckBox[] EUParticipants()
        {
            CheckBox[] particpants = new CheckBox[]
            {
                 AusPart, BelgPart, BulPart, CroPart, CypPart, CzePart, DenPart,
                 EstPart,FinPart,FraPart,GerPart,GrePart, HunPart, IrePart, ItaPart,
                 LatPart, LitPart, LuxPart, MalPart, NetPart, PolPart, PorPart, RomPart,
                 SloPart,SlovPart,SpaPart,SwePart
            };
            return particpants;
        }
        private CheckBox[] EUAbstain()
        {
            CheckBox[] Abstain = new CheckBox[]
            {
                 AusAb, BelgAb, BulAb, CroAb, CypAb, CzeAb, DenAb,
                 EstAb,FinAb,FraAb,GerAb,GreAb, HunAb, IreAb, ItaAb,
                 LatAb, LitAb, LuxAb, MalAb, NetAb, PolAb, PorAb, RomAb,
                 SloAb,SlovAb,SpaAb,SweAb
            };
            return Abstain;
        }
        private CheckBox[] EUVote()
        {
            CheckBox[] Vote = new CheckBox[]
            {
                 AusVote, BelgVote, BulVote, CroVote, CypVote, CzeVote, DenVote,
                 EstVote,FinVote,FraVote,GerVote,GreVote, HunVote, IreVote, ItaVote,
                 LatVote, LitVote, LuxVote, MalVote, NetVote, PolVote, PorVote, RomVote,
                 SloVote,SlovVote,SpaVote,SweVote
            };
            return Vote;
        }
        private CheckBox[] NotEuro()
        {
            CheckBox[] NonEuro = new CheckBox[]
            {

              BulPart,CroPart,CzePart,DenPart,HunPart,PolPart,RomPart,SwePart
            };
            return NonEuro;
        }
        
        //Initialize the main window for the UI
        public MainWindow()
        {
            InitializeComponent();
            Initiate.Create();
        }
        

        // Method Name: limit_Euro
        // Return: Void
        // Purpose: To uncheck all of the non eurozone countries
        private void limit_Euro(object sender, RoutedEventArgs e)
        {
            bool limit = true;
            if(Euro_Control.IsChecked == true)
            {
                limit = false;
            }
            foreach(CheckBox nonEUCountry in NotEuro())
            {
                nonEUCountry.IsChecked = limit;
                int loc = Array.IndexOf(EUParticipants(), nonEUCountry);
                EUAbstain()[loc].IsChecked = false;
                EUVote()[loc].IsChecked = limit;
            }
            Update_numbers();
        }

        // Method Name: Participation
        // Return: Void
        // Purpose: To control particpation, if participation is unchecked then vote or abstain is also unchecked
        private void Participaction(object sender, RoutedEventArgs e)
        {
            int count = 0;
            foreach(CheckBox country in EUParticipants())
            {
                bool join = true;
                if (country.IsChecked == false)
                {
                    join = false;
                }
                try
                {
                    if(country.IsChecked== false )
                    {
                        EUAbstain()[count].IsChecked = false;
                        EUVote()[count].IsChecked = join;
                        All_Part.IsChecked = false;
                    }
                    RemoveEurotag(country);
                    Update_numbers();
                    count++;
                }
                catch
                {
                    break;
                }
                
            }
            
        }

        // Method Name: Abstaining
        // Return: Void
        // Purpose: To control the abstain vote, if abstain is checked vote is unchecked
        //          If particpation is unchecked and abstain is checked then then participation will turn on
        private void Abstaining(object sender, RoutedEventArgs e)
        {
            int count = 0;
            foreach (CheckBox country in EUAbstain())
            {
                bool abs = false;
                if (country.IsChecked == true )
                {
                    abs = true;
                }
                try
                { 
                    
                    
                    if(EUParticipants()[count].IsChecked == !abs )
                    {
                        EUParticipants()[count].IsChecked = true;
                        RemoveEurotag(EUParticipants()[count]);
                    }
                    if(EUVote()[count].IsChecked == true)
                    {
                        EUVote()[count].IsChecked = !abs;
                        RemoveEurotag(EUParticipants()[count]);
                    }
                    Update_numbers();
                    count++;
                }
                catch
                {
                    break;
                }
            }
        }

        // Method Name: Voting
        // Return: Void
        // Purpose: Controls voting , if checked then abastain will be unchecked
         //         If particpation is unchecked and voting is checked then then participation will turn on
        private void Voting(object sender, RoutedEventArgs e)
        {
            int count = 0;
            foreach (CheckBox country in EUVote())
            {
                bool vot = false;
                if (country.IsChecked == true)
                {
                    vot = true;
                }
                try
                {
                    if (EUParticipants()[count].IsChecked == !vot)
                    {
                        EUParticipants()[count].IsChecked = true;
                        RemoveEurotag(EUParticipants()[count]);
                    }
                    if(EUAbstain()[count].IsChecked == vot)
                    {
                        EUAbstain()[count].IsChecked = false;
                    }
                    Update_numbers();
                    count++;
                }
                catch
                {
                    break;
                }
            }
        }

        // Method Name: Force_Part
        // Return: Void
        // Purpose: To force all countries to particpate
        private void Force_Part(object sender, RoutedEventArgs e)
        {
            foreach(CheckBox country in EUParticipants())
            {
                if (country.IsChecked == false)
                {
                    country.IsChecked = true;

                }
            }
        }


        // Method Name: RemoveEurotag
        // Return: Void
        // Purpose: Will uncheck the eurozone check box if one of the non euro zone section is checked while the filter is on
        private void RemoveEurotag(CheckBox country)
        {

            if (NotEuro().Contains(country))
            {
                Euro_Control.IsChecked = false;
                Update_numbers();
            }
        }
        

        // Method  Name: Update_numbers
        // Return: void
        // Purpose: This method is responsible for updating the number of countries particpating, voting yes, or voting no
        //          Updates live
        //          Purely visual but also triggers the methods that update the Country structure
        private void Update_numbers()
        {
            int count = 0,  countries_yes = EUParticipants().Count(), countries_no = 0, countries_abs = 0, total = EUParticipants().Count();
            foreach(CheckBox country in EUParticipants())
            {
                if (country.IsChecked == true && EUVote()[count].IsChecked == true)
                {
                    countries_no += 1;
                    countries_yes -= 1;
                    Initiate.VoteChange(count,true);

                }
                if(country.IsChecked == false)
                {
                    countries_yes -= 1;
                    total -= 1;
                    Initiate.PartispantChange(count);
                }
                if (country.IsChecked == true && EUVote()[count].IsChecked == false)
                {
                    Initiate.VoteChange(count, false);

                }
                if (country.IsChecked == true && EUAbstain()[count].IsChecked == true)
                {
                    countries_abs += 1;
                    countries_yes -= 1;
                    Initiate.AbstainChange(count);

                }

                Mem_No.Content = $"No: {countries_yes}";
                Mem_Yes.Content = $"Yes: {countries_no}";
                Mem_Abs.Content = $"Abstain: {countries_abs}";
                Mem_Total.Content = $"Total: {total}";
                count++;
            }
            Population_Stat_Updater();
        }

        // Method Name: Vote_Rule
        // Return: void
        // Purpose: This method takes note of what is selected in the voting rule drop down menu and updates an
        //          enumerated list to match the current selection 
        private void Vote_Rule(object sender, RoutedEventArgs e)
        {
            string VoteState = Voting_Rules.SelectedValue.ToString().ToLower();
            try
            {
                switch (VoteState.Remove(0, 38))
                {
                    case "qualified majority":
                        Initiate.vote_system = Votelogger.Majority_System.qual;
                        break;
                    case "reinforced qualified majority":
                        Initiate.vote_system = Votelogger.Majority_System.rein;
                        break;
                    case "simple majority":
                        Initiate.vote_system = Votelogger.Majority_System.sim;
                        break;
                    case "unanamity":
                        Initiate.vote_system = Votelogger.Majority_System.unam;
                        break;
                    default:
                        break;
                }
                Update_numbers();
            }
            catch
            {

            }

        }

        // Method Name: If_Pass
        // Return: void
        // Purpose: This method acts as an AND gate if the population and number of member states is high enough
        //          it modifies the text to say if the bill has passed or not
        private void If_Pass(double percfor)
        {
            var countfor = from state in Initiate.EuCountries
                       where state.Position.ToString() == "Yes"
                       select state;
            var Notparticipating = from state in Initiate.EuCountries
                                  where state.Position.ToString() == "Notparticpating"
                                  select state;
            Mem_Pass.Content = $"Member States to Pass: {Convert.ToInt32(Math.Ceiling((double)(((Initiate.EuCountries.Count() - 1) - Notparticipating.Count()) * Initiate.Majority_Choose(Initiate.vote_system,true))))}";
            if (Initiate.Population_Check(Initiate.vote_system, percfor) && Initiate.Member_States_Check(Initiate.vote_system, Notparticipating.Count(), countfor.Count()-1))
                Pass_Marker.Content = "Approved";
            else
                Pass_Marker.Content = "Denied";
        }

        // Method Name: Population_Stat_Updater
        // Return: void
        // Purpose: To collect all of the population data and not only output to the UI the population figures rounded to 2DP
        //          It also triggers the If_Pass method to decide if the bill passes.
        private void Population_Stat_Updater()
        {
            int countYe=0, countNo=0, countAbs=0, countNotParc= 0;
            foreach (var State in Initiate.EuCountries)
            {

                switch (State.Position.ToString())
                {
                    case "Yes":
                        countYe += State.Population;
                        break;
                    case "No":
                        countNo += State.Population;
                        break;
                    case "Abstain":
                        countAbs += State.Population;
                        break;
                    case "Notparticpating":
                        countNotParc += State.Population;
                        break;
                    default:
                        break;
                }
                //totalPercentage += Math.Round((double)(ParticpatingCountry / PercentageParticpating), 2);
            }
            double PercentageParticpating = Convert.ToInt32(Initiate.PopulationTotal- countNotParc);
            double PercYes =  Math.Round((double)(100*(countYe / PercentageParticpating)), 2), 
                PercNo = Math.Round((double)(100*(countNo / PercentageParticpating)),2), 
                Percabs = Math.Round((double)(100*(countAbs / PercentageParticpating)),2);
            If_Pass(Math.Round((double)(countYe / PercentageParticpating), 2));
            Pop_Yes.Content = $"Yes: {PercYes}%";
            Pop_No.Content = $"No: {PercNo}%";
            Pop_Abs.Content = $"Abstain: {Percabs}%";
            Pop_Pass.Content = $"Population to Pass: {Initiate.Majority_Choose(Initiate.vote_system, false)*100}%";
            

        }

    }
}

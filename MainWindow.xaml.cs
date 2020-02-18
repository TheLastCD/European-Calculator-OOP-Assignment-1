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
        Main Initiate = new Main();
        public CheckBox[] EUParticipants()
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
        public CheckBox[] EUAbstain()
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
        public CheckBox[] EUVote()
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
        public CheckBox[] NotEuro()
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
            
            Initiate.Create();
            InitializeComponent();
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
        }

        private void Vote_Rule(object sender, RoutedEventArgs e)
        {
            string VoteState = Voting_Rules.SelectedValue.ToString().ToLower();
            try
            {
                switch (VoteState.Remove(0, 38))
                {
                    case "qualified majority":
                        Initiate.vote_system = Main.Majority_System.qual;
                        break;
                    case "reinforced qualified majority":
                        Initiate.vote_system = Main.Majority_System.rein;
                        break;
                    case "simple majority":
                        Initiate.vote_system = Main.Majority_System.sim;
                        break;
                    case "unanamity":
                        Initiate.vote_system = Main.Majority_System.unam;
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

    }
}

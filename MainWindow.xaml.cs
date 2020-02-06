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

        //Methods containing lists for all the different clickboxs
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
            InitializeComponent();
        }
       
        //checkbox methods
        //currently needs attachments to main code
        

        // Method Name: limit_Euro
        // Return: Void
        // Purpose: To uncheck all of the non eurozone countries and
        private void limit_Euro(object sender, RoutedEventArgs e)
        {
            bool limit = true;
            if(Euro_Control.IsChecked == true)
            {
                limit = false;
            }
            CheckBox[] participants = EUParticipants(), abstain = EUAbstain(), vote = EUVote(), NonEuro = NotEuro();
            foreach(CheckBox nonEUCountry in NonEuro)
            {
                nonEUCountry.IsChecked = limit;
                int loc = Array.IndexOf(participants, nonEUCountry);
                abstain[loc].IsChecked = false;
                vote[loc].IsChecked = limit;
            }
        }

        // Method Name: Participation
        // Return: Void
        // Purpose: To control particpation, if participation is unchecked then vote or abstain is also unchecked
        private void Participaction(object sender, RoutedEventArgs e)
        {
            int count = 0;
            CheckBox[] participants = EUParticipants(),abstain = EUAbstain(), vote = EUVote();
            foreach(CheckBox country in participants)
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
                        abstain[count].IsChecked = false;
                        vote[count].IsChecked = join;
                    }
                    RemoveEurotag(country);
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
            CheckBox[] participants = EUParticipants(), abstain = EUAbstain(), vote = EUVote();
            foreach (CheckBox country in abstain)
            {
                bool abs = false;
                if (country.IsChecked == true )
                {
                    abs = true;
                }
                try
                { 
                    
                    
                    if(participants[count].IsChecked == !abs )
                    {
                        participants[count].IsChecked = true;
                        RemoveEurotag(participants[count]);
                    }
                    if(vote[count].IsChecked == true)
                    {
                        vote[count].IsChecked = !abs;
                        RemoveEurotag(participants[count]);
                    }
                    
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
            CheckBox[] participants = EUParticipants(), vote = EUVote(), Abstain = EUAbstain();
            foreach (CheckBox country in vote)
            {
                bool vot = false;
                if (country.IsChecked == true)
                {
                    vot = true;
                }
                try
                {
                    if (participants[count].IsChecked == !vot)
                    {
                        participants[count].IsChecked = true;
                        RemoveEurotag(participants[count]);
                    }
                    if(Abstain[count].IsChecked == vot)
                    {
                        Abstain[count].IsChecked = false;
                    }
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
            CheckBox[] nonEuro = NotEuro();
            if (nonEuro.Contains(country))
            {
                Euro_Control.IsChecked = false;
            }
        }

        private void Update_numbers(object sender, RoutedEventArgs e)
        {
            int count = 0,  countries_yes = 27, countries_no = 0, countries_abs = 0;
            CheckBox[] participants = EUParticipants(), vote = EUVote(), Abstain = EUAbstain();
            foreach(CheckBox country in participants)
            {
                if (country.IsChecked == true && vote[count].IsChecked == true)
                {
                    countries_no += 1;
                    countries_yes -= 1;

                }
                if (country.IsChecked == true && Abstain[count].IsChecked == true)
                {
                    countries_abs += 1;
                    countries_yes -= 1;
                }
                if(country.IsChecked == false)
                {
                    countries_yes -= 1;
                }
                Mem_No.Content = $"No: {countries_yes}";
                Mem_Yes.Content = $"Yes: {countries_no}";
                Mem_Abs.Content = $"Abstain: {countries_abs}";
                count++;
            }
        }

    }
}

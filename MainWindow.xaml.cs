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
        public MainWindow()
        {
            InitializeComponent();
        }
       
        private void x(object sender, RoutedEventArgs e)
        {
            
        }
        private void limit_Euro(object sender, RoutedEventArgs e)
        {
            bool limit = true;
            if(Euro_Control.IsChecked == true)
            {
                limit = false;
            }
            CheckBox[] participants = EUParticipants(),abstain = EUAbstain(), vote = EUVote(), NonEuro = new CheckBox[]
            {
                BulPart,CroPart,CzePart,DenPart,HunPart,PolPart,RomPart,SwePart
            };
            foreach(CheckBox nonEUCountry in NonEuro)
            {
                nonEUCountry.IsChecked = limit;
                int loc = Array.IndexOf(participants, nonEUCountry);
                abstain[loc].IsChecked = false;
                vote[loc].IsChecked = limit;
            }
        }
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
                    abstain[count].IsChecked = false;
                    vote[count].IsChecked = join;
                    count++;
                }
                catch
                {
                    break;
                }
                
            }
            
        }
        private void Abstaining(object sender, RoutedEventArgs e)
        {
            int count = 0;
            CheckBox[] participants = EUParticipants(), abstain = EUAbstain(), vote = EUVote();
            foreach (CheckBox country in abstain)
            {
                bool abs = false;
                if (country.IsChecked == true)
                {
                    abs = true;
                }
                try
                {

                    vote[count].IsChecked = !abs;
                    if(participants[count].IsChecked == false)
                    {
                        participants[count].IsChecked = true;
                    }
                    count++;
                }
                catch
                {
                    break;
                }
            }
        }
        private void Voting(object sender, RoutedEventArgs e)
        {
            int count = 0;
            CheckBox[] participants = EUParticipants(), abstain = EUAbstain(), vote = EUVote();
            foreach (CheckBox country in vote)
            {
                bool abs = false;
                if (country.IsChecked == true)
                {
                    abs = true;
                }
                try
                {

                    abstain[count].IsChecked = !abs;
                    if (participants[count].IsChecked == false)
                    {
                        participants[count].IsChecked = true;
                    }
                    count++;
                }
                catch
                {
                    break;
                }
            }
        }


    }
}

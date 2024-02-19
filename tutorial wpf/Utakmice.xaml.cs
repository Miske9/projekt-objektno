using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace tutorial_wpf
{
    /// <summary>
    /// Interaction logic for Utakmice.xaml
    /// </summary>
    public partial class Utakmice : Page
    {
        public Utakmice()
        {
            DataContext = new UtakmiceViewModel();
            InitializeComponent();
        }
        public void OnMatchSelect(object sender, EventArgs e)
        {
            if (sender is ListBox listBox && listBox.SelectedItem != null)
            {
                Match selectedMatch = listBox.SelectedItem as Match;
                detaljiOutakmici detalji2Page = new detaljiOutakmici(selectedMatch);

                this.NavigationService.Navigate(detalji2Page);
            }
        }
    }
    public class UtakmiceViewModel
        {
            public ObservableCollection<Match> Matches { get; set; }
            public UtakmiceViewModel()
            {
                Matches = new ObservableCollection<Match>();
                FootballClub myClub = new FootballClub("Smoljanci Sloboda", 344000);

                Match match1 = new Match(myClub.Name, "Real", "Stadion Suhača", "Master Liga");
                Match match2 = new Match(myClub.Name, "PSG", "Stadion Suhača", "Master Liga");
                Match match3 = new Match(myClub.Name, "BVB", "Stadion Suhača", "Master Liga");
                Match match4 = new Match(myClub.Name, "Dinamo", "Stadion Suhača", "Master Liga");
                Match match5 = new Match(myClub.Name, "Inter", "Stadion Suhača", "Master Liga");
                Match match6 = new Match(myClub.Name, "Milan", "Stadion Suhača", "Master Liga");
                Match match7 = new Match(myClub.Name, "Manchester United", "Stadion Suhača", "Master Liga");
                Match match8 = new Match(myClub.Name, "Lyon", "Stadion Suhača", "Master Liga");
                Match match9 = new Match(myClub.Name, "Al Nassr", "Stadion Suhača", "Master Liga");
                Match match10 = new Match(myClub.Name, "Coventry", "Stadion Suhača", "Master Liga");
                Match match11 = new Match(myClub.Name, "Real", "Stadion Suhača", "Master Liga");
                Match match12 = new Match(myClub.Name, "PSG", "Stadion Suhača", "Master Liga");
                Match match13 = new Match(myClub.Name, "BVB", "Stadion Suhača", "Master Liga");
                Match match14 = new Match(myClub.Name, "Dinamo", "Stadion Suhača", "Master Liga");
                Match match15 = new Match(myClub.Name, "Inter", "Stadion Suhača", "Master Liga");
                Match match16 = new Match(myClub.Name, "Milan", "Stadion Suhača", "Master Liga");
                Match match17 = new Match(myClub.Name, "Machester United", "Stadion Suhača", "Master Liga");
                Match match18 = new Match(myClub.Name, "Lyon", "Stadion Suhača", "Master Liga");
                Match match19 = new Match(myClub.Name, "Al Nassr", "Stadion Suhača", "Master Liga");
                Match match20 = new Match(myClub.Name, "Coventry", "Stadion Suhača", "Master Liga");
                myClub.ScheduleMatch(match1);
                myClub.ScheduleMatch(match2);
                myClub.ScheduleMatch(match3);
                myClub.ScheduleMatch(match4);
                myClub.ScheduleMatch(match5);
                myClub.ScheduleMatch(match6);
                myClub.ScheduleMatch(match7);
                myClub.ScheduleMatch(match8);
                myClub.ScheduleMatch(match9);
                myClub.ScheduleMatch(match10);
                myClub.ScheduleMatch(match11);
                myClub.ScheduleMatch(match12);
                myClub.ScheduleMatch(match13);
                myClub.ScheduleMatch(match14);
                myClub.ScheduleMatch(match15);
                myClub.ScheduleMatch(match16);
                myClub.ScheduleMatch(match17);
                myClub.ScheduleMatch(match18);
                myClub.ScheduleMatch(match19);
                myClub.ScheduleMatch(match20);

                myClub.RecordMatchResult(match1, 2, 1);
                myClub.RecordMatchResult(match2, 2, 1);
                myClub.RecordMatchResult(match3, 4, 0);
                myClub.RecordMatchResult(match4, 1, 1);
                myClub.RecordMatchResult(match5, 3, 2);
                myClub.RecordMatchResult(match6, 1, 0);
                myClub.RecordMatchResult(match7, 2, 0);
                myClub.RecordMatchResult(match8, 3, 1);
                myClub.RecordMatchResult(match9, 2, 1);
                myClub.RecordMatchResult(match10, 4, 1);
                myClub.RecordMatchResult(match11, 1, 0);
                myClub.RecordMatchResult(match12, 4, 3);
                myClub.RecordMatchResult(match13, 5, 0);
                myClub.RecordMatchResult(match14, 0, 1);
                myClub.RecordMatchResult(match15, 3, 1);
                myClub.RecordMatchResult(match16, 2, 1);
                myClub.RecordMatchResult(match17, 2, 0);
                myClub.RecordMatchResult(match18, 4, 2);
                myClub.RecordMatchResult(match19, 2, 1);
                myClub.RecordMatchResult(match20, 5, 0);

                myClub.Strijelci(match1, "Andi, Klasnić", "Modrić");
                myClub.Strijelci(match2, "Simon, Klasnić", "Mbappe");
                myClub.Strijelci(match3, "Simon, Andi, Andi, Andi", " ");
                myClub.Strijelci(match4, "Mirko", "Petković");
                myClub.Strijelci(match5, "Simon, Klasnić, Simon", "Lautaro, Lautaro");
                myClub.Strijelci(match6, "Drvo", " ");
                myClub.Strijelci(match7, "Simon, Klasnić", " ");
                myClub.Strijelci(match8, "Simon, Klasnić, Andi", "Lovren");
                myClub.Strijelci(match9, "Simon, Klasnić", "Ronaldo");
                myClub.Strijelci(match10, "Simon, Klasnić", "Wilson");
                myClub.Strijelci(match11, "Andi", " ");
                myClub.Strijelci(match12, "Simon, Klasnić, Andi, Mićula", "Mbappe, Mbappe, Mbappe");
                myClub.Strijelci(match13, "Simon, Klasnić, Drvo, Drvo, Drvo", " ");
                myClub.Strijelci(match14, " ", "Baturina");
                myClub.Strijelci(match15, "Andi, Drvo, Mirko", "Lautaro");
                myClub.Strijelci(match16, "Mirko, Klasnić", "Leao");
                myClub.Strijelci(match17, "Andi, Drvo", " ");
                myClub.Strijelci(match18, "Andi, Andi, Mirko, Mirko", "Lacazette,Lovren");
                myClub.Strijelci(match19, "Simon, Klasnić", "Ronaldo");
                myClub.Strijelci(match20, "Simon, Klasnić, Drvo, Andi, Mirko", " ");

                Matches.Add(match1);
                Matches.Add(match2);
                Matches.Add(match3);
                Matches.Add(match4);
                Matches.Add(match5);
                Matches.Add(match6);
                Matches.Add(match7);
                Matches.Add(match8);
                Matches.Add(match9);
                Matches.Add(match10);
                Matches.Add(match11);
                Matches.Add(match12);
                Matches.Add(match13);
                Matches.Add(match14);
                Matches.Add(match15);
                Matches.Add(match16);
                Matches.Add(match17);
                Matches.Add(match18);
                Matches.Add(match19);
                Matches.Add(match20);
            }
        }
}

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

                Match match1 = new Match(myClub.Name, "Bilbao", "Stadion Suhača", "Champions League");
                Match match2 = new Match(myClub.Name, "PSG", "Stadion Suhača", "Liga");
                myClub.ScheduleMatch(match1);
                myClub.ScheduleMatch(match2);

                myClub.RecordMatchResult(match1, 2, 1);
                myClub.RecordMatchResult(match2, 1, 1);

                myClub.Strijelci(match1, "andi, Kluo", "indi");
                myClub.Strijelci(match2, "Simon", "Klaun");

                Matches.Add(match1);
                Matches.Add(match2);
            }
        }
}

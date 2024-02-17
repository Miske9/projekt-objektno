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
        public class UtakmiceViewModel
        {
            public ObservableCollection<Player> Matches { get; set; }
            public UtakmiceViewModel()
            {
                Matches = new ObservableCollection<Player>();
                FootballClub myClub = new FootballClub("Barecelona", 1000);
                FootballClub newClub = new FootballClub("Real Madrid", 1000);

                Match match1 = new Match("Bilbao", "Domaća", "Prijateljska");
                Match match2 = new Match("PSG", "Gostujuća", "Liga");
                myClub.ScheduleMatch(match1);
                myClub.ScheduleMatch(match2);

                myClub.RecordMatchResult(match1, 2, 1);
                myClub.RecordMatchResult(match2, 1, 1);

                Console.WriteLine("Izvještaj o klubu: " + myClub.Name);

                Console.WriteLine("\nRaspored utakmica:");
                foreach (Match match in myClub.Matches)
                {
                    Console.WriteLine(match.ToString());
                }
            }
        }
    }
}

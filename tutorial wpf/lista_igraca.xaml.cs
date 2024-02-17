using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;

namespace tutorial_wpf
{
    public partial class lista_igraca : Page
    {
        public lista_igraca()
        {
            DataContext = new ListaIgracaViewModel();
            InitializeComponent();
        }
    }

    public class ListaIgracaViewModel
    {
        public ObservableCollection<Player> Players { get; set; }

        public ListaIgracaViewModel()
        {
            Players = new ObservableCollection<Player>();
            FootballClub myClub = new FootballClub("Barecelona", 1000);
            FootballClub newClub = new FootballClub("Real Madrid", 1000);

            Player player1 = new Player("Messi", 10, "Napadač", 100);
            Player player2 = new Player("Ronaldo", 7, "Vezni", 200);

            myClub.AddPlayer(player1);
            newClub.AddPlayer(player2);

            Players.Add(player1);
            Players.Add(player2);
        }
    }
}

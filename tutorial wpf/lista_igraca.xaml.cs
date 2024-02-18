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

        public void OnPlayerSelect(object sender, EventArgs e)
        {
            if (sender is ListBox listBox && listBox.SelectedItem != null)
            {
                Player selectedPlayer = listBox.SelectedItem as Player;
                Detalji_o_Igracu detaljiPage = new Detalji_o_Igracu(selectedPlayer);

                this.NavigationService.Navigate(detaljiPage);
            }
        }
    }

    public class ListaIgracaViewModel
    {
        public ObservableCollection<Player> Players { get; set; }

        public ListaIgracaViewModel()
        {
            Players = new ObservableCollection<Player>();
            FootballClub myClub = new FootballClub("Barecelona", 33);
            FootballClub newClub = new FootballClub("Real Madrid", 2);

            Player player1 = new Player("Paulo", 10,"Senior", "Napadač", 33);
            Player player2 = new Player("Kaneko", 7,"Junior", "Vezni", 23);

            myClub.AddPlayer(player1);
            newClub.AddPlayer(player2);

            Players.Add(player1);
            Players.Add(player2);
        }
    }
}

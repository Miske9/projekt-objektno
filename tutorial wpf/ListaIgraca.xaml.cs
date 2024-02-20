using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;
using Microsoft.EntityFrameworkCore;
namespace tutorial_wpf
{
    public partial class ListaIgraca : Page
    {
        private readonly FootballDbContext _context = new FootballDbContext();
        private CollectionViewSource playersViewSource;
        public ListaIgraca()
        {
            InitializeComponent();
            playersViewSource =
        (CollectionViewSource)FindResource(nameof(playersViewSource));
        }
        List<Player> playersTemp;
        Player newPlayer;
        //imamo samo jedan klub
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Database.EnsureCreated();
            _context.Players.Load();
            //DODAVANJE NOVOG IGRACA U DATABAZU
            //int age = 12;
            //newPlayer = new Player("TIGUAL", age, age <= 11 ? "Škola Nogometa" : age < 16 ? "Pionir" : age <= 18 ? "Junior" : age <= 65 ? "Senior" : "Veteran", "napadac", 39, 3, 3);
            //newPlayer = new Player("Manye", age, age <= 11 ? "Škola Nogometa" : age < 16 ? "Pionir" : age <= 18 ? "Junior" : age <= 65 ? "Senior" : "Veteran", "napadac", 39, 3, 3);
            //newPlayer = new Player("asdasda", age, age <= 11 ? "Škola Nogometa" : age < 16 ? "Pionir" : age <= 18 ? "Junior" : age <= 65 ? "Senior" : "Veteran", "napadac", 39, 3, 3);
            //newPlayer = new Player("Matija", age, age <= 11 ? "Škola Nogometa" : age < 16 ? "Pionir" : age <= 18 ? "Junior" : age <= 65 ? "Senior" : "Veteran", "napadac", 39, 3, 3);
            //newPlayer = new Player("David", age, age <= 11 ? "Škola Nogometa" : age < 16 ? "Pionir" : age <= 18 ? "Junior" : age <= 65 ? "Senior" : "Veteran", "napadac", 39, 3, 3);
            //newPlayer = new Player("Nez ki js", age, age <= 11 ? "Škola Nogometa" : age < 16 ? "Pionir" : age <= 18 ? "Junior" : age <= 65 ? "Senior" : "Veteran", "napadac", 39, 3, 3);
            //_context.Players.Add(newPlayer);
            //playersTemp = _context.Players.Local.ToList();
            //AddPlayer(newPlayer);
            //_context.FootballClubs.Add(club);
            //TransferPlayerToClub(newPlayer);
            //_context.SaveChanges();
            playersViewSource.Source = _context.Players.Local.ToList();
            playersViewSource.View.Refresh();
        }
        public void TransferPlayerToClub(Player player)
        {
            Player transferPlayer = playersTemp.First(p => p.Name == newPlayer.Name);
            transferPlayer.TransferToClub(_context.FootballClubs.First(), 100);
            _context.FootballClubs.First().AddPlayer(player);
        }
        private void AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            AddPlayerButton.Visibility = Visibility.Collapsed;
            addPlayerForm.Visibility = Visibility.Visible;
        }
        private void SavePlayer_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "" || txtAge.Text == "" || txtMarketValue.Text == "" || txtPosition.Text == "") return;
            string name = txtName.Text;
            int age = int.Parse(txtAge.Text);
            string category = age <= 11 ? "Škola Nogometa" : age < 16 ? "Pionir" : age <= 18 ? "Junior" : age <= 65 ? "Senior" : "Veteran"; // Determine category based on age
            string position = txtPosition.Text;
            int marketValue = int.Parse(txtMarketValue.Text);
            newPlayer = new Player(name, age, category, position, marketValue, 0, 0);
            txtName.Text = "";
            txtAge.Text = "";
            txtPosition.Text = "";
            txtMarketValue.Text = "";
            _context.Players.Add(newPlayer);
            playersTemp = _context.Players.Local.ToList();
            //_context.FootballClubs.Add(club);
            TransferPlayerToClub(newPlayer);
            _context.SaveChanges();
            addPlayerForm.Visibility = Visibility.Collapsed;
            AddPlayerButton.Visibility = Visibility.Visible;
            playersViewSource.Source = _context.Players.Local.ToList();
        }
        private void RemovePlayer_Click(object sender, RoutedEventArgs e)
        {
            if (playersViewSource.View.CurrentItem != null)
            {
                Player selectedPlayer = (Player)playersViewSource.View.CurrentItem;
                var indInDb = _context.Players.First(p => p.Name == selectedPlayer.Name);
                _context.Players.Remove(indInDb);
                _context.SaveChanges();
                playersViewSource.Source = _context.Players.Local.ToList();
            }
        }
        public void OnPlayerSelect(object sender, EventArgs e)
        {
            if (sender is ListView ListView && ListView.SelectedItem != null)
            {
                Player selectedPlayer = ListView.SelectedItem as Player;
                DetaljiOIgracu detaljiPage = new DetaljiOIgracu(selectedPlayer);
                this.NavigationService.Navigate(detaljiPage);
            }
        }
    }
}
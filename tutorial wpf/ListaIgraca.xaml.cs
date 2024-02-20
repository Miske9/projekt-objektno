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
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Database.EnsureCreated();
            _context.Players.Load();

            playersViewSource.Source = _context.FootballClubs.First().Players.ToList();
            playersViewSource.View.Refresh();
        }
        private void AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            AddPlayerButton.Visibility = Visibility.Collapsed;
            addPlayerForm.Visibility = Visibility.Visible;
        }
        private void SavePlayer_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPosition.Text) || string.IsNullOrEmpty(txtAge.Text) || string.IsNullOrEmpty(txtMarketValue.Text))
            {
                MessageBox.Show("Molimo popunite sva polja.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            int age, marketValue;
            if (!int.TryParse(txtAge.Text, out age) || !int.TryParse(txtMarketValue.Text, out marketValue))
            {
                MessageBox.Show("Godine i vrijednost na tržištu trebaju biti cijeli brojevi.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            string name = txtName.Text;
            age = int.Parse(txtAge.Text);
            string category = age <= 11 ? "Škola Nogometa" : age < 16 ? "Pionir" : age <= 18 ? "Junior" : age <= 65 ? "Senior" : "Veteran";
            string position = txtPosition.Text;
            marketValue = int.Parse(txtMarketValue.Text);
            newPlayer = new Player(name, age, category, position, marketValue, 0, 0);
            txtName.Text = "";
            txtAge.Text = "";
            txtPosition.Text = "";
            txtMarketValue.Text = "";
            _context.Players.Add(newPlayer);
            _context.FootballClubs.First().Players.Add(newPlayer);
            _context.SaveChanges();
            addPlayerForm.Visibility = Visibility.Collapsed;
            AddPlayerButton.Visibility = Visibility.Visible;
            playersViewSource.Source = _context.FootballClubs.First().Players.ToList();
        }
        private void RemovePlayer_Click(object sender, RoutedEventArgs e)
        {
            if (playersViewSource.View.CurrentItem != null)
            {
                var button = sender as Button;
                if (button != null)
                {
                    var player = button.DataContext as Player;
                    if (player != null)
                    {
                        var tempClub = player.CurrentClub;
                        player.CurrentClub = null;
                        _context.SaveChanges();
                        playersViewSource.Source = tempClub.Players.ToList();
                    }
                }
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
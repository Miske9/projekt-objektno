using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;

namespace tutorial_wpf
{
    public partial class lista_igraca : Page
    {
        private readonly FootballDbContext _context = new FootballDbContext();
        private CollectionViewSource playersViewSource;


        public lista_igraca()
        {
            InitializeComponent();
            playersViewSource =
    (CollectionViewSource)FindResource(nameof(playersViewSource));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Database.EnsureCreated();
            _context.Players.Add(new Player("Ronaldo", 10, "Senior", "Real Madrid", 100));
            _context.SaveChanges();
            playersViewSource.Source = _context.Players.Local.ToObservableCollection();
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

}

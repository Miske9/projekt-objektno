using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Navigation;

namespace tutorial_wpf
{
    public partial class MainWindow : NavigationWindow
    {

        FootballDbContext _context = new FootballDbContext();
        private CollectionViewSource playersViewSource;
        private CollectionViewSource matchesViewSource;
        private CollectionViewSource footballClubsViewSource;
        public MainWindow()
        {
            InitializeComponent();
            playersViewSource = (CollectionViewSource)FindResource(nameof(playersViewSource));
            matchesViewSource = (CollectionViewSource)FindResource(nameof(matchesViewSource));
            footballClubsViewSource = (CollectionViewSource)FindResource(nameof(footballClubsViewSource));
        }

        public void Window_Load(object sender, RoutedEventArgs e)
        {
            _context.Database.EnsureCreated();

            _context.Players.Load();
            _context.FootballClubs.Load();
            _context.Matches.Load();

            playersViewSource.Source = _context.Players.Local.ToObservableCollection();
            matchesViewSource.Source = _context.Matches.Local.ToObservableCollection();
            footballClubsViewSource.Source = _context.FootballClubs.Local.ToObservableCollection();
        }
        protected override void OnClosed(EventArgs args)
        {
            _context.Dispose();
            base.OnClosed(args);
        }
    }
}
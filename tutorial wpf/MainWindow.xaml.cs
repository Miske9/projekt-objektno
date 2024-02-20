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
            //_context.FootballClubs.Add(new FootballClub("Smoljanci Sloboda", 100, 1, 8, 1, 0));
            //_context.FootballClubs.Add(new FootballClub("Real Madrid", 300, 2, 7, 1, 1));
            //_context.FootballClubs.Add(new FootballClub("Milan", 200, 3, 6, 2, 1));
            //_context.FootballClubs.Add(new FootballClub("BVB", 150, 4, 6, 0, 3));
            //_context.FootballClubs.Add(new FootballClub("Inter", 200, 5, 5, 2, 2));
            //_context.FootballClubs.Add(new FootballClub("Coventry", 80, 6, 4, 2, 3));
            //_context.FootballClubs.Add(new FootballClub("Lecce", 90, 7, 3, 3, 3));
            //_context.FootballClubs.Add(new FootballClub("Monza", 120, 8, 2, 2, 5));
            //_context.FootballClubs.Add(new FootballClub("Genoa", 140, 9, 1, 3, 5));
            //_context.SaveChanges();

            _context.Matches.Load();

            //Match match = new Match(_context.FootballClubs.First(), _context.FootballClubs.Local.ToList()[1], "Stadion ", "Champions League");
            //match.RecordResult(1, 2, "Rodrygo", "Mirko, Mero");
            //_context.Matches.Add(match);
            //_context.SaveChanges();

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
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace tutorial_wpf
{
    public partial class Tablica : Page
    {
        private readonly FootballDbContext _context = new FootballDbContext();
        private CollectionViewSource footballClubsViewSource;

        public Tablica()
        {
            InitializeComponent();
            footballClubsViewSource = (CollectionViewSource)FindResource(nameof(footballClubsViewSource));
        }

        public void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Database.EnsureCreated();
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

            footballClubsViewSource.Source = _context.FootballClubs.Local.ToList();
        }
    }
}

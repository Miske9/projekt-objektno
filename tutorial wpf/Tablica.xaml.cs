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

            //_context.FootballClubs.Add(new FootballClub("Somljanci Sloboda", 100, 1, 10, 0, 0));
            //_context.FootballClubs.Add(new FootballClub("Somljanci Sloboda", 100, 2, 10, 0, 0));
            //_context.FootballClubs.Add(new FootballClub("Somljanci Sloboda", 100, 3, 10, 0, 0));
            //_context.FootballClubs.Add(new FootballClub("Somljanci Sloboda", 100, 4, 10, 0, 0));
            //_context.FootballClubs.Add(new FootballClub("Somljanci Sloboda", 100, 5, 10, 0, 0));
            //_context.FootballClubs.Add(new FootballClub("Somljanci Sloboda", 100, 6, 10, 0, 0));
            //_context.FootballClubs.Add(new FootballClub("Somljanci Sloboda", 100, 7, 10, 0, 0));
            //_context.FootballClubs.Add(new FootballClub("Somljanci Sloboda", 100, 8, 10, 0, 0));
            //_context.FootballClubs.Add(new FootballClub("Somljanci Sloboda", 100, 9, 10, 0, 0));

            //_context.SaveChanges();

            footballClubsViewSource.Source = _context.FootballClubs.Local.ToList();
        }
    }
}

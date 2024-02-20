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
            footballClubsViewSource.Source = _context.FootballClubs.Local.ToList();
        }
    }
}

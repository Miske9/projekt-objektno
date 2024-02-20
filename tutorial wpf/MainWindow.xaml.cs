using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Xml.Linq;

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

            //======================================================
            // ODKOMENTIRAJ DO KRAJA BLOKA ZA DODAVALJE PODATAKA U DB
            //======================================================

            //AKO SE OVO RADI TREBA SE IZBRISATI football.db FILE I POKRENI OVO SAMO JEDANPUT!!!

            //_context.FootballClubs.Add(new FootballClub("Smoljanci Sloboda", 100000, 1, 8, 1, 0));
            //_context.FootballClubs.Add(new FootballClub("Real Madrid", 300, 2, 7, 1, 1));
            //_context.FootballClubs.Add(new FootballClub("Milan", 200, 3, 6, 2, 1));
            //_context.FootballClubs.Add(new FootballClub("BVB", 150, 4, 6, 0, 3));
            //_context.FootballClubs.Add(new FootballClub("Inter", 200, 5, 5, 2, 2));
            //_context.FootballClubs.Add(new FootballClub("Coventry", 80, 6, 4, 2, 3));
            //_context.FootballClubs.Add(new FootballClub("Lecce", 90, 7, 3, 3, 3));
            //_context.FootballClubs.Add(new FootballClub("Monza", 120, 8, 2, 2, 5));
            //_context.FootballClubs.Add(new FootballClub("Genoa", 140, 9, 1, 3, 5));
            //_context.SaveChanges();

            //TransferPlayerToClub(new Player("Matija", 20, "senior", "napadac", 333, 1, 0), _context.FootballClubs.First(), 100);
            //TransferPlayerToClub(new Player("Mateo", 26, "senior", "napadac", 12, 0, 2), _context.FootballClubs.First(), 150);
            //TransferPlayerToClub(new Player("Ivan", 65, "veteran", "napadac", 333, 4, 0), _context.FootballClubs.First(), 200);
            //TransferPlayerToClub(new Player("Luka", 12, "pionir", "golamn", 234, 0, 12), _context.FootballClubs.First(), 120);
            //TransferPlayerToClub(new Player("David", 43, "senior", "obrana", 333, 0, 0), _context.FootballClubs.First(), 180);
            //TransferPlayerToClub(new Player("Martin", 30, "senior", "napadac", 356, 345, 0), _context.FootballClubs.First(), 250);
            //TransferPlayerToClub(new Player("Patrik", 33, "senior", "obrana", 234, 0, 0), _context.FootballClubs.First(), 300);
            //TransferPlayerToClub(new Player("Dalibor", 27, "senior", "vezni", 3, 0, 5), _context.FootballClubs.First(), 180);
            //TransferPlayerToClub(new Player("Daniel", 15, "junior", "bocni", 5, 0, 4), _context.FootballClubs.First(), 150);
            //TransferPlayerToClub(new Player("Toni", 18, "junior", "napadac", 32, 0, 0), _context.FootballClubs.First(), 200);


            //Match match1 = new Match(_context.FootballClubs.First(),
            //_context.FootballClubs.Local.ToList()[2], "Stadion Suhača", "Champions League");
            //match1.RecordResult(1, 1, _context.Players.Local.ToList()[3],
            //_context.Players.Local.ToList()[1]);
            //Match match2 = new Match(_context.FootballClubs.First(),
            //_context.FootballClubs.Local.ToList()[3], "Stadion Suhača", "Champions League");
            //match2.RecordResult(1, 0, _context.Players.Local.ToList()[0], null);
            //Match match3 = new Match(_context.FootballClubs.First(),
            //_context.FootballClubs.Local.ToList()[4], "Stadion Suhača", "Champions League");
            //match3.RecordResult(1, 0, _context.Players.Local.ToList()[2], null);
            //Match match4 = new Match(_context.FootballClubs.First(),
            //_context.FootballClubs.Local.ToList()[6], "Stadion Suhača", "Champions League");
            //match4.RecordResult(1, 0, _context.Players.Local.ToList()[4], null);
            //Match match5 = new Match(_context.FootballClubs.First(),
            //_context.FootballClubs.Local.ToList()[7], "Stadion Suhača", "Champions League");
            //match5.RecordResult(1, 0, _context.Players.Local.ToList()[1], null);
            //Match match6 = new Match(_context.FootballClubs.First(),
            //_context.FootballClubs.Local.ToList()[8], "Stadion Suhača", "Champions League");
            //match6.RecordResult(1, 0, _context.Players.Local.ToList()[0], null);
            //Match match8 = new Match(_context.FootballClubs.First(),
            //_context.FootballClubs.Local.ToList()[5], "Stadion Suhača", "Champions League");
            //match8.RecordResult(1, 0, _context.Players.Local.ToList()[0], null);
            //_context.Matches.Add(match1);
            //_context.Matches.Add(match2);
            //_context.Matches.Add(match3);
            //_context.Matches.Add(match4);
            //_context.Matches.Add(match5);
            //_context.Matches.Add(match6);
            //_context.Matches.Add(match8);
            //_context.SaveChanges();

            //======================================================

            playersViewSource.Source = _context.Players.Local.ToObservableCollection();
            matchesViewSource.Source = _context.Matches.Local.ToObservableCollection();
            footballClubsViewSource.Source = _context.FootballClubs.Local.ToObservableCollection();
        }

        public void TransferPlayerToClub(Player player, FootballClub club, int transferCost)
        {
            player.TransferToClub(club, transferCost);

            club.AddPlayer(player);
        }
        protected override void OnClosed(EventArgs args)
        {
            _context.Dispose();
            base.OnClosed(args);
        }
    }
}
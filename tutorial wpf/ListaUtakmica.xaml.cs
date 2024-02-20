using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Microsoft.EntityFrameworkCore;

namespace tutorial_wpf
{
    public partial class ListaUtakmica : Page
    {

        private readonly FootballDbContext _context = new FootballDbContext();
        private CollectionViewSource matchesViewSource;
        public ListaUtakmica()
        {
            InitializeComponent();
            matchesViewSource =
(CollectionViewSource)FindResource(nameof(matchesViewSource));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Database.EnsureCreated();
            _context.Matches.Load();
            //Match match = new Match("Real Madrid", "Smoljanci Sloboda", "Stadion ", "Champions League");
            //match.RecordResult(1, 2, "Rodrygo", "Mirko, Mero");
            //Match match = new Match("Smoljanci Sloboda", "BVB", "Stadion Suhača", "Champions League");
            //match.RecordResult(1, 0, "Špruc", "/");
            //Match match = new Match("PSG", "Smoljanci Sloboda", "Stadion Park Prinčeva", "Champions League");
            //match.RecordResult(1, 1, "Mbappe", "Kale");
            //Match match = new Match("Smoljanci Sloboda", "Milan", "Stadion Suhača", "Champions League");
            //match.RecordResult(2, 1, "Nino, Špruc", "Leao");
            //Match match = new Match("Inter", "Smoljanci Sloboda", "Stadion San Siro", "Champions League");
            //match.RecordResult(0, 1, "/", "Kale");
            //Match match = new Match("Smoljanci Sloboda", "Lecce", "Stadion Suhača", "Champions League");
            //match.RecordResult(2, 0, "Dino, Mero", "/");
            //Match match = new Match("Smoljanci Sloboda", "Genoa", "Stadion Suhača", "Champions League");
            //match.RecordResult(3, 1, "Špruc, Nino, Mero", "Castrovilli");
            //Match match = new Match("Smoljanci Sloboda", "Monza", "Stadion Suhača", "Champions League");
            //match.RecordResult(2, 0, "Mirko, Dino", "/");
            //Match match = new Match("Smoljanci Sloboda", "Coventry", "Stadion Suhača", "Champions League");
            //match.RecordResult(1, 0, "Špruc", "/");
            //_context.Matches.Add(match);
            //_context.SaveChanges();

            matchesViewSource.Source = _context.Matches.Local.ToList();
        }



        public void OnMatchSelect(object sender, EventArgs e)
        {
            if (sender is ListBox listBox && listBox.SelectedItem != null)
            {
                Match selectedMatch = listBox.SelectedItem as Match;
                DetaljiOUtakmici detalji2Page = new DetaljiOUtakmici(selectedMatch);

                this.NavigationService.Navigate(detalji2Page);
            }
        }
    }
    //public class UtakmiceViewModel
    //    {
    //        public ObservableCollection<Match> Matches { get; set; }
    //        public UtakmiceViewModel()
    //        {
    //            Matches = new ObservableCollection<Match>();
    //            FootballClub myClub = new FootballClub("Smoljanci Sloboda", 344000);

    //            Match match1 = new Match(myClub.Name, "Bilbao", "Stadion Suhača", "Champions League");
    //            Match match2 = new Match(myClub.Name, "PSG", "Stadion Suhača", "Liga");
    //            myClub.ScheduleMatch(match1);
    //            myClub.ScheduleMatch(match2);

    //            myClub.RecordMatchResult(match1, 2, 1);
    //            myClub.RecordMatchResult(match2, 1, 1);

    //            myClub.Strijelci(match1, "andi, Kluo", "indi");
    //            myClub.Strijelci(match2, "Simon", "Klaun");

    //            Matches.Add(match1);
    //            Matches.Add(match2);
    //        }
    //    }
}

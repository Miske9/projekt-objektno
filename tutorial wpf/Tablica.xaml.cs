using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tutorial_wpf
{
    /// <summary>
    /// Interaction logic for Tablica.xaml
    /// </summary>
    public partial class Tablica : Page
    {
        // Definisanje klase za utakmicu
        public class Team
        {
            public int Position { get; set; }
            public string TeamName { get; set; }
            public int PlayedGames { get; set; }
            public int Wins { get; set; }
            public int Draws { get; set; }
            public int Losses { get; set; }
            public int Points { get; set; }
        }

        // ObservableCollection za skladištenje ekipa (automatski ažurira UI)
        private ObservableCollection<Team> teams = new ObservableCollection<Team>();

        public Tablica()
        {
            InitializeComponent();
            AddTeam("Smoljanci Sloboda", 20, 18, 1, 1, 55);
            AddTeam("PSG", 20, 15, 0, 5, 45);
            AddTeam("Real", 20, 16, 2, 2, 50);
            AddTeam("BVB", 20, 10, 5, 5, 35);
            AddTeam("Inter", 20, 10, 2, 8, 32);
            AddTeam("Milan", 20, 14, 3, 3, 45);
            AddTeam("Dinamo", 20, 16, 4, 0, 52);
            AddTeam("Manchester United", 20, 5, 5, 10, 20);
            AddTeam("Lyon", 20, 5, 7, 8, 22);
            AddTeam("Al Nassr", 20, 11, 5, 4, 38);
            AddTeam("Coventry", 20, 10, 0, 10, 30);

            // Povezivanje DataGrid-a sa ObservableCollection-om
            scoreboardDataGrid.ItemsSource = teams;
        }

        // Metoda za dodavanje nove ekipe
        private void AddTeam(string teamName, int playedGames, int wins, int draws, int losses, int points)
        {
            teams.Add(new Team { TeamName = teamName, PlayedGames = playedGames, Wins = wins, Draws = draws, Losses = losses, Points = points });
            var sortedTeams = teams.OrderByDescending(t => t.Points).ToList();
            for (int i = 0; i < sortedTeams.Count; i++)
            {
                sortedTeams[i].Position = i + 1;
            }
            // Ažuriramo ObservableCollection
            teams.Clear();
            foreach (var team in sortedTeams)
            {
                teams.Add(team);
            }
        }
    }
}

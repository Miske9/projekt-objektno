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
        //imamo samo jedan klub
        FootballClub club = new FootballClub("Smoljanci Sloboda", 1000, 1, 1, 2,3);
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Database.EnsureCreated();
            _context.Players.Load();

            //DODAVANJE NOVOG IGRACA U DATABAZU

            //int age = 12;
            //newPlayer = new Player("TIGUAL", age, age <= 11 ? "Škola Nogometa" : age < 16 ? "Pionir" : age <= 18 ? "Junior" : age <= 65 ? "Senior" : "Veteran", "napadac", 39, 3, 3);
            //newPlayer = new Player("Manye", age, age <= 11 ? "Škola Nogometa" : age < 16 ? "Pionir" : age <= 18 ? "Junior" : age <= 65 ? "Senior" : "Veteran", "napadac", 39, 3, 3);
            //newPlayer = new Player("asdasda", age, age <= 11 ? "Škola Nogometa" : age < 16 ? "Pionir" : age <= 18 ? "Junior" : age <= 65 ? "Senior" : "Veteran", "napadac", 39, 3, 3);
            //newPlayer = new Player("Matija", age, age <= 11 ? "Škola Nogometa" : age < 16 ? "Pionir" : age <= 18 ? "Junior" : age <= 65 ? "Senior" : "Veteran", "napadac", 39, 3, 3);
            //newPlayer = new Player("David", age, age <= 11 ? "Škola Nogometa" : age < 16 ? "Pionir" : age <= 18 ? "Junior" : age <= 65 ? "Senior" : "Veteran", "napadac", 39, 3, 3);
            //newPlayer = new Player("Nez ki js", age, age <= 11 ? "Škola Nogometa" : age < 16 ? "Pionir" : age <= 18 ? "Junior" : age <= 65 ? "Senior" : "Veteran", "napadac", 39, 3, 3);
            //_context.Players.Add(newPlayer);
            //playersTemp = _context.Players.Local.ToList();
            //AddPlayer(newPlayer);
            //_context.FootballClubs.Add(club);
            //TransferPlayerToClub(newPlayer);
            //_context.SaveChanges();

            playersViewSource.Source = _context.Players.Local.ToList();
            playersViewSource.View.Refresh();
        }
        public void TransferPlayerToClub(Player player)
        {
            Player transferPlayer = playersTemp.Find(p => p.Name == newPlayer.Name);
            transferPlayer.TransferToClub(club, 100);
            club.AddPlayer(player);

        }

         public void AddPlayer(Player player)
        {
            if (player.Age <= 11)
            {
                player.Category = "Škola Nogometa";
            }
            else if (player.Age >= 12 && player.Age <16)
            {
                player.Category = "Pionir";
            }
            // Automatski dodaje igrača u odgovarajuću kategoriju
            else if (player.Age >= 16 && player.Age<= 18)
            {
                player.Category = "Junior";
            }
            else if (player.Age >= 19 && player.Age < 65)
            {
                player.Category = "Senior";
            }
            else
            {
                player.Category = "Veteran";
            }
            if (player.Category == "Veteran")
            {
                // Pronalazimo prvi indeks veterana
                int index = playersTemp.ToList().FindIndex(p => p.Category == "Senior");
                if (index == -1)
                {
                    playersTemp.Add(player); // Ako nema veterana, dodajemo na kraj
                }
                else
                {
                    int lastIndex = playersTemp.ToList().FindLastIndex(p => p.Category == "Senior");
                    playersTemp.Insert(index, player); // Inače, umetnemo prije prvog veterana
                }
            }
            else if (player.Category == "Senior")
            {
                // Pronalazimo prvi indeks seniora
                int index = playersTemp.ToList().FindIndex(p => p.Category == "Senior");
                if (index == -1)
                {
                    playersTemp.Add(player); // Ako nema seniora, dodajemo na kraj
                }
                else
                {
                    // Pronalazimo posljednjeg seniora
                    int lastIndex = playersTemp.ToList().FindLastIndex(p => p.Category == "Senior");
                    playersTemp.Insert(lastIndex + 1, player); // Inače, umetnemo poslije posljednjeg seniora
                }
            }
            else if (player.Category == "Junior")
            {
                // Pronalazimo prvi indeks seniora
                int index = playersTemp.ToList().FindIndex(p => p.Category == "Junior");
                if (index == -1)
                {
                    playersTemp.Add(player); // Ako nema seniora, dodajemo na kraj
                }
                else
                {
                    // Pronalazimo posljednjeg seniora
                    int lastIndex = playersTemp.ToList().FindLastIndex(p => p.Category == "Junior");
                    playersTemp.Insert(lastIndex + 1, player); // Inače, umetnemo poslije posljednjeg seniora
                }
            }
            else if (player.Category == "Pionir")
            {
                // Pronalazimo prvi indeks seniora
                int index = playersTemp.ToList().FindIndex(p => p.Category == "Pionir");
                if (index == -1)
                {
                    playersTemp.Add(player); // Ako nema seniora, dodajemo na kraj
                }
                else
                {
                    // Pronalazimo posljednjeg seniora
                    int lastIndex = playersTemp.ToList().FindLastIndex(p => p.Category == "Pionir");
                    playersTemp.Insert(lastIndex + 1, player); // Inače, umetnemo poslije posljednjeg seniora
                }
            }
            else if (player.Category == "Škola Nogometa")
            {
                // Pronalazimo prvi indeks seniora
                int index = playersTemp.ToList().FindIndex(p => p.Category == "Škola Nogometa");
                if (index == -1)
                {
                    playersTemp.Add(player); // Ako nema seniora, dodajemo na kraj
                }
                else
                {
                    // Pronalazimo posljednjeg seniora
                    int lastIndex = playersTemp.ToList().FindLastIndex(p => p.Category == "Škola Nogometa");
                    playersTemp.Insert(lastIndex + 1, player); // Inače, umetnemo poslije posljednjeg seniora
                }
            }
        }

        public void OnPlayerSelect(object sender, EventArgs e)
        {
            if (sender is ListBox listBox && listBox.SelectedItem != null)
            {
                Player selectedPlayer = listBox.SelectedItem as Player;
                DetaljiOIgracu detaljiPage = new DetaljiOIgracu(selectedPlayer);

                this.NavigationService.Navigate(detaljiPage);
            }
        }
    }

}

using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace tutorial_wpf
{
    public partial class Kategorije : Page
    {
        public Kategorije()
        {
            InitializeComponent();

            DataContext = new KategorijeIgracaViewModel();
            PopulatePlayers();
        }

        private void PopulatePlayers()
        {
            KategorijeIgracaViewModel viewModel = DataContext as KategorijeIgracaViewModel;
            if (viewModel != null)
            {
                viewModel.AddPlayer(new Player("Paulo", 20, "", "Napadač", 101));
                viewModel.AddPlayer(new Player("Kaneko", 66, "", "Vezni", 2));
                viewModel.AddPlayer(new Player("Ivo", 18, "", "Stoper", 90));
                viewModel.AddPlayer(new Player("Dado", 12, "", "Golman", 8));
                viewModel.AddPlayer(new Player("Teo", 11, "", "Vezni", 9));
                viewModel.AddPlayer(new Player("Miho", 89, "", "Napadač", 3));
                viewModel.AddPlayer(new Player("Javor", 64, "", "Napadač", 4));
                viewModel.AddPlayer(new Player("Mladina", 16, "", "Stoper", 55));
                viewModel.AddPlayer(new Player("Silvano", 19, "", "Napadač", 78));
                viewModel.AddPlayer(new Player("Milo", 12, "", "Krilo", 6));
                viewModel.AddPlayer(new Player("Hrki", 10, "", "Golman", 7));
                // Dodajte više igrača po potrebi
            }
        }
    }

    public class KategorijeIgracaViewModel
    {
        public ObservableCollection<Player> Players { get; set; }

        public KategorijeIgracaViewModel()
        {
            Players = new ObservableCollection<Player>();
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
                int index = Players.ToList().FindIndex(p => p.Category == "Senior");
                if (index == -1)
                {
                    Players.Add(player); // Ako nema veterana, dodajemo na kraj
                }
                else
                {
                    int lastIndex = Players.ToList().FindLastIndex(p => p.Category == "Senior");
                    Players.Insert(index, player); // Inače, umetnemo prije prvog veterana
                }
            }
            else if (player.Category == "Senior")
            {
                // Pronalazimo prvi indeks seniora
                int index = Players.ToList().FindIndex(p => p.Category == "Senior");
                if (index == -1)
                {
                    Players.Add(player); // Ako nema seniora, dodajemo na kraj
                }
                else
                {
                    // Pronalazimo posljednjeg seniora
                    int lastIndex = Players.ToList().FindLastIndex(p => p.Category == "Senior");
                    Players.Insert(lastIndex + 1, player); // Inače, umetnemo poslije posljednjeg seniora
                }
            }
            else if (player.Category == "Junior")
            {
                // Pronalazimo prvi indeks seniora
                int index = Players.ToList().FindIndex(p => p.Category == "Junior");
                if (index == -1)
                {
                    Players.Add(player); // Ako nema seniora, dodajemo na kraj
                }
                else
                {
                    // Pronalazimo posljednjeg seniora
                    int lastIndex = Players.ToList().FindLastIndex(p => p.Category == "Junior");
                    Players.Insert(lastIndex + 1, player); // Inače, umetnemo poslije posljednjeg seniora
                }
            }
            else if (player.Category == "Pionir")
            {
                // Pronalazimo prvi indeks seniora
                int index = Players.ToList().FindIndex(p => p.Category == "Pionir");
                if (index == -1)
                {
                    Players.Add(player); // Ako nema seniora, dodajemo na kraj
                }
                else
                {
                    // Pronalazimo posljednjeg seniora
                    int lastIndex = Players.ToList().FindLastIndex(p => p.Category == "Pionir");
                    Players.Insert(lastIndex + 1, player); // Inače, umetnemo poslije posljednjeg seniora
                }
            }
            else if (player.Category == "Škola Nogometa")
            {
                // Pronalazimo prvi indeks seniora
                int index = Players.ToList().FindIndex(p => p.Category == "Škola Nogometa");
                if (index == -1)
                {
                    Players.Add(player); // Ako nema seniora, dodajemo na kraj
                }
                else
                {
                    // Pronalazimo posljednjeg seniora
                    int lastIndex = Players.ToList().FindLastIndex(p => p.Category == "Škola Nogometa");
                    Players.Insert(lastIndex + 1, player); // Inače, umetnemo poslije posljednjeg seniora
                }
            }
        }
    }
}

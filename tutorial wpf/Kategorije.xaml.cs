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
                viewModel.AddPlayer(new Player("Paulo", 20, "", "Napadač", 33));
                viewModel.AddPlayer(new Player("Kaneko", 66, "", "Vezni", 23));
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
            // Automatski dodaje igrača u odgovarajuću kategoriju
            if (player.Age < 18)
            {
                player.Category = "Junior";
            }
            else if (player.Age >= 18 && player.Age < 65)
            {
                player.Category = "Senior";
            }
            else
            {
                player.Category = "Veteran";
            }

            Players.Add(player);
        }
    }
}

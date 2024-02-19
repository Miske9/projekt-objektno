using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace tutorial_wpf
{
    public partial class MainPage : Page
    {
        private readonly FootballDbContext _context = new FootballDbContext();
        private CollectionViewSource playersViewSource;


        public MainPage()
        {
            InitializeComponent();
            playersViewSource =
    (CollectionViewSource)FindResource(nameof(playersViewSource));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _context.Database.EnsureCreated();
            _context.Players.Add(new Player("Ronaldo", 10, "Senior", "Real Madrid", 100));
            _context.SaveChanges();
            playersViewSource.Source = _context.Players.Local.ToObservableCollection();
        }
        private void IgraciButton_Click(object sender, RoutedEventArgs e)
        {
            lista_igraca igracipage = new lista_igraca();
            this.NavigationService.Navigate(igracipage);
        }
        private void UtakmiceButton_Click(object sender, RoutedEventArgs e)
        {
            Utakmice utakmicaPage = new Utakmice();
            this.NavigationService.Navigate(utakmicaPage);
        }

        private void KategorijeButton_Click(object sender, RoutedEventArgs e)
        {
            Kategorije katPage = new Kategorije();
            this.NavigationService.Navigate(katPage);
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            About aboutPage = new About();
            this.NavigationService.Navigate(aboutPage);
        }
    }
}

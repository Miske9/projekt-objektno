using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace tutorial_wpf
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void IgraciButton_Click(object sender, RoutedEventArgs e)
        {
            ListaIgraca igracipage = new ListaIgraca();
            this.NavigationService.Navigate(igracipage);
        }
        private void UtakmiceButton_Click(object sender, RoutedEventArgs e)
        {
            ListaUtakmica utakmicaPage = new ListaUtakmica();
            this.NavigationService.Navigate(utakmicaPage);
        }

        private void KategorijeButton_Click(object sender, RoutedEventArgs e)
        {
            Tablica katPage = new Tablica();
            this.NavigationService.Navigate(katPage);
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            About aboutPage = new About();
            this.NavigationService.Navigate(aboutPage);
        }
    }
}

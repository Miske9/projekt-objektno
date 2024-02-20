using System.Windows;
using System.Windows.Controls;

namespace tutorial_wpf
{
    public partial class DetaljiOUtakmici : Page
    {
        public DetaljiOUtakmici(Match match)
        {
            InitializeComponent();
            DataContext = match;
        }

        public void OnSelectClub(object sender, RoutedEventArgs e)
        {
            FootballClub selectedMatch = KlubButton.Tag as FootballClub;
            DetaljiOKlubu detalji2Page = new DetaljiOKlubu(selectedMatch);

            this.NavigationService.Navigate(detalji2Page);
        }
        public void OnSelectOpponent(object sender, RoutedEventArgs e)
        {
            FootballClub selectedMatch = KlubButton2.Tag as FootballClub;
            DetaljiOKlubu detalji2Page = new DetaljiOKlubu(selectedMatch);

            this.NavigationService.Navigate(detalji2Page);
        }
    }
}

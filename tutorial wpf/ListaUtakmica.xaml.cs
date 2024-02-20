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
}

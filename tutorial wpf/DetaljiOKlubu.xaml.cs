using System.Windows.Controls;

namespace tutorial_wpf
{
    public partial class DetaljiOKlubu : Page
    {
        public DetaljiOKlubu(FootballClub club)
        {
            InitializeComponent();
            DataContext = club;
        }
    }
}

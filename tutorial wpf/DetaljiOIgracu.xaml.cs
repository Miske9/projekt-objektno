using System.Windows.Controls;

namespace tutorial_wpf
{
    public partial class DetaljiOIgracu : Page
    {
        public DetaljiOIgracu(Player player)
        {
            InitializeComponent();
            DataContext = player;
        }
    }
}

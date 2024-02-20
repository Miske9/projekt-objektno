using System.Windows.Controls;

namespace tutorial_wpf
{
    public partial class About : Page
    {
        private AboutViewModel viewModel;

        public About()
        {
            InitializeComponent();

            viewModel = new AboutViewModel();

            DataContext = viewModel;
        }
    }

    public class AboutViewModel
    {
        public string Location { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public AboutViewModel()
        {
            Location = "Hrvatska, Istra";
            Address = "Svetvinčenat 988";
            Phone = "+38597876765";
            Fax = "051234";
        }
    }
}

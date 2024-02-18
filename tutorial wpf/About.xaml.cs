using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tutorial_wpf
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Page
    {
        // ViewModel koji će sadržavati podatke za binding
        private AboutViewModel viewModel;

        public About()
        {
            InitializeComponent();

            // Inicijalizacija ViewModel-a
            viewModel = new AboutViewModel();

            // Postavljanje DataContext-a na ViewModel
            DataContext = viewModel;
        }
    }

    // ViewModel klasa koja sadrži podatke za binding
    public class AboutViewModel
    {
        public string Location { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public AboutViewModel()
        {
            // Inicijalizacija podataka
            Location = "Hrvatska";
            Address = "Svetvinčenat 988";
            Phone = "+38597876765";
            Fax = "051234";
        }
    }
}

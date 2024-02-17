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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
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

        private void TransferiButton_Click(object sender, RoutedEventArgs e)
        {
            Transferi transferPage = new Transferi();
            this.NavigationService.Navigate(transferPage);
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            About aboutPage = new About();
            this.NavigationService.Navigate(aboutPage);
        }
    }
}

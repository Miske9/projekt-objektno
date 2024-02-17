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
    /// Interaction logic for Detalji_o_Igracu.xaml
    /// </summary>
    public partial class Detalji_o_Igracu : Page
    {
        public Detalji_o_Igracu(Player player)
        {
            InitializeComponent();
            DataContext = player;
        }
    }
}

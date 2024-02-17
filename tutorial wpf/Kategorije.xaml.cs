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
    /// Interaction logic for Kategorije.xaml
    /// </summary>
    public partial class Kategorije : Page
    {
        public Kategorije()
        {
            InitializeComponent();
        }

        private void KategorijeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
    IgraciListBox.Items.Clear();

    ListBoxItem selectedItem = KategorijeListBox.SelectedItem as ListBoxItem;
    if (selectedItem != null)
    {
        string selectedCategory = selectedItem.Content.ToString();

        List<Player> players = GetPlayersByCategory(selectedCategory);

        foreach (Player player in players)
        {
            IgraciListBox.Items.Add(player);
        }
    }
}

private List<Player> GetPlayersByCategory(string category)
{
    List<Player> playersByCategory = new List<Player>();

    return playersByCategory;
}

    }
}

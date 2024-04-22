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
using System.Windows.Shapes;

namespace Petshop
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            MainFrame.Content = new DashBoard();
        }

        private void Listbx_Selected(object sender, RoutedEventArgs e)
        {
          
        }

        private void DashBoard_Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new DashBoard();
        }

        private void Pets_Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Pets();
        }

        private void Supplies_Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Supplies();
        }
    }
}

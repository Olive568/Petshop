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
            string[] a = new string[6] {"Dashboard" , "Pets", "Supplies" , "Users", "Logs" , "Options"};
            foreach(string s in a) 
            {
                Listbx.Items.Add(s);
            }
            Listbx.SelectedIndex = 0;
        }

        private void Listbx_Selected(object sender, RoutedEventArgs e)
        {
            if(Listbx.SelectedItem == "Dashboard") 
            {
                Dashboard.Opacity = 100;
                Dashboard.IsEnabled = true;
            }
        }
    }
}

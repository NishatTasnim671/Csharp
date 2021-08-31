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

namespace Campaign
{
    /// <summary>
    /// Interaction logic for Userview.xaml
    /// </summary>
    public partial class Userview : Window
    {
        public Userview(string username)
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string username = null;
            AcceptorPage a = new AcceptorPage(username);
            a.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string username = null;
            DonorPage d = new DonorPage(username);
            d.Show();
            this.Hide();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string username = null;
            LogIn l = new LogIn(username);
            l.Show();
            this.Hide();
        }
    }
}

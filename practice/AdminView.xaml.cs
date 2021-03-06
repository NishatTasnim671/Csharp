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
using System.Data.SqlClient;

namespace Campaign
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : Window
    {
        public AdminView(string username)
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = null;
            ShowREG sr = new ShowREG(username);
            sr.Show();
            this.Hide();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string username = null;
            ShowDonor sd = new ShowDonor(username);
            sd.Show();
            this.Hide();
        }
    }
}

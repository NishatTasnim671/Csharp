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
    /// Interaction logic for BloodGroupShow.xaml
    /// </summary>
    public partial class BloodGroupShow : Window
    {
        public BloodGroupShow(string username)
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string option = MyComboBox.Text;
            AvailableDonorInfo info = new AvailableDonorInfo(option);
            this.Hide();
            info.Show();
        }
    }
}


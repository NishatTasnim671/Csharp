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
    /// Interaction logic for DonorPage.xaml
    /// </summary>
    public partial class DonorPage : Window
    {
        public DonorPage(string username)
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-28R5CG7A\SQLEXPRESS;Initial Catalog=Registration;Integrated Security=True");
            conn.Open();
            try
            {
                SqlCommand cmdd = new SqlCommand(@"INSERT INTO [dbo].[DonorInfo]
           ([Name]
           ,[Address]
           ,[Phone]
           ,[Gender]
           ,[Age]
           ,[Blood Group]
           ,[Date Of Recovery])
     VALUES
           ('" + dname.Text + "', '" + daddress.Text + "', '" + dphone.Text + "', '" + dgender.Text + "', '" + dage.Text + "', '" + dgroup.Text + "', '" + drecovery.Text + "' )", conn);
                cmdd.ExecuteNonQuery();
                MessageBox.Show("Successfull. Thank You For this Info");
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string username = null;
            Userview u = new Userview(username);
            u.Show();
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

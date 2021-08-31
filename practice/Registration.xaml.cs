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
using System.Data.SqlClient;

namespace Campaign
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(String Username)
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-28R5CG7A\SQLEXPRESS;Initial Catalog=Registration;Integrated Security=True");
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Registration User]
           ([First Name]
           ,[Last Name]
           ,[Address]
           ,[Gender]
           ,[Phone]
           ,[Email]
           ,[User Name]
           ,[Password])
     VALUES
           ('" + txtfirstname.Text + "', '" + txtlastname.Text + "','" + txtaddress.Text + "', '" + txtgender.Text + "','" + txtemail.Text + "','" + txtphone.Text + "','" + txtusername.Text + "','" + txtpassword.Password + "')", con);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Register Complete");
                string userName = txtusername.Text.ToString();
                LogIn l = new LogIn(userName);
                l.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string userName = txtusername.Text.ToString();
            LogIn l = new LogIn(userName);
            l.Show();
            this.Hide();

        }

        
    }
}

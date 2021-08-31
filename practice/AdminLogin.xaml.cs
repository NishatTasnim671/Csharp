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
    /// Interaction logic for AdminLogin.xaml
    /// </summary>
    public partial class AdminLogin : Window
    {
        public AdminLogin(string username)
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-28R5CG7A\SQLEXPRESS;Initial Catalog=Registration;Integrated Security=True");
            try
            {
                conn.Open();



                string query = "select count(*) from [Registration].[dbo].[AdminLogIn] where UserName='" + aname.Text + "' And Password='" + apass.Password + "'";
                SqlCommand sqlcmd = new SqlCommand(query, conn);
                int s = Convert.ToInt32(sqlcmd.ExecuteScalar());
                string username = null;
                AdminView aview = new AdminView(username);
                aview.Show();
                this.Hide();


                if (s == 1)
                {
                    MessageBox.Show("valid");
                   
                }
                else
                {
                    MessageBox.Show("Invalid");
                }



            }



            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);



            }
            finally
            {
                conn.Close();
            }
        }
    }
    }


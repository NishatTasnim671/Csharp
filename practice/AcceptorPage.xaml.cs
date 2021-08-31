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
    /// Interaction logic for AcceptorPage.xaml
    /// </summary>
    public partial class AcceptorPage : Window
    {
        public AcceptorPage(string username)
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = null;
            Userview u = new Userview(username);
            u.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            string username = null;
            LogIn l = new LogIn(username);
            l.Show();
            this.Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-28R5CG7A\SQLEXPRESS;Initial Catalog=Registration;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[AcceptorInfo]
           ([Patient Name]
           ,[Age]
           ,[Gender]
           ,[Corona Positive Date]
           ,[Name Of Hospital])
           
     VALUES
           ('" + pname.Text + "', '" + page.Text + "','" + pgender.Text + "', '" + pdate.Text + "','" + phospital.Text + "')", con);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Register Complete");
            string username = null;
            BloodGroupShow bshow = new BloodGroupShow(username);
            bshow.Show();
            this.Hide();

        }
    }
}

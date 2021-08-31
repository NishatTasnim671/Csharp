using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Data;


namespace Campaign
{
    /// <summary>
    /// Interaction logic for AvailableDonorInfo.xaml
    /// </summary>
    public partial class AvailableDonorInfo : Window
    {
        public AvailableDonorInfo(string bg)
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-28R5CG7A\SQLEXPRESS;Initial Catalog=Registration;Integrated Security=True");
            string BG;
            BG = bg;
            conn.Open();

            string query = (@"SELECT [Name]
           ,[Address]
           ,[Phone]
           ,[Gender]
           ,[Age]
           ,[Blood Group]
           ,[Date Of Recovery]
  FROM [dbo].[DonorInfo] where [Blood Group]  like '" + BG + "' ");
            SqlCommand sqlcmd = new SqlCommand(query, conn);
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter dadap = new SqlDataAdapter(sqlcmd);
            dadap.Fill(dt);
            gridview.ItemsSource = dt.DefaultView;

            conn.Close();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = null;
            LogIn l = new LogIn(username);
            l.Show();
            this.Hide();
        }

        private void gridview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

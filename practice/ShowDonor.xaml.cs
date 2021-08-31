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
using System.Data;

namespace Campaign
{
    /// <summary>
    /// Interaction logic for ShowDonor.xaml
    /// </summary>
    public partial class ShowDonor : Window
    {
        public ShowDonor(string username)
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-28R5CG7A\SQLEXPRESS;Initial Catalog=Registration;Integrated Security=True");
            conn.Open();
            try
            {
                string query = (@"SELECT [Name]
           ,[Address]
           ,[Phone]
           ,[Gender]
           ,[Age]
           ,[Blood Group]
           ,[Date Of Recovery]
  FROM [dbo].[DonorInfo]");
                SqlCommand sqlcmd = new SqlCommand(query, conn);
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter dadap = new SqlDataAdapter(sqlcmd);
                dadap.Fill(dt);
                datagrid2.ItemsSource = dt.DefaultView;

               
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

        private void datagrid2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

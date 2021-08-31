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
    /// Interaction logic for ShowREG.xaml
    /// </summary>
    public partial class ShowREG : Window
    {
        public ShowREG(string username)
        {
            InitializeComponent();
            SqlConnection connn = new SqlConnection(@"Data Source=LAPTOP-28R5CG7A\SQLEXPRESS;Initial Catalog=Registration;Integrated Security=True");
            connn.Open();
            string query = (@"SELECT [First Name]
           ,[Last Name]
           ,[Address]
           ,[Gender]
           ,[Phone]
           ,[Email]
           ,[User Name]
           ,[Password]
  FROM [dbo].[Registration User]");
            SqlCommand sqlcmd = new SqlCommand(query, connn);
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter dadap = new SqlDataAdapter(sqlcmd);
            dadap.Fill(dt);
            datagrid1.ItemsSource = dt.DefaultView;

            connn.Close();


        }

        private void datagrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

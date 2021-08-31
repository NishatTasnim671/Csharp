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
using System.IO;

namespace Assignments
{
   
    public partial class MainWindow : Window
    {
        string file = @"F:\Assignment\TextFile.txt";
        public MainWindow()
        {
            InitializeComponent();
            if(!File.Exists(file))
            {
                File.Create(file);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string line = MyComboBox.Text;
            Textbox.Text = line;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           StreamWriter sw = new StreamWriter(file, true);
            try
            {
                string Write = Textbox.Text;
                sw.WriteLine(Write);
                MessageBox.Show("Text is written successfully!");

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            finally
            {
                sw.Close();
            }
        }

        
    }
}

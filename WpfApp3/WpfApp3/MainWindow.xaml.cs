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
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        static SqlConnection connection;
        public MainWindow()
        {
            InitializeComponent();
            connectionDB();

            //MyTextBox
            // MyTextBox.Items.Add(pnlMain.FindResource("strPanel").ToString());
            //disconnect();
          
        }

        static void connectionDB()
        {
            string connectiondb = @"data source=(localdb)\mssqllocaldb;
                                    initial catalog=lessondb;
                                    integrated security=true;
                                    pooling=false";

            connection = new SqlConnection(connectiondb);         
            connection.Open();         
        }

        static string getUser()
        {
            string sql = "select * from [dbo].[table]";
            SqlCommand command = new SqlCommand(sql, connection);       
            SqlDataReader reader = command.ExecuteReader();

  
            while (reader.Read())
            {
               return reader.GetString(1);
            }
            return null;

        }

        static void disconnect()
        {
            connection.Close();
        }

        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {
            string user = getUser();
            MyTextBox.Text = user;
        }


    }
}



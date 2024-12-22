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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DigitalLib2._0
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bookAdder bookAdderEv;

        public MainWindow()
        {
            InitializeComponent();
            fillComboAuthor();
            fillComboCategory();
            fillComboPublisher();
            fillComboGenre();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (bookAdderEv == null)
            {
                bookAdderEv = new bookAdder();
                bookAdderEv.Show();
            }
            else
            {
                bookAdderEv.Activate();
            }
            if(!bookAdderEv.IsActive)
            {
                bookAdderEv = null;
            }
        }

        private void fillComboAuthor()
        {
            // Заполение combobox автора
            SqlConnection connection = new SqlConnection("Data Source=PEKANYA;Initial Catalog=DigitalLibrary;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT DISTINCT Автор FROM Book", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string author = reader.GetString(0);
                comboAuthor.Items.Add(author);
            }
        }        
        private void fillComboCategory()
        {
            // Заполение combobox категории
            SqlConnection connection = new SqlConnection("Data Source=PEKANYA;Initial Catalog=DigitalLibrary;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT DISTINCT Категории FROM Book", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string category = reader.GetString(0);
                comboCategory.Items.Add(category);
            }
        }        
        private void fillComboPublisher()
        {
            // Заполение combobox категории
            SqlConnection connection = new SqlConnection("Data Source=PEKANYA;Initial Catalog=DigitalLibrary;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT DISTINCT Издатель FROM Book", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string Publisher = reader.GetString(0);
                comboPublisher.Items.Add(Publisher);
            }
        }        
        private void fillComboGenre()
        {
            // Заполение combobox категории
            SqlConnection connection = new SqlConnection("Data Source=PEKANYA;Initial Catalog=DigitalLibrary;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT DISTINCT Жанр FROM Book", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string Genre = reader.GetString(0);
                comboGenre.Items.Add(Genre);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_3(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BookList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

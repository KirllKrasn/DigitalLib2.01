using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
//using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using static System.Net.Mime.MediaTypeNames;


namespace DigitalLib2._0
{
    /// <summary>
    /// Логика взаимодействия для bookAdder.xaml
    /// </summary>
    public partial class bookAdder : Window
    {

        public bookAdder()
        {
            InitializeComponent();
        }

        private string filePath;
        private string fileName;

        // SQL подключение

        private void ChooseBook_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "PDF books | *.pdf";
            dlg.Title = "Выберите книгу: ";
            dlg.Multiselect = false;

            bool? successOpen = dlg.ShowDialog();

            if(successOpen == true)
            {
                filePath = dlg.FileName;
                fileName = dlg.SafeFileName;
            }
            else
            {
                tbInfo.Content = "Файл не выбран: ";
            }
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {

            string DirPath = "C:\\DigitalLib";
            if (Directory.Exists(DirPath))
            {
                Directory.CreateDirectory(DirPath);
            }

            // Создание директории на диске при её отсутствии
            string destinationPath = System.IO.Path.Combine(DirPath, fileName);

            SqlConnection connection = new SqlConnection("Data Source=PEKANYA;Initial Catalog=DigitalLibrary;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            connection.Open();
            SqlCommand changeID = new SqlCommand("");
            SqlCommand command = new SqlCommand("Insert into Book(Автор, Год, Наименование, Издатель, Жанр, Категории,  Возрастное_ограничение, bookURL) values" +
                "(@Автор, @Год, @Наименование, @Издатель, @Жанр, @Категории,  @Возрастное_ограничение, @bookURL)", connection);
            var censure = Convert.ToInt32(TbCensure.Text);
            command.Parameters.AddWithValue("@Автор", TbAuthor.Text);
            command.Parameters.AddWithValue("@Год", TbYear.Text);
            command.Parameters.AddWithValue("@Наименование", TbName.Text);
            command.Parameters.AddWithValue("@Издатель", TbPublisher.Text);
            command.Parameters.AddWithValue("@Жанр", TbGenre.Text);
            command.Parameters.AddWithValue("@Категории", TbCategory.Text);
            command.Parameters.AddWithValue("@Возрастное_ограничение", censure);
            command.Parameters.AddWithValue("@bookURL", destinationPath);

            command.ExecuteNonQuery();

            MessageBox.Show(destinationPath);


            //Проверяем, существует ли такой файл
            if (File.Exists(destinationPath))
            {
                MessageBox.Show("Файл с таким именем уже существует в папке!", "Ошибка");
                return;
            }
            // Перемещаем файл (можно также использовать File.Copy для копирования)
            File.Move(filePath, destinationPath);

            MessageBox.Show("Файл успешно перемещен!", "Успех");
            filePath = null; // Сбрасываем путь после перемещения
            tbInfo.Content = "Файл перемещён!"; // Обновляем UI
        }

    }
}

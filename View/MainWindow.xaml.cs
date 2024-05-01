using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using TelephoneCompanyApp.Model;
using TelephoneCompanyApp.ViewModel;

namespace TelephoneCompanyApp.View
{
    public partial class MainWindow : Window
    {
        public static DataGrid AllAbonentsView;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            AllAbonentsView = ViewAllAbonents;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string dateTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string fileName = $"report_{dateTime}.csv";

            List<string> lines = new List<string>();

            lines.Add("ФИО;Улица;Номер дома;Телефон (домашний);Телефон (рабочий);Телефон (мобильный)");

            foreach (Abonent abonent in (DataContext as DataManageVM).AllAbonents)
            {
                string fio = abonent.FullName;
                string address = abonent.Address;
                string phoneNumber = abonent.PhoneNumber;

                lines.Add($"{fio};{address};{phoneNumber}");
            }

            Encoding encoding = Encoding.UTF8;

            File.WriteAllLines(fileName, lines, encoding);

            MessageBox.Show($"Данные успешно сохранены в файл {fileName}", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
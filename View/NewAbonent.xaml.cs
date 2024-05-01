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
using TelephoneCompanyApp.ViewModel;

namespace TelephoneCompanyApp.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewAbonent.xaml
    /// </summary>
    public partial class NewAbonent : Window
    {
        public NewAbonent()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
        }
    }
}

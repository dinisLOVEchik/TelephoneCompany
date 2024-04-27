using System.Text;
using System.Windows;
using TelephoneCompanyApp.ViewModel;

namespace TelephoneCompanyApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
        }
    }
}
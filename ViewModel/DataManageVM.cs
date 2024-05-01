using System.ComponentModel;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using TelephoneCompanyApp.Model;
using TelephoneCompanyApp.View;
using System.Windows.Interop;
using TelephoneCompanyApp.Model.Data;

namespace TelephoneCompanyApp.ViewModel
{
    public class DataManageVM:INotifyPropertyChanged
    {
        private List<Abonent> allAbonents = DataWorker.GetAllAbonents();

        public List<Abonent> AllAbonents
        {
            get { return allAbonents; }
            set
            {
                allAbonents = value;
                NotifyPropertyChanged(nameof(AllAbonents));
            }
        }

        public string ParametrForAllAbonentsByNumberMethod { get; set; }
        public List<Abonent> AllAbonentsByNumber
        {
            get { return DataWorker.GetAbonentsByNumber(ParametrForAllAbonentsByNumberMethod); }
            set
            {
                allAbonents = value;
                NotifyPropertyChanged(nameof(AllAbonentsByNumber));
            }
        }
        public string NewAbonentName { get; set; }
        public string NewAbonentAddress { get; set; }
        public string NewAbonentNumber { get; set; }
        #region COMMAND TO ADD
        private RelayCommand addNewAbonent;
        public RelayCommand AddNewAbonent
        {
            get
            {
                return addNewAbonent ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string result = "";
                    if (NewAbonentName == null || NewAbonentName.Replace(" ","").Length == 0)
                    {
                        SetRedBlockControl(window, "NameBlock");
                    }
                    else
                    {
                        result = DataWorker.CreateAbonent(NewAbonentName, NewAbonentAddress, NewAbonentNumber);
                        UpdateAllAbonentsView();
                        ShowMessageToUser(result);
                        SetNullValuesToProperties();
                        window.Close();
                    }
                }
                );

            }
        }
        #endregion

        #region COMMANDS TO OPEN WINDOWS
        private RelayCommand openNewAbonentWindow;
        public RelayCommand OpenNewAbonentWindow
        {
            get
            {
                return openNewAbonentWindow ?? new RelayCommand(obj =>
                {
                    OpenNewAbonentWindowMethod();
                }
                );
            }
        }
        private RelayCommand openSearchByNumberWindow;
        public RelayCommand OpenSearchByNumberWindow
        {
            get
            {
                return openSearchByNumberWindow ?? new RelayCommand(obj =>
                {
                    OpenSearchByNumberWindowMethod();
                }
                );
            }
        }
        private RelayCommand openNoResultsWindow;
        public RelayCommand OpenNoResultsWindow
        {
            get
            {
                return openNoResultsWindow ?? new RelayCommand(obj =>
                {
                    OpenNoResultsWindowMethod();
                }
                );
            }
        }
        private RelayCommand openStreetsWindow;
        public RelayCommand OpenStreetsWindow
        {
            get
            {
                return openStreetsWindow ?? new RelayCommand(obj =>
                {
                    OpenStreetsWindowMethod();
                }
                );
            }
        }
        #endregion
        #region METHODS TO OPEN WINDOWS
        private void OpenNewAbonentWindowMethod()
        {
            NewAbonent newAbonent = new NewAbonent();
            SetCenterPositionAndOpen(newAbonent);
        }
        private void OpenSearchByNumberWindowMethod()
        {
            SearchByNumber searchByNumber = new SearchByNumber();
            SetCenterPositionAndOpen(searchByNumber);
        }
        private void OpenNoResultsWindowMethod()
        {
            NoResultsWindow noResultsWindow = new NoResultsWindow();
            SetCenterPositionAndOpen(noResultsWindow);
        }
        private void OpenStreetsWindowMethod()
        {
            StreetsWindow streetsWindow = new StreetsWindow();
            SetCenterPositionAndOpen(streetsWindow);
        }
        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        #endregion

        private void SetRedBlockControl(Window window, string blockName)
        {
            Control control = window.FindName(blockName) as Control;
            control.BorderBrush = Brushes.Red;
        }
        #region UPDATE VIEWS
        private void UpdateAllAbonentsView()
        {
            AllAbonents = DataWorker.GetAllAbonents();
            MainWindow.AllAbonentsView.ItemsSource = null;
            MainWindow.AllAbonentsView.Items.Clear();
            MainWindow.AllAbonentsView.ItemsSource= AllAbonents;
            MainWindow.AllAbonentsView.Items.Refresh();
        }

        private void SetNullValuesToProperties()
        {
            NewAbonentName = null;
            NewAbonentAddress = null;
            NewAbonentNumber = null;
        }
        #endregion
        private void ShowMessageToUser(string msg)
        {
            MessageView messageView = new MessageView(msg);
            SetCenterPositionAndOpen(messageView);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

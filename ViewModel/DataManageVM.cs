using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneCompanyApp.Model;

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
                NotifyPropertyChanged("AllAbonents");
            }
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

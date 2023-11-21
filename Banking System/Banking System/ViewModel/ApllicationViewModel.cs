using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Banking_System.Models;

namespace Banking_System.ViewModel
{
    internal class ApllicationViewModel : INotifyPropertyChanged
    {
        private History selectedPhone;

        public ObservableCollection<History> Phones { get; set; }
        public History SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                OnPropertyChanged("SelectedPhone");
            }
        }

        public ApplicationViewModel()
        {
            History = new ObservableCollection<History>
            {
                new History { Title="iPhone 7", Company="Apple", Price=56000 },
                new History {Title="Galaxy S7 Edge", Company="Samsung", Price =60000 },
                new History {Title="Elite x3", Company="HP", Price=56000 },
                new History {Title="Mi5S", Company="Xiaomi", Price=35000 }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
      
    }
}

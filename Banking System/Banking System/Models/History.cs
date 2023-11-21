using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System.Models
{
    internal class History : INotifyPropertyChanged
    {
    
        string boughtTitle;
        private int cashHistory;

        public int PropCashHistory
        {
            get { return cashHistory; }
            set { 
                cashHistory = value;
                OnPropertyChanged("History");
            }
        }
        public string PropBoughtTitle
        {
            get { return boughtTitle; }
            set
            {
                boughtTitle = value;
                OnPropertyChanged("Title");
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

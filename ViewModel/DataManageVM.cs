using System;
using System.Collections.Generic;
using System.Text;
using EngineerKA_1._0.View;
using EngineerKA_1._0.Model;
using System.ComponentModel;

namespace EngineerKA_1._0.ViewModel
{

    public class DataManageVM : INotifyPropertyChanged
    {
        private List<CurrentSparePartsLog> allCurrentSpareParts = DataWorker.GetAllCurrentSpareParts();

        public List<CurrentSparePartsLog> AllCurrentSpareParts
        {
            get { return allCurrentSpareParts; }
            set
            { 
                allCurrentSpareParts = value;
                NotifyPropertyChanged("AllCurrentSpareParts");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


       
    }
    
}

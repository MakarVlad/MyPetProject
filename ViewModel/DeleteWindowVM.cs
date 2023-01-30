using EngineerKA_1._0.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace EngineerKA_1._0.ViewModel
{
    public class DeleteWindowVM : DataManageVM
    {
       
        private RelayCommand _deleteOkButton;
        private bool _removeAllDBRecords;
        private bool _removeSelectedTabRecords;
        private void OpenSuccessfullDeleteRecordsWindow()
        {
            MessageBox.Show
             (
               "Записи успешно удалены!",
               "Сообщение",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public RelayCommand DeleteOKButton
        {
            get
            {
                return _deleteOkButton ?? new RelayCommand(obj =>
                {
                    UpdateALLRecordsView();
                    Remover.Remove(RemoveAllDBRecords, RemoveSelectedTabRecords, SelectedTab);
                    UpdateALLRecordsView();
                    OpenSuccessfullDeleteRecordsWindow();
                });

            }
        }
        public bool RemoveAllDBRecords
        {
            get
            {
                return _removeAllDBRecords;
            }
            set
            {
                _removeAllDBRecords = value ? true : false;
                NotifyPropertyChanged("RemoveAllDBRecords");
            }
        }
        public bool RemoveSelectedTabRecords
        {
            get
            {
                return _removeSelectedTabRecords;
            }
            set
            {
                _removeSelectedTabRecords = value ? true : false;
                NotifyPropertyChanged("RemoveSelectedTabRecords");
            }
        }
    
       
      
    }
}

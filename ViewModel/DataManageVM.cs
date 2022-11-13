using System;
using System.Collections.Generic;
using System.Text;
using EngineerKA_1._0.View;
using EngineerKA_1._0.Model;
using System.ComponentModel;
using System.Windows;
using System.Collections.ObjectModel;

namespace EngineerKA_1._0.ViewModel
{

    public class DataManageVM : INotifyPropertyChanged

    {   
        private ObservableCollection<CurrentSparePartsLog> _allCurrentSpareParts = GetCollections.GetAllCurrentSpareParts();
        private ObservableCollection<AdmissionSpareParts> _allAdmissionSpareParts = GetCollections.GetAllAdmissionSpareParts();
        private ObservableCollection<ReceivedSpareParts> _allReceivedSpareParts = GetCollections.GetAllReceivedSP();
        private ObservableCollection<OutOfStockSpareParts> _allOutOfStockSP = GetCollections.GetAllOutOfStock();



        public ObservableCollection<CurrentSparePartsLog> AllCurrentSpareParts
        {
            get 
            {
                return _allCurrentSpareParts;
            
            }
            set
            {
                _allCurrentSpareParts = value;
                NotifyPropertyChanged("AllCurrentSpareParts");
            }
        }
        public ObservableCollection<AdmissionSpareParts> AllAdmissionSpareParts
        {
            get
            {
                return _allAdmissionSpareParts;

            }
            set
            {
                _allAdmissionSpareParts = value;
                NotifyPropertyChanged("AllAdmissionSpareParts");
            }
        }
        public ObservableCollection<ReceivedSpareParts> AllReceivedSP
        {
            get
            {
                return _allReceivedSpareParts;

            }
            set
            {
                _allReceivedSpareParts = value;
                NotifyPropertyChanged("AllReceivedSP");
            }
        }
        public ObservableCollection<OutOfStockSpareParts> AllOutOfStock
        {
            get
            {
                return _allOutOfStockSP;

            }
            set
            {
                _allOutOfStockSP = value;
                NotifyPropertyChanged("AllOutOfStock");
            }
        }
        public ObservableCollection<CurrentSparePartsLog> NewLog = new ObservableCollection<CurrentSparePartsLog>();




        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

   
           
        
        #region OPEN SPARE PARTS WINDOW
        public void OpenSparePartsWindow()
        {
            SpareParts spareParts = new SpareParts();
            spareParts.Show();
          
        }
     
        private RelayCommand _openSpareParts;
        public RelayCommand OpenSpareParts
        {
            get
            {
                return _openSpareParts ?? new RelayCommand(obj =>
                {
                    OpenSparePartsWindow();
                }
                );
            }
        }
        #endregion
        #region OPEN LOAD FROM FILE WINDOW
        
       
        internal void OpenLoadFromFileWindow()
        {
            LoadWindow loadWindow = new LoadWindow();
            loadWindow.ShowDialog();

        }





        private RelayCommand _openLoadWindow;
        public RelayCommand OpenLoadWindow
        {
            get
            {
                return _openLoadWindow ?? new RelayCommand(obj =>
                {

                    OpenLoadFromFileWindow();
                }
                );
            }

        }
        #endregion
        #region OPEN SEARCH WINDOW
        public void OpenSearchWindow()
        {
            SearchWindow searchWindow = new SearchWindow();
            searchWindow.ShowDialog();
        }

        private RelayCommand _openSearch;
        public RelayCommand OpenSearch
        {
            get
            {
                return _openSearch ?? new RelayCommand(obj =>
                {
                    OpenSearchWindow();
                }
                );
            }
        }
        #endregion
        #region OPEN UPDATE WINDOW
        private void OpenUpdateWindow()
        {
            UpdateWindow updateWindow = new UpdateWindow();
            updateWindow.ShowDialog();
        }

        private RelayCommand _openUpdate;
        public RelayCommand OpenUpdate
        {
            get
            {
                return _openUpdate ?? new RelayCommand(obj =>
                {
                    OpenUpdateWindow();
                }
                );
            }
        }
        #endregion

        #region DELETE ALL RECORDS IN DB  
        private RelayCommand _deleteAllDBRecords;
        public RelayCommand DeleteAllDBRecords
        {
            get
            {
                return _deleteAllDBRecords ?? new RelayCommand(obj =>
                {
                    UpdateALLRecordsView();
                    Remover.DeleteALLDataBaseRecords(AllCurrentSpareParts, AllAdmissionSpareParts,
                                                         AllReceivedSP, AllOutOfStock);
                    UpdateALLRecordsView();
                    OpenSuccessfullDeleteRecordsWindow();
                } );
                
            }
           
        }

        private void OpenSuccessfullDeleteRecordsWindow()
        {
            MessageBox.Show
             (
               "Все записи текущей таблицы успешно удалены из базы данных !",
               "Сообщение",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        #endregion
        #region UPDATE VIEWS                   
        public void UpdateALLRecordsView()                    
        {
            AllCurrentSpareParts = GetCollections.GetAllCurrentSpareParts();
            AllAdmissionSpareParts = GetCollections.GetAllAdmissionSpareParts();
            AllReceivedSP = GetCollections.GetAllReceivedSP();
            AllOutOfStock = GetCollections.GetAllOutOfStock();

            SpareParts.CurrentSPView.ItemsSource = AllCurrentSpareParts;
            SpareParts.AdmissionSPView.ItemsSource = AllAdmissionSpareParts;
            SpareParts.ReceivedSPView.ItemsSource = AllReceivedSP;
            SpareParts.OutOfStockView.ItemsSource = AllOutOfStock;

        }
        #endregion
    }

}

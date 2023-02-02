using System;
using System.Collections.Generic;
using System.Text;
using EngineerKA_1._0.View;
using EngineerKA_1._0.Model;
using System.ComponentModel;
using System.Windows;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace EngineerKA_1._0.ViewModel
{

    public class DataManageVM : INotifyPropertyChanged
    { 
        private ObservableCollection<CurrentSparePartsLog> _allCurrentSpareParts = GetCollections.GetAllCurrentSpareParts();
        private ObservableCollection<AdmissionSpareParts> _allAdmissionSpareParts = GetCollections.GetAllAdmissionSpareParts();
        private ObservableCollection<ReceivedSpareParts> _allReceivedSpareParts = GetCollections.GetAllReceivedSP();
        private ObservableCollection<OutOfStockSpareParts> _allOutOfStockSP = GetCollections.GetAllOutOfStock();
        private CurrentSparePartsLog _selected;
        private RelayCommand _openSearch;
        private RelayCommand _openSpareParts;
        private RelayCommand _openLoadWindow;
        private RelayCommand _openUpdate;
        private RelayCommand _openDeleteWindow;
        private RelayCommand _openCreateGropWindow; 
        private string _path;
        private static int _indexSelectedTab;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
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
        public ObservableCollection<CurrentSparePartsLog> SparePartsLog = new ObservableCollection<CurrentSparePartsLog>(); 
        public string LoadPath
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
            }
        }
        public CurrentSparePartsLog Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                NotifyPropertyChanged("Selected");
            }
        }
        public static int SelectedTab
        {
            get
            {
                return _indexSelectedTab;
            }
            set
            {
                _indexSelectedTab = value;
            }
        }

        #region OPEN SPARE PARTS WINDOW
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
        public void OpenSparePartsWindow()
        {
            SpareParts spareParts = new SpareParts();
            spareParts.Show();
          
        }
        #endregion
        #region OPEN LOAD FROM FILE WINDOW
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

        internal void OpenLoadFromFileWindow()
        {
            LoadWindow loadWindow = new LoadWindow();
            loadWindow.ShowDialog();

        }





        //private RelayCommand _openLoadWindow;

        #endregion
        #region OPEN SEARCH WINDOW
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
        public void OpenSearchWindow()
        {
            SearchWindow searchWindow = new SearchWindow();
            searchWindow.Show();
        }
        #endregion
        #region OPEN UPDATE WINDOW
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
        private void OpenUpdateWindow()
        {
            UpdateWindow updateWindow = new UpdateWindow();
            updateWindow.ShowDialog();
        }
        #endregion
        #region OPEN DELETE WINDOW
        public RelayCommand OpenDeleteWindow
        {
            get
            {
                return _openDeleteWindow ?? new RelayCommand(obj =>
                {
                    OpenDelWindow();
                }
                );
            }
        }
        private void OpenDelWindow()
        {

           
            DeleteWindow deleteWindow= new DeleteWindow();
            deleteWindow.Show();
            
        }
        #endregion
        #region OPEN CREATE GROUP WINDOW
        public RelayCommand OpenCreateteWindow
        {
            get
            {
                return _openCreateGropWindow ?? new RelayCommand(obj =>
                {
                    OpenCreateGroupWindow();
                }
                );
            }
        }
        private void OpenCreateGroupWindow()
        {


            CreateGroupWindow createGroup = new CreateGroupWindow();
            createGroup.Show();

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

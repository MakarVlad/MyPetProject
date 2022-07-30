using System;
using System.Collections.Generic;
using System.Text;
using EngineerKA_1._0.Model;
using EngineerKA_1._0.View;

namespace EngineerKA_1._0.ViewModel
{
     public class WindowOpenerVM
    {
        #region OPEN SPARE PARTS WINDOW
        private void OpenSparePartsWindow()
        {
            SpareParts spareParts = new SpareParts();
            spareParts.ShowDialog();
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
        private void OpenLoadFromFileWindow()
        {
            LoadWindow loadWindow = new LoadWindow();
            loadWindow.ShowDialog();
        }

        private RelayCommand _openLoadWindow;
        public RelayCommand OpenLoadWindow
        {
            get
            {
                return _openSpareParts ?? new RelayCommand(obj =>
                {
                    OpenLoadFromFileWindow();
                }
                );
            }
        }
        #endregion
        #region OPEN SEARCH WINDOW
        private void OpenSearchWindow()
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

        #region OPEN ERROR WINDOW
        #endregion
    }
}

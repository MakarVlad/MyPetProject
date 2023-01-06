using EngineerKA_1._0.Model;
using EngineerKA_1._0.Model.DataWorker;
using EngineerKA_1._0.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace EngineerKA_1._0.ViewModel
{
    public class SearcherVM : DataManageVM
    {
        private string _searchString;
        private CurrentSparePartsLog _selected;
        private ObservableCollection<CurrentSparePartsLog> _searchResult = new ObservableCollection<CurrentSparePartsLog>();
        private RelayCommand _searchButton;
        private bool _clear ;
        public string SearchString 
        { 
            get
            {
               return _searchString;
            } 
            set
            {
                _searchString = value;
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
                _selected = value ; 
                NotifyPropertyChanged("Selected");
            }
        }
        public bool Clear
        {
            get
            {
                return _clear;
            }
            set
            {
                _clear = value;
            }
        }
        public ObservableCollection<CurrentSparePartsLog> SearchResult
        {
            get
            {
                return _searchResult;

            }
            set
            {
                _searchResult = value;
            }
        }
        public RelayCommand SearchButton
        {
            get
            {
                return _searchButton ?? new RelayCommand(obj =>
                {
                    if (_clear == true) Searcher.SearchResultCleaner(SearchResult);
                    if (_searchString != null)
                    {
                        Searcher.Search(_searchString.ToLower(), AllCurrentSpareParts, SearchResult);
                    }
                    Selected = AllCurrentSpareParts.FirstOrDefault(s => s.NamePart.Contains(SearchString) || s.PartCode.Contains(SearchString));
                    SpareParts.CurrentSPView.SelectedItem = Selected;
                    Scroll();
                   Clear = true;
                });

            }
        }
        private void Scroll()
        {
            if(Selected != null)
            {
                SpareParts.CurrentSPView.ScrollIntoView(Selected);
            }
            
        }
    }
}

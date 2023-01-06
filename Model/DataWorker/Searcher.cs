using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using EngineerKA_1._0.ViewModel;

namespace EngineerKA_1._0.Model.DataWorker
{
  public class Searcher
  {
        public static void Search(string _searchString, ObservableCollection<CurrentSparePartsLog>AllCurrentSpareParts, ObservableCollection<CurrentSparePartsLog>SearchResult)
        {
          
            foreach (CurrentSparePartsLog sparePart in AllCurrentSpareParts)
            {

                if (sparePart.NamePart.ToLower().Contains(_searchString) ||
                    sparePart.PartCode.ToLower().Contains(_searchString))
                {
                    SearchResult.Add(sparePart);
                }
            }
       
        }
        public static void SearchResultCleaner(ObservableCollection<CurrentSparePartsLog> SearchResult)
        {
            SearchResult.Clear();
        }
  }
}

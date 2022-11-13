using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EngineerKA_1._0.Model
{
     public class GetCollections
     {
        public static ObservableCollection<CurrentSparePartsLog> GetAllCurrentSpareParts()
        {
            ObservableCollection<CurrentSparePartsLog> resultCurrentSP = new ObservableCollection<CurrentSparePartsLog>();
            using (Data.AppContext db = new Data.AppContext())
            {
                foreach (CurrentSparePartsLog current in db.CurrentSpareParts)
                {
                    resultCurrentSP.Add(current);
                }
                return resultCurrentSP;
            }
        }
        public static ObservableCollection<AdmissionSpareParts> GetAllAdmissionSpareParts()
        {
            ObservableCollection<AdmissionSpareParts> result = new ObservableCollection<AdmissionSpareParts>();
            using (Data.AppContext db = new Data.AppContext())
            {
                foreach (AdmissionSpareParts admission in db.AdmissionSpareParts)
                {
                    result.Add(admission);
                }
                return result;
            }
        }
        public static ObservableCollection<ReceivedSpareParts> GetAllReceivedSP()
        {
            ObservableCollection<ReceivedSpareParts> receivedSP = new ObservableCollection<ReceivedSpareParts>();
            using (Data.AppContext db = new Data.AppContext())
            {
                foreach (ReceivedSpareParts received in db.ReceivedSpareParts)
                {
                    receivedSP.Add(received);
                }
                return receivedSP;
            }
        }
        public static ObservableCollection<OutOfStockSpareParts> GetAllOutOfStock()
        {
            ObservableCollection<OutOfStockSpareParts> OutOfStockSP = new ObservableCollection<OutOfStockSpareParts>();
            using (Data.AppContext db = new Data.AppContext())
            {
                foreach (OutOfStockSpareParts outOfStock in db.OutOfStockSpareParts)
                {
                    OutOfStockSP.Add(outOfStock);
                }
                return OutOfStockSP;
            }
        }
     }
}

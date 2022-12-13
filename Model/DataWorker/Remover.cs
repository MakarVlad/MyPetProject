using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace EngineerKA_1._0.Model
{
    public class Remover
    {
        public static void RemoveAll(ObservableCollection<CurrentSparePartsLog> AllCurrentSpareParts,
                              ObservableCollection<ReceivedSpareParts> AllReceivedSP,
                              ObservableCollection<AdmissionSpareParts> AllAdmissionSpareParts,
                              ObservableCollection<OutOfStockSpareParts> AllOutOfStock)
                              
        {
            Parallel.Invoke
                (
                  () => RemoveAllCurrentSpareParts(AllCurrentSpareParts),
                  () => RemoveAllReceived(AllReceivedSP),
                  () => RemoveAllAdmissionSpareParts(AllAdmissionSpareParts),
                  () => RemoveAllOutOfStockSpareParts(AllOutOfStock)

                ) ;

        }
        private static void RemoveAllCurrentSpareParts(ObservableCollection<CurrentSparePartsLog> AllCurrentSpareParts)
        {
            using (Data.AppContext db = new Data.AppContext())
            {
                foreach (CurrentSparePartsLog currentSparePartsRecord in AllCurrentSpareParts)
                {
                    if (db.CurrentSpareParts != null && AllCurrentSpareParts != null)
                    {
                        db.CurrentSpareParts.Remove(currentSparePartsRecord);
                        db.SaveChanges();
                    }
                }
            }
        }
        private static void RemoveAllReceived(ObservableCollection<ReceivedSpareParts> AllReceivedSP)
        {
            using (Data.AppContext db = new Data.AppContext())
            {
                foreach (ReceivedSpareParts receivedSparePartsRecord in AllReceivedSP)
                {
                    if (db.ReceivedSpareParts != null && AllReceivedSP != null)
                    {
                        db.ReceivedSpareParts.Remove(receivedSparePartsRecord);
                        db.SaveChanges();
                    }
                }
            }

        }
        private static void RemoveAllAdmissionSpareParts(ObservableCollection<AdmissionSpareParts> AllAdmissionSpareParts)
        {
            using (Data.AppContext db = new Data.AppContext())
            {
                foreach (AdmissionSpareParts admissionSparePartsRecord in AllAdmissionSpareParts)
                {
                    if (db.AdmissionSpareParts != null && AllAdmissionSpareParts != null)
                    {
                        db.AdmissionSpareParts.Remove(admissionSparePartsRecord);
                        db.SaveChanges();
                    }
                }
            }

        }
        private static void RemoveAllOutOfStockSpareParts(ObservableCollection<OutOfStockSpareParts> AllOutOfStock)
        {
            using (Data.AppContext db = new Data.AppContext())
            {
                foreach (OutOfStockSpareParts outOfStock in AllOutOfStock)
                {
                    if (db.OutOfStockSpareParts != null && AllOutOfStock != null)
                    {
                        db.OutOfStockSpareParts.Remove(outOfStock);
                        db.SaveChanges();
                    }
                }
            }

        }
    }
}          
       

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EngineerKA_1._0.Model
{
     public class Remover
     {
        public static void DeleteALLDataBaseRecords(ObservableCollection<CurrentSparePartsLog> AllCurrentSpareParts, 
                                                   ObservableCollection<AdmissionSpareParts> AllAdmissionSpareParts, ObservableCollection<ReceivedSpareParts> AllReceivedSP,
                                                   ObservableCollection<OutOfStockSpareParts> AllOutOfStock)
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
                foreach (AdmissionSpareParts admissionSparePartsRecord in AllAdmissionSpareParts)
                {
                    if (db.AdmissionSpareParts != null && AllAdmissionSpareParts != null)
                    {
                        db.AdmissionSpareParts.Remove(admissionSparePartsRecord);
                        db.SaveChanges();
                    }
                }
                foreach (ReceivedSpareParts receivedSparePartsRecord in AllReceivedSP)
                {
                    if (db.ReceivedSpareParts != null && AllReceivedSP != null)
                    {
                        db.ReceivedSpareParts.Remove(receivedSparePartsRecord);
                        db.SaveChanges();
                    }
                }
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

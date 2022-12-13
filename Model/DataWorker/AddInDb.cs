using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineerKA_1._0.Model
{
    public class AddInDb
    {
        public static void CompareCollections(ObservableCollection<CurrentSparePartsLog> AllCurrentSpareParts,
                                              ObservableCollection<CurrentSparePartsLog> NewLog,
                                              ObservableCollection<CurrentSparePartsLog>SparePartsLog,string _log)
        {
            if(_log == "SparePartsLog")
            {
                AddSparePartsLog(SparePartsLog);
            }
            if (_log == "NewLog")
            {
                var missingInNewlog = AllCurrentSpareParts.Except(NewLog).ToList();
                var missingInCurrentLog = NewLog.Except(AllCurrentSpareParts).ToList();
                var listCurrentLog = AllCurrentSpareParts.ToList();
                if (missingInCurrentLog.Count != 0)
                {
                    foreach (CurrentSparePartsLog rec in missingInCurrentLog)
                    {
                        CurrentSparePartsLog found = listCurrentLog.Find(item => item.NamePart.Equals(rec.NamePart)
                                                                                 && item.CellCode.Equals(rec.CellCode));
                        if (found != null)
                        {
                            if (found.Amount > rec.Amount)
                            {
                             AddOnlyInReceived(rec);
                            }
                            if (found.Amount < rec.Amount)
                            {
                             AddInAdmission(rec);
                            }
                        }
                        if (found == null)
                        {

                         AddInAdmission(rec);
                        }
                    }
                }
                if (missingInCurrentLog.Count == 0 || missingInCurrentLog.Count < missingInNewlog.Count || missingInCurrentLog.Count == missingInNewlog.Count)
                {
                    foreach (CurrentSparePartsLog rec in missingInNewlog)
                    {
                        CurrentSparePartsLog found = missingInCurrentLog.Find(item => item.NamePart == rec.NamePart
                                                                                      && item.CellCode == item.CellCode);
                        if (missingInCurrentLog.Count == 0 || found == null)
                        {

                         AddInReceivedAndOutOfStock(rec);
                        }
                    }
                }
            }
        }

        private static void AddSparePartsLog(ObservableCollection<CurrentSparePartsLog> SparePartsLog)
        {
            using(Data.AppContext db = new Data.AppContext())
            {
                foreach (CurrentSparePartsLog SP in SparePartsLog)
                {
                    bool recordExist = db.CurrentSpareParts.Any(rec => rec.PartCode == SP.PartCode
                                                                           && rec.NamePart == SP.NamePart
                                                                           && rec.CellCode == SP.CellCode
                                                                           && rec.Amount == SP.Amount);
                    if (!recordExist)
                    {
                        db.CurrentSpareParts.Add(SP);
                    }
                }
                db.SaveChanges();
            }
        }
        private static void AddInAdmission(CurrentSparePartsLog currentSpare)
        {
            using (Data.AppContext db = new Data.AppContext())
            {
                AdmissionSpareParts admissionSpare = new AdmissionSpareParts()
                {
                    PartCode = currentSpare.PartCode,
                    NamePart = currentSpare.NamePart,
                    CellCode = currentSpare.CellCode,
                    UnitPart = currentSpare.UnitPart,
                    Amount = currentSpare.Amount,
                    Price = currentSpare.Price
                };
                foreach (CurrentSparePartsLog currentSP in db.CurrentSpareParts)
                {
                    if (admissionSpare.NamePart == currentSP.NamePart && admissionSpare.CellCode == currentSP.CellCode)
                    {
                        if (currentSP.Amount != 0 && currentSP.Price != 0)
                        {
                            currentSP.PriceForOne = currentSP.Price / currentSP.Amount;
                        }
                        else
                        {
                            currentSP.PriceForOne = currentSP.Price;
                        }
                        admissionSpare.Amount = currentSpare.Amount - currentSP.Amount;
                        currentSP.Amount = currentSpare.Amount;
                        currentSP.Price = currentSpare.Price;
                        admissionSpare.Price = currentSP.PriceForOne * admissionSpare.Amount;
                    }

                }
                bool recordExist = db.CurrentSpareParts.Any(rec => rec.PartCode == currentSpare.PartCode
                                                                                            && rec.NamePart == currentSpare.NamePart
                                                                                            && rec.CellCode == currentSpare.CellCode);
                if (!recordExist)
                {
                    db.CurrentSpareParts.Add(currentSpare);
                }

                db.AdmissionSpareParts.Add(admissionSpare);
                db.SaveChanges();
            }
        }
        private static void AddInReceivedAndOutOfStock(CurrentSparePartsLog currentSpare)
        {
            using (Data.AppContext db = new Data.AppContext())
            {
                ReceivedSpareParts receivedSpareParts = new ReceivedSpareParts()
                {
                    PartCode = currentSpare.PartCode,
                    NamePart = currentSpare.NamePart,
                    CellCode = currentSpare.CellCode,
                    Amount = currentSpare.Amount,
                    UnitPart = currentSpare.UnitPart,
                    Price = currentSpare.Price

                };
                OutOfStockSpareParts outOfStock = new OutOfStockSpareParts()
                {
                    PartCode = currentSpare.PartCode,
                    NamePart = currentSpare.NamePart,
                    CellCode = currentSpare.CellCode,
                    Amount = currentSpare.Amount,
                    UnitPart = currentSpare.UnitPart,
                    Price = currentSpare.Price
                };
                db.ReceivedSpareParts.Add(receivedSpareParts);
                db.OutOfStockSpareParts.Add(outOfStock);
                db.CurrentSpareParts.Remove(currentSpare);
                db.SaveChanges();
            }
        }
        private static void AddOnlyInReceived(CurrentSparePartsLog currentSpare)
        {
            using (Data.AppContext db = new Data.AppContext())
            {

                ReceivedSpareParts receivedSpareParts = new ReceivedSpareParts()
                {
                    PartCode = currentSpare.PartCode,
                    NamePart = currentSpare.NamePart,
                    CellCode = currentSpare.CellCode,
                    UnitPart = currentSpare.UnitPart
                };

                foreach (CurrentSparePartsLog currentSP in db.CurrentSpareParts)
                {
                    if (receivedSpareParts.NamePart == currentSP.NamePart && receivedSpareParts.CellCode == currentSP.CellCode)
                    {
                        if (currentSP.Amount != 0 && currentSP.Price != 0)
                        {
                            currentSP.PriceForOne = currentSP.Price / currentSP.Amount;
                        }
                        else
                        {
                            currentSP.PriceForOne = currentSP.Price;
                        }
                        receivedSpareParts.Amount = currentSP.Amount - currentSpare.Amount;
                        currentSP.Amount -= receivedSpareParts.Amount;
                        currentSP.Price = currentSpare.Price;
                        receivedSpareParts.Price = currentSP.PriceForOne * receivedSpareParts.Amount;
                    }
                }
                db.ReceivedSpareParts.Add(receivedSpareParts);
                db.SaveChanges();
            }
        }
        
    }
}

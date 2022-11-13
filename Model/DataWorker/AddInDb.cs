using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace EngineerKA_1._0.Model
{
    public class AddInDb
    {
        public static void CompareCollections(ObservableCollection<CurrentSparePartsLog> AllCurrentSpareParts,
                                              ObservableCollection<CurrentSparePartsLog> NewLog)
        {
            var missingInNewlog = AllCurrentSpareParts.Except(NewLog).ToList();
            var missingInCurrentLog = NewLog.Except(AllCurrentSpareParts).ToList();
            var listCurrentLog = AllCurrentSpareParts.ToList();
            if (missingInCurrentLog.Count != 0)
            {
                foreach (CurrentSparePartsLog rec in missingInCurrentLog)
                {
                    CurrentSparePartsLog found = listCurrentLog.Find(item => item.NamePart == rec.NamePart);
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
                    CurrentSparePartsLog found = missingInCurrentLog.Find(item => item.NamePart.Equals(rec.NamePart));
                    if (missingInCurrentLog.Count == 0 || found == null)
                    {

                        AddInReceivedAndOutOfStock(rec);
                    }
                }
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
                    Amount = currentSpare.Amount

                };
                foreach (CurrentSparePartsLog currentSP in db.CurrentSpareParts)
                {
                    if (admissionSpare.NamePart == currentSP.NamePart)
                    {
                        currentSP.PriceForOne = currentSP.Price / currentSP.Amount;
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
                    if (receivedSpareParts.NamePart == currentSP.NamePart)
                    {
                        currentSP.PriceForOne = currentSP.Price / currentSP.Amount;
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

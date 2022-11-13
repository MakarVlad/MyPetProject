using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace EngineerKA_1._0.Model
{
     public class FileReader
    {
        public static void ReadTxtFile(string _path, string _log, ObservableCollection<CurrentSparePartsLog> NewLog)

        {
            using (StreamReader sr = new StreamReader(_path, Encoding.Unicode))
            {
                string[] dataLine;
                string line;

                using (Data.AppContext db = new Data.AppContext())
                {

                    while ((line = sr.ReadLine()) != null)
                    {
                        CurrentSparePartsLog currentSparePartsLog = new CurrentSparePartsLog();

                        dataLine = line.Split('\t');
                        if (_log == "CurrentLog" && dataLine[0] != "")
                        {
                            currentSparePartsLog.PartCode = dataLine[0];
                            currentSparePartsLog.NamePart = dataLine[1];
                            currentSparePartsLog.CellCode = dataLine[2];
                            currentSparePartsLog.UnitPart = dataLine[3];
                            currentSparePartsLog.Amount = int.Parse(dataLine[4]);
                            currentSparePartsLog.Price = decimal.Parse(dataLine[5]);

                            bool recordExist = db.CurrentSpareParts.Any(rec => rec.PartCode == currentSparePartsLog.PartCode
                                                                                            && rec.NamePart == currentSparePartsLog.NamePart
                                                                                            && rec.CellCode == currentSparePartsLog.CellCode
                                                                                            && rec.Amount == currentSparePartsLog.Amount);
                            if (!recordExist)
                            {
                                db.CurrentSpareParts.Add(currentSparePartsLog);
                            }
                        }
                        if (_log == "NewLog" && dataLine[0] != "")
                        {
                            currentSparePartsLog.PartCode = dataLine[0];
                            currentSparePartsLog.NamePart = dataLine[1];
                            currentSparePartsLog.CellCode = dataLine[2];
                            currentSparePartsLog.UnitPart = dataLine[3];
                            currentSparePartsLog.Amount = int.Parse(dataLine[4]);
                            currentSparePartsLog.Price = decimal.Parse(dataLine[5]);
                            NewLog.Add(currentSparePartsLog);
                        }
                    }
                    db.SaveChanges();
                }
            }
        }
    }
}

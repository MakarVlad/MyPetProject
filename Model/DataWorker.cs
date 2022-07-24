using System;
using System.Collections.Generic;
using System.Text;
using EngineerKA_1._0.ViewModel;
using EngineerKA_1._0.Model.Data;
using EngineerKA_1._0.View;
using System.IO;
using System.Linq;


namespace EngineerKA_1._0.Model
{
    public class DataWorker
    {
        //метод для загрузки данных из файла и заполнения таблицы  текущий журнал
        public static void CreateCurrentSparePartsFromTxtFile(string path)

        {

            using (StreamReader sr = new StreamReader(path) )
            {

                string[] dateLine;
                string line;

                using (Data.AppContext db = new Data.AppContext())
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        dateLine = line.Split('\t');

                        CurrentSparePartsLog currentSparePartsLog = new CurrentSparePartsLog()
                        {
                            PartCode = dateLine[0],
                            NamePart = dateLine[1],
                            CellCode = dateLine[2],
                            UnitPart = dateLine[3],
                            Amount = int.Parse(dateLine[4]),
                            Price = decimal.Parse(dateLine[5])
                        };
                        bool recordExist = db.CurrentSpareParts.Any(rec => rec.PartCode == currentSparePartsLog.PartCode 
                                                                   && rec.NamePart == currentSparePartsLog.NamePart 
                                                                   && rec.CellCode == currentSparePartsLog.CellCode 
                                                                   && rec.Amount == currentSparePartsLog.Amount);
                        if (!recordExist)
                        {
                            db.CurrentSpareParts.Add(currentSparePartsLog);
                        }   
                    }

                    db.SaveChanges();
                }

            }
        }

        //метод для получения записей из таблицы Current БД  списком
        public static List<CurrentSparePartsLog> GetAllCurrentSpareParts()
        {
            using (Data.AppContext db = new Data.AppContext())
            {
                var resultList = db.CurrentSpareParts.ToList();
                return resultList;

            }
        }

        //метод для удаления записей из таблицы Current БД
      
    }
}

using EngineerKA_1._0.Model.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EngineerKA_1._0.Model
{
     public class FileReader
    {
        public  static void ReadTxtFile(string _path, string _log, ObservableCollection<CurrentSparePartsLog> SparePartsLog,
                                        ObservableCollection<CurrentSparePartsLog> NewLog)

        {
            using ( StreamReader sr = new StreamReader(_path, Encoding.GetEncoding(1251)))
            {
                string[] dataLine;
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    CurrentSparePartsLog currentSparePartsLog = new CurrentSparePartsLog();
                        bool _skip = false;
                        dataLine = line.Split('\t');
                        if ( dataLine[0] != "")
                        {
                          try
                          {
                                currentSparePartsLog.PartCode = dataLine[0];
                                currentSparePartsLog.NamePart = dataLine[1];
                                currentSparePartsLog.CellCode = dataLine[4];
                                currentSparePartsLog.UnitPart = dataLine[5];
                            if (int.Parse(dataLine[6]) != 0 && decimal.Parse(dataLine[7]) > 0)
                            {
                                currentSparePartsLog.Amount = int.Parse(dataLine[6]);
                                currentSparePartsLog.Price = decimal.Parse(dataLine[7]);
                            }
                            else _skip = true; 
                            if (_log == "SparePartsLog" && _skip == false)
                            {
                           
                                SparePartsLog.Add(currentSparePartsLog);
                              
                            }
                          }
                          catch (FormatException)
                          { 
                            _skip = true;
                          }
                         
                            if(_log == "NewLog" && _skip == false)
                            {
                                NewLog.Add(currentSparePartsLog);
                            }
                        }
                }
            }
        }
     }
}

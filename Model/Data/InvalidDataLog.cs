using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EngineerKA_1._0.Model.Data
{
    public class InvalidDataLog
    {
        public async static void WriteInvalidDataInTxtFile(CurrentSparePartsLog currentSpare)
        {
            string path = @"C:\Users\HP\Desktop\InvalidData.txt";
            using (StreamWriter sw = new StreamWriter(path, true, Encoding.Unicode))
            {
                await sw.WriteAsync($"{ currentSpare.PartCode}\t");
                await sw.WriteAsync($"{ currentSpare.NamePart}\t");
                await sw.WriteAsync($"{ currentSpare.CellCode}\t");
                await sw.WriteAsync($"{ currentSpare.UnitPart}\t");
                await sw.WriteAsync($"{ currentSpare.Amount}\t");
                await sw.WriteAsync($"{ currentSpare.Price}\n");
                await sw.WriteLineAsync();
                
            }
        }
    }
}

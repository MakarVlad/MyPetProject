using System;
using System.Collections.Generic;
using System.Text;

namespace EngineerKA_1._0.Model
{
    class CurrentSparePartsLog
    {
        public int Id { get; set; }
        public string PartCode { get; set; }
        public string NamePart { get; set; }
        public string CellCode { get; set; }
        public string UnitPart { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}

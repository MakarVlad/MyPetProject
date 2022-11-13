using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EngineerKA_1._0.Model
{
    public class CurrentSparePartsLog : IEquatable<CurrentSparePartsLog>
    {
       
        public int Id { get; set; }
        public string PartCode { get; set; }
        public string NamePart { get; set; }
        public string CellCode { get; set; }
        public string UnitPart { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        [NotMapped]
        public decimal PriceForOne { get; set; }
   
        public bool Equals(CurrentSparePartsLog other)
        {
            if (other is null)
                return false;
            return this.NamePart == other.NamePart && this.Amount == other.Amount;
        }
        public override bool Equals(object obj) => Equals(obj as CurrentSparePartsLog);
        public override int GetHashCode() => (NamePart, Amount).GetHashCode();
        

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EngineerKA_1._0.Model.Data
{
    class AppContext : DbContext
    {
        public DbSet<CurrentSparePartsLog> CurrentSpareParts { get; set; }
        public DbSet<NewSparePartsLog> NewSpareParts { get; set; }
        public DbSet<AdmissionSpareParts> AdmissionSpareParts { get; set; }
        public DbSet<OutOfStockSpareParts> OutOfStockSpareParts { get; set; }
        public DbSet<ReceivedSpareParts> ReceivedSpareParts { get; set; }

        public AppContext() 
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SparePartManageDB;Trusted_Connection=True;");
        }
          
    }
}

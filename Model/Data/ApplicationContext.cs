using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TelephoneCompanyApp.Model;

namespace TelephoneCompanyApp.Model.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Abonent> Abonents { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Streets> Streets { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TelephoneCompanyApp;Trusted_Connection=True;");
        }
    }
}

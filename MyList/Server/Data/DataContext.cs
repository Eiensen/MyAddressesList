using Microsoft.EntityFrameworkCore;
using MyList.Shared;
using System;

namespace MyList.Server.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seeding some data
            modelBuilder.Entity<Address>().HasData(
                new Address { Id = 1, DateMeasurment = DateTime.Now.Date, DateMontage = DateTime.Now.Date, Name = "str. Nova 99", Sum = 11500, WorkersName = "Александр" },
                new Address { Id = 2, DateMeasurment = DateTime.Now.Date, DateMontage = DateTime.Now.Date, Name = "str. Dobor 1", Sum = 9300, WorkersName = "Броня" },
                new Address { Id = 3, DateMeasurment = DateTime.Now.Date, DateMontage = DateTime.Now.Date, Name = "str. Znaniya 12", Sum = 8200, WorkersName = "Дима" }
                );
        }

        public DbSet<Address> Addresses { get; set; }
    }
}

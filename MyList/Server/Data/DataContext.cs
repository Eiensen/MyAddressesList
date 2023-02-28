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

        public DbSet<Address> Addresses { get; set; }
    }
}

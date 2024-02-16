using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CustomerDatabaseAPI.Models;

namespace CustomerDatabaseAPI.Data
{
    public class CustomerDatabaseAPIContext : DbContext
    {
        public CustomerDatabaseAPIContext (DbContextOptions<CustomerDatabaseAPIContext> options)
            : base(options)
        {
        }

        public DbSet<CustomerDatabaseAPI.Models.CustomerInformation> CustomerInformation { get; set; } = default!;
    }
}

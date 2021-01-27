using DemoRazorPages.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRazorPages.Data
{
    public class CustomersDbContext : DbContext
    {
        public CustomersDbContext(DbContextOptions<CustomersDbContext> opzioni) : base(opzioni)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}

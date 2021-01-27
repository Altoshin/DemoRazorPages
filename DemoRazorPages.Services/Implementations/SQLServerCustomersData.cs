using DemoRazorPages.Data;
using DemoRazorPages.Model;
using DemoRazorPages.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoRazorPages.Services.Implementations
{
    public class SQLServerCustomersData : ICustomersData
    {
        private readonly CustomersDbContext _customersDbContext;

        public SQLServerCustomersData(CustomersDbContext customersDbContext)
        {
            _customersDbContext = customersDbContext;
        }

        public async Task Add(Customer customer)
        {
            _customersDbContext.Customers.Add(customer);
            await _customersDbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var customer = new Customer() { Id = id };
            _customersDbContext.Customers.Attach(customer).State = EntityState.Deleted;
            await _customersDbContext.SaveChangesAsync();
        }

        public async Task Edit(Customer customer)
        {
            _customersDbContext.Customers.Attach(customer).State = EntityState.Modified;
            await _customersDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> Get()
        {
            return await _customersDbContext.Customers.ToListAsync();
        }

        public async Task<Customer> Get(int id)
        {
            return await _customersDbContext.Customers.FindAsync(id);
        }
    }
}

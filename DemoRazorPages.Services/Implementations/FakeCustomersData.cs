using DemoRazorPages.Model;
using DemoRazorPages.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoRazorPages.Services.Implementations
{
    public class FakeCustomersData : ICustomersData
    {
        static List<Customer> customers = new List<Customer>();

        public async Task Add(Customer customer)
        {
            customers.Add(customer);

            await Task.Delay(200);
        }

        public async Task Delete(int id)
        {
            var customer = customers.Where(x => x.Id == id).SingleOrDefault();
            customers.Remove(customer);

            await Task.Delay(200);
        }

        public async Task Edit(Customer customer)
        {
            var cust = customers.Where(x => x.Id == customer.Id).SingleOrDefault();
            customers.Remove(cust);
            customers.Add(customer);

            await Task.Delay(200);
        }

        public async Task<IEnumerable<Customer>> Get()
        {
            await Task.Delay(200);

            return customers;
        }

        public async Task<Customer> Get(int id)
        {
            await Task.Delay(200);

            return customers.FirstOrDefault(x => x.Id == id);
        }
    }
}

using DemoRazorPages.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoRazorPages.Services.Interfaces
{
    public interface ICustomersData
    {
        Task<IEnumerable<Customer>> Get();

        Task<Customer> Get(int id);

        Task Add(Customer customer);

        Task Edit(Customer customer);

        Task Delete(int id);
    }
}

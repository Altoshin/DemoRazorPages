using DemoRazorPages.Data;
using DemoRazorPages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using DemoRazorPages.Services.Interfaces;

namespace DemoRazorPages.Pages
{
    public class CustomersModel : PageModel
    {
        private readonly ICustomersData _customersData;

        [TempData]
        public string Message { get; set; }

        public CustomersModel(ICustomersData customersData)
        {
            _customersData = customersData;
        }

        public List<Customer> Customers { get; set; }
        public bool HasCustomers => Customers.Count > 0;
        public bool ShowMessage => !string.IsNullOrEmpty(Message);

        public async Task OnGetAsync()
        {
            Customers = (await _customersData.Get()).ToList();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _customersData.Delete(id);

            Message = $"Utente numero { id } cancellato";
            return RedirectToPage();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoRazorPages.Data;
using DemoRazorPages.Model;
using DemoRazorPages.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoRazorPages.Pages
{
    public class NewCustomerModel : PageModel
    {
        private readonly ICustomersData _customersData;

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Customer Customer { get; set; }

        public NewCustomerModel(ICustomersData customersData)
        {
            _customersData = customersData;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _customersData.Add(Customer);

            Message = $"Customer { Customer.FirstName } { Customer.LastName } was created";

            return RedirectToPage("Customers");
        }
    }
}

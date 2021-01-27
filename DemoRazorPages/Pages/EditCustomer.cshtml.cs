using DemoRazorPages.Data;
using DemoRazorPages.Model;
using DemoRazorPages.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DemoRazorPages.Pages
{
    public class EditCustomerModel : PageModel
    {
        private readonly ICustomersData _customersData;

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Customer Customer { get; set; }

        public EditCustomerModel(ICustomersData customersData)
        {
            _customersData = customersData;
        }

        public async Task OnGet(int id)
        {
            Customer = await _customersData.Get(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _customersData.Edit(Customer);

            Message = $"Customer {Customer.FirstName} {Customer.LastName} edited successfully";

            return RedirectToPage("Customers");
        }
    }
}

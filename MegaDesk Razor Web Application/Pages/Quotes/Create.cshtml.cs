using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDesk_Razor_Web_Application.Data;
using MegaDesk_Razor_Web_Application.Models;

namespace MegaDesk_Razor_Web_Application.Pages.Quotes
{
    public class CreateModel : PageModel
    {
        private readonly MegaDesk_Razor_Web_Application.Data.MegaDesk_Razor_Web_ApplicationContext _context;

        public CreateModel(MegaDesk_Razor_Web_Application.Data.MegaDesk_Razor_Web_ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Quote Quote { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Quote.Add(Quote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

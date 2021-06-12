using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDesk_Razor_Web_Application.Data;
using MegaDesk_Razor_Web_Application.Models;

namespace MegaDesk_Razor_Web_Application.Pages.Quotes
{
    public class IndexModel : PageModel
    {
        private readonly MegaDesk_Razor_Web_Application.Data.MegaDesk_Razor_Web_ApplicationContext _context;

        public IndexModel(MegaDesk_Razor_Web_Application.Data.MegaDesk_Razor_Web_ApplicationContext context)
        {
            _context = context;
        }

        public IList<Quote> Quote { get;set; }

        public async Task OnGetAsync()
        {
            Quote = await _context.Quote.ToListAsync();
        }
    }
}

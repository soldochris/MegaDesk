using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MegaDesk_Razor_Web_Application.Models;

namespace MegaDesk_Razor_Web_Application.Data
{
    public class MegaDesk_Razor_Web_ApplicationContext : DbContext
    {
        public MegaDesk_Razor_Web_ApplicationContext (DbContextOptions<MegaDesk_Razor_Web_ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<MegaDesk_Razor_Web_Application.Models.Quote> Quote { get; set; }
    }
}

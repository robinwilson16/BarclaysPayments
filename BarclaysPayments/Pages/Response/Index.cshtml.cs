using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BarclaysPayments.Data;
using BarclaysPayments.Models;

namespace BarclaysPayments.Pages.Response
{
    public class IndexModel : PageModel
    {
        private readonly BarclaysPayments.Data.ApplicationDbContext _context;

        public IndexModel(BarclaysPayments.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<BarclaysResponse> BarclaysResponse { get;set; }

        public async Task OnGetAsync()
        {
            BarclaysResponse = await _context.BarclaysResponse.ToListAsync();
        }
    }
}

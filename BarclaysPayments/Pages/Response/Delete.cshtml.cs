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
    public class DeleteModel : PageModel
    {
        private readonly BarclaysPayments.Data.ApplicationDbContext _context;

        public DeleteModel(BarclaysPayments.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BarclaysResponse BarclaysResponse { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BarclaysResponse = await _context.BarclaysResponse.FirstOrDefaultAsync(m => m.BarclaysResponseID == id);

            if (BarclaysResponse == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BarclaysResponse = await _context.BarclaysResponse.FindAsync(id);

            if (BarclaysResponse != null)
            {
                _context.BarclaysResponse.Remove(BarclaysResponse);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

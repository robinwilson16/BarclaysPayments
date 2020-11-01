using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BarclaysPayments.Data;
using BarclaysPayments.Models;
using Microsoft.AspNetCore.Authorization;

namespace BarclaysPayments.Pages.Payments
{
    [Authorize(Roles = "ALLSTAFF")]
    public class DeleteModel : PageModel
    {
        private readonly BarclaysPayments.Data.ApplicationDbContext _context;

        public DeleteModel(BarclaysPayments.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BarclaysPayment BarclaysPayment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BarclaysPayment = await _context.BarclaysPayment.FirstOrDefaultAsync(m => m.BarclaysPaymentID == id);

            if (BarclaysPayment == null)
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

            BarclaysPayment = await _context.BarclaysPayment.FindAsync(id);

            if (BarclaysPayment != null)
            {
                _context.BarclaysPayment.Remove(BarclaysPayment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

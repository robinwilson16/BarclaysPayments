using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarclaysPayments.Data;
using BarclaysPayments.Models;
using Microsoft.AspNetCore.Authorization;

namespace BarclaysPayments.Pages.Payments
{
    [Authorize(Roles = "ALLSTAFF")]
    public class EditModel : PageModel
    {
        private readonly BarclaysPayments.Data.ApplicationDbContext _context;

        public EditModel(BarclaysPayments.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BarclaysPayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarclaysPaymentExists(BarclaysPayment.BarclaysPaymentID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BarclaysPaymentExists(int id)
        {
            return _context.BarclaysPayment.Any(e => e.BarclaysPaymentID == id);
        }
    }
}

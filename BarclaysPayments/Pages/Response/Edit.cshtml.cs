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

namespace BarclaysPayments.Pages.Response
{
    public class EditModel : PageModel
    {
        private readonly BarclaysPayments.Data.ApplicationDbContext _context;

        public EditModel(BarclaysPayments.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BarclaysResponse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarclaysResponseExists(BarclaysResponse.BarclaysResponseID))
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

        private bool BarclaysResponseExists(int id)
        {
            return _context.BarclaysResponse.Any(e => e.BarclaysResponseID == id);
        }
    }
}

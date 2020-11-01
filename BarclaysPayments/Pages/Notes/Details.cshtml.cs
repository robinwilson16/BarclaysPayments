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

namespace BarclaysPayments.Pages.Notes
{
    [Authorize(Roles = "ALLSTAFF")]
    public class DetailsModel : PageModel
    {
        private readonly BarclaysPayments.Data.ApplicationDbContext _context;

        public DetailsModel(BarclaysPayments.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Note Note { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Note = await _context.Note.FirstOrDefaultAsync(m => m.NoteID == id);

            if (Note == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

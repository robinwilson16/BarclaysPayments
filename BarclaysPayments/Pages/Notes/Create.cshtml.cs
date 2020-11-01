using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BarclaysPayments.Data;
using BarclaysPayments.Models;
using Microsoft.AspNetCore.Authorization;

namespace BarclaysPayments.Pages.Notes
{
    [Authorize(Roles = "ALLSTAFF")]
    public class CreateModel : PageModel
    {
        private readonly BarclaysPayments.Data.ApplicationDbContext _context;

        public CreateModel(BarclaysPayments.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int transactionID)
        {
            Note = new Note
            {
                TransactionID = transactionID,
                CreatedDate = DateTime.Now,
                CreatedBy = User.Identity.Name
        };
            
            return Page();
        }

        [BindProperty]
        public Note Note { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Note.CreatedDate = DateTime.Now;
            Note.CreatedBy = User.Identity.Name;

            _context.Note.Add(Note);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
            //return Page();
        }
    }
}
